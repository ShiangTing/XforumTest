import axios from 'axios';
import store from '../store/index';
import errorHandle from './errorHandle';
// axios 配置
const instance = axios.create();
instance.defaults.timeout = 5000;

instance.interceptors.request.use(
  (config) => {
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
