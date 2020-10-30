import axios from 'axios';
import store from '../store/index';
import errorHandle from './errorHandle';
// axios 配置
const instance = axios.create();

instance.interceptors.request.use(
  (config) => {
    if (
      config.url.indexOf('/refresh') >= 0 ||
      config.url.indexOf('/login') >= 0
    ) {
      return config;
    }
    if (store.state.tokenModule.isAuthorize) {
      config.headers.Authorization = `Bearer ${store.state.tokenModule.token}`;
    }
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
    if (error.response.status === 401) {
      const token = await refreshAccessToken();
      if (token !== "") {
        originalRequest.headers.Authorization = 'Bearer ' + token;
        return instance(originalRequest);
      }
      else {
        alert("登入驗證過期請重新登入")
      }
    }
    if (error.response.status) {
      errorHandle(error.response.status.toString(), error.response.config.url);
    }

    return Promise.reject(error.response.data);
  }
);
function refreshAccessToken() {
  let refreshUrl = process.env.VUE_APP_API + '/api/JwtHelper/refresh';
  let refreshToken = store.state.tokenModule.refreshToken;
  axios
    .post(refreshUrl, { refreshToken: refreshToken })
    .then((res) => {
      if (res.status === 200 && res.data.issuccessful) {
        let data = {
          refreshToken: res.data.refreshToken,
          token: res.data.token,
          expireTime: res.data.expireTime,
          isAuthorize: true,
        };
        store.dispatch('setAuth', data);
        return store.state.tokenModule.token;
      } else {
        return "";
      }
    })
    .catch(() => {
      console.log('登入驗證錯誤');
    });
}
export default instance;
