import axios from 'axios';
import store from '../store/index';
import errorHandle from './errorHandle';
// axios 配置
const instance = axios.create();
instance.defaults.timeout = 5000;

instance.interceptors.request.use(
  (config) => {
    let refreshUrl = process.env.VUE_APP_API + '/api/JwtHelper/refresh';
    console.log(
      parseInt(store.state.tokenModule.expireTime),
      parseInt(Date.now() / 1000)
    );
    if (
      store.state.tokenModule.isAuthorize &&
      parseInt(store.state.tokenModule.expireTime) >=
        parseInt(Date.now() / 1000)
    ) {
      config.headers.Authorization = `Bearer ${store.state.tokenModule.token}`;
    } else if (
      parseInt(store.state.tokenModule.expireTime) <=
      parseInt(Date.now() / 1000)
    ) {
      axios
        .post(refreshUrl, store.state.tokenModule.refreshToken)
        .then((res) => {
          let data = {
            refreshToken: res.data.refreshToken,
            token: res.data.token,
            expireTime: res.data.expireTime,
            isAuthorize: true,
          };
          store.dispatch('setAuth', data);
          config.headers.Authorization = `Bearer ${store.state.tokenModule.token}`;
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
    if (err) {
      console.log(err);
      errorHandle(err.status.toString(), err.data);
    }
    return Promise.reject(error.response.data);
  }
);

export default instance;
