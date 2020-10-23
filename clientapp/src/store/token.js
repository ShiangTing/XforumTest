export default {
  state: {
    refreshToken: '',
    token: '',
    expireTime: '',
    isAuthorize: false,
  },
  mutations: {
    SET_AUTH(state, payload) {
      state.token = payload.token;
      state.refreshToken = payload.refreshToken;
      state.expireTime = payload.expireTime;
      state.isAuthorize = payload.isAuthorize;
    },
    CLEAR_AUTH(state) {
      state.token = '';
      state.refreshToken = '';
      state.expireTime = '';
      state.isAuthorize = false;
    },
  },
  actions: {
    setAuth(context, option) {
      context.commit('SET_AUTH', {
        token: option.token,
        isAuthorize: option.isAuthorize,
        refreshToken: option.refreshToken,
        expireTime: option.expireTime
      });
    },
    clearAuth(context) {
      context.commit('CLEAR_AUTH');
    },
  },
};
