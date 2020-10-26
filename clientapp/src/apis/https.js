import axios from 'axios';
import store from '../store/index';
import errorHandle from './errorHandle';
// axios 配置
const instance = axios.create();
instance.defaults.timeout = 5000;

instance.interceptors.request.use(
  (config) => {
    let expireTime = store.state.tokenModule.expireTime;
    if (store.state.tokenModule.isAuthorize) {
      config.headers.Authorization = `Bearer ${store.state.tokenModule.token}`;
    }
    if (
      config.url.indexOf('/refresh') >= 0 ||
      config.url.indexOf('/login') >= 0
    ) {
      return config;
    }

    if (parseInt(expireTime) <= parseInt(Date.now() / 1000)) {
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
          config.headers.Authorization = `Bearer ${store.state.tokenModule.token}`;
        })
        .catch((err) => {
          console.err(err);
        });
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
  (error) => {
    let err = error.response;
    if (err.status) {
      errorHandle(err.status.toString(), err.data);
    }
    return Promise.reject(error.response.data);
  }
);

export default instance;
