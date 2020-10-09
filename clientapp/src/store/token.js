// import axios from 'axios'

export default {
  state: {
    isAuthorize: false,
    token: ""
  },
  mutations: {
    GET_AUTH(state, payload){
      state.token = payload.token;
      state.isAuthorize = payload.isAuthorize
    }
  },
  actions: {
    setAuth(context,option){
      context.commit("GET_AUTH", { 
        token: option.token,
        isAuthorize: option.isAuthorize })
    }
  },
};
