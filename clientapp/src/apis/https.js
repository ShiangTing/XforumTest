import axios from 'axios';
import store from '../store/index';
import errorHandle from './errorHandle';
// axios 配置
const instance = axios.create();
instance.defaults.timeout = 5000;

instance.interceptors.request.use(
  (config) => {
    //   let expireTime = store.state.tokenModule.expireTime;
    if (store.state.tokenModule.isAuthorize) {
      config.headers.Authorization = `Bearer ${store.state.tokenModule.token}`;
    }
    if (
      config.url.indexOf('/refresh') >= 0 ||
      config.url.indexOf('/login') >= 0
    ) {
      return config;
    }
    // if (parseInt(expireTime) <= parseInt(Date.now() / 1000)) {
    //   refreshAccessToken();
    //   config.headers.Authorization = `Bearer ${store.state.tokenModule.token}`;
    // }
    return config;
  },
  (err) => {
    return Promise.reject(err);
  }
);

instance.interceptors.response.use(
  (response) => {
    return response;
  },
  async (error) => {
    const originalRequest = error.config;
    let err = error.response;
    let expireTime = parseInt(store.state.tokenModule.expireTime);
    let nowTime = parseInt(Date.now() / 1000);
    if (err.status === 401 && expireTime <= nowTime && store.state.tokenModule.isAuthorize) {
      window.localStorage.clear();
      const token = await refreshAccessToken();
      originalRequest.headers.Authorization =
        'Bearer ' + token;
      return instance.request(originalRequest);
    }
    if (err.status) {
      errorHandle(err.status.toString(), err.config.url);
    }

    return Promise.reject(error.response.data);
  }
);
let refreshAccessToken = function() {
  let refreshUrl = process.env.VUE_APP_API + '/api/JwtHelper/refresh';
  let refreshToken = store.state.tokenModule.refreshToken;
  axios
    .post(refreshUrl, { refreshToken: refreshToken })
    .then((res) => {
      let data = {
        refreshToken: res.data.refreshToken,
        token: res.data.token,
        expireTime: res.data.expireTime,
        isAuthorize: true,
      };
      store.dispatch('setAuth', data);
      return store.state.tokenModule.token;
    })
    .catch((err) => {
      console.err(err);
      alert('驗證過期請重新登入')
    });
};
export default instance;
