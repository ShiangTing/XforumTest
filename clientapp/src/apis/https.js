import axios from 'axios';
import store from '../store/index';
import router from '../router';
// axios 配置
const instance = axios.create();

let isRefreshing = false;
let refreshSubscribers = [];
let failTimes = 0;

instance.interceptors.request.use(
  async (config) => {
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
  (error) => {
    const originalRequest = error.config;
    if (error.response.status === 401) {
      //錯誤超過5次就停止請求
      if (failTimes <= 5) {
        failTimes++;
      } else {
        alert('驗證失敗請重新登入');
        return;
      }
      if (!isRefreshing) {
        isRefreshing = true;
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
              return res.data.token;
            } else {
              return '';
            }
          })
          .then((newToken) => {
            if (newToken === '') {
              isRefreshing = false;
              refreshSubscribers = [];
            } else {
              isRefreshing = false;
              onRefreshed(newToken);
            }
          })
          .catch(() => {
            alert('驗證過期，請重新登入');
            router.push('/login');
          });
      }

      const retryOrigReq = new Promise((resolve) => {
        subscribeTokenRefresh((token) => {
          // replace the expired token and retry
          originalRequest.headers['Authorization'] = 'Bearer ' + token;
          resolve(axios(originalRequest));
        });
      });
      return retryOrigReq;
    } else {
      return Promise.reject(error.response.data);
    }
  }
);
function subscribeTokenRefresh(cb) {
  refreshSubscribers.push(cb);
}

function onRefreshed(token) {
  refreshSubscribers.map((cb) => cb(token));
}
export default instance;
