import Vue from 'vue';
import Vuex from 'vuex';
// vuex 長期存儲套件
import createPersistedState from 'vuex-persistedstate';
import SecureLS from 'secure-ls';
const ls = new SecureLS({
  isCompression: false,
});
import tokenModule from './token';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    isLoading: false,
  },
  mutations: {
    LOADING(state,payload){
      state.isLoading = payload
    } 
  },
  actions: {
    isLoading (context) {
      context.commit('LOADING', status)
    },
  },
  modules: {
    tokenModule,
  },
  plugins: [
    createPersistedState({
      reducer(val){
        return {tokenModule: val.tokenModule}
      },
      storage: {
        getItem: (key) => ls.get(key),
        setItem: (key, value) => ls.set(key, value),
        removeItem: (key) => ls.remove(key),
      },
    }),
  ],
});
