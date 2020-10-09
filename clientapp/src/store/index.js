import Vue from 'vue';
import Vuex from 'vuex';
// vuex 長期存儲套件
import createPersistedState from 'vuex-persistedstate';

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
      storage: window.sessionStorage,
      reducer(val) {
        return { tokenModule: val.tokenModule}
      }
    }),
  ],
});
