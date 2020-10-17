import axios from 'axios';
import store from '../store/index';
import errorHandle from './https'
// axios 配置
axios.defaults.timeout = 5000;

axios.interceptors.request.use(
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

axios.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    let err = error.response;
    if (err) {
      errorHandle(err.status.toString(),err.data)
    }
    return Promise.reject(error.response.data);
  }
);

export default axios;
