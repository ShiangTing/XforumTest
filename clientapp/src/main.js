import Vue from 'vue';
import Router from './router';
import App from './App.vue';
import VueParticles from 'vue-particles';
import 'bootstrap';
import BoostrapVue from 'bootstrap-vue';
import infiniteScroll from 'vue-infinite-scroll'
import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';
import VueLoading from 'vue-loading-overlay';
import 'vue-loading-overlay/dist/vue-loading.css'
import { library } from '@fortawesome/fontawesome-svg-core';
import {
  faShoppingCart,
  faCoffee,
  faAngry,
  faUser,
  faBookDead,
  faUserGraduate,
  faGhost,
  faPen,
  faThumbsUp,
  faThumbsDown,
  faTrash,
  faHeart,
  faBookmark,
  faCrown,
  faCaretDown,
  faClipboardCheck
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import VueQuillEditor from "vue-quill-editor";

import 'quill/dist/quill.core.css'; // import styles
import 'quill/dist/quill.snow.css'; // for snow theme
import 'quill/dist/quill.bubble.css'; // for bubble theme
import store from './store';
import axios from './apis/https';
// Vee-Validate
import {
  ValidationObserver,
  ValidationProvider,
  extend,
  localize,
} from 'vee-validate';
import { required, email } from 'vee-validate/dist/rules';
import TW from 'vee-validate/dist/locale/zh_TW.json';

localize('zh_TW', TW);

extend('required', {
  ...required,
  message: '*欄位不得為空',
});
extend('email', {
  ...email,
  message: '*{_field_}格式錯誤'
});
extend('min', {
  validate(value, args) {
    return value.length >= args.length;
  },
  params: ['length'],
  message: '*長度至少 6 字元',
});
extend('password', {
  params: ['target'],
  validate(value, { target }) {
    return value === target;
  },
  message: '*密碼不相符',
});
Vue.use(VueLoading, {
  canCancel: false,
  color: '#000000',
  loader: 'dots', //spinner/dots/bars
  width: 50,
  height: 50,
  backgroundColor: '#ffffff',
  isFullPage: true,
  opacity: 0.8
});
Vue.component('font-awesome-icon', FontAwesomeIcon); //使用kebab-case
Vue.component('ValidationProvider', ValidationProvider);
Vue.component('ValidationObserver', ValidationObserver);
library.add(
  faShoppingCart,
  faCoffee,
  faAngry,
  faUser,
  faBookDead,
  faUserGraduate,
  faGhost,
  faPen,
  faThumbsUp,
  faThumbsDown,
  faTrash,
  faBookmark,
  faHeart,
  faCrown,
  faCaretDown,
  faClipboardCheck
);

Vue.prototype.$axios = axios;
Vue.prototype.$bus = new Vue();
Vue.use(VueParticles);
Vue.use(BoostrapVue);
Vue.use(VueQuillEditor);
Vue.use(infiniteScroll);
Vue.use(VueSweetalert2);
new Vue({
  el: '#app',
  router: Router,
  store,
  axios,
  render: (h) => h(App),
});
