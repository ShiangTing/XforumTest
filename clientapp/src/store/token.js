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
    },
    CLEAR_AUTH(state){
      state.token = "",
      state.isAuthorize = false
    }
  },
  actions: {
    setAuth(context,option){
      context.commit("GET_AUTH", { 
        token: option.token,
        isAuthorize: option.isAuthorize })
    },
    clearAuth(context){
      context.commit("CLEAR_AUTH")
    }
  },
};
