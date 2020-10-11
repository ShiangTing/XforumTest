import Vue from 'vue';
import Router from './router';
import App from './App.vue';
import VueParticles from 'vue-particles';
import BoostrapVue from 'bootstrap-vue';
import infiniteScroll from 'vue-infinite-scroll'
import { library } from '@fortawesome/fontawesome-svg-core';
import {
  faShoppingCart,
  faCoffee,
  faAngry,
  faUser,
  faBookDead,
  faUserGraduate,
  faGhost,
  faPen
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import VueQuillEditor from "vue-quill-editor";

import "quill/dist/quill.core.css"; // import styles
import "quill/dist/quill.snow.css"; // for snow theme
import "quill/dist/quill.bubble.css"; // for bubble theme
import store from './store'

import axios from 'axios';




Vue.prototype.$axios = axios
Vue.component('font-awesome-icon', FontAwesomeIcon); //使用kebab-case
library.add(
  faShoppingCart,
  faCoffee,
  faAngry,
  faUser,
  faBookDead,
  faUserGraduate,
  faGhost,
  faPen
);

Vue.prototype.$bus = new Vue();
Vue.use(VueParticles);
Vue.use(BoostrapVue);
Vue.use(VueQuillEditor);
Vue.use(infiniteScroll)
new Vue({
  el: '#app',
  router: Router,
  store,
  render: (h) => h(App)
});