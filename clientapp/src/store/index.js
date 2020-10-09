import Vue from 'vue';
import Vuex from 'vuex';
// vuex 長期存儲套件
import createPersistedState from 'vuex-persistedstate';
import SecureLS from "secure-ls"
const ls = new SecureLS({ isCompression: false })
import tokenModule from './token';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {},
  mutations: {},
  actions: {},
  modules: {
    tokenModule,
  },
  plugins: [
    createPersistedState({
      key: 'userInfo',
      storage: {
        getItem: key => ls.get(key),
        setItem: (key, value) => ls.set(key, value),
        removeItem: key => ls.remove(key)
      }
    }),
  ],
});
