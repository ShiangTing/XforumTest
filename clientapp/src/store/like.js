
import axios from 'axios'
export default {
  state: {
    article:{
      like: 0,
      dislike: 0
    },
    messageLikeList: [],
    message: {
      like: 0,
      dislike: 0
    }
  },
  mutations: {
    GET_ARTICLE(state, payload){
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