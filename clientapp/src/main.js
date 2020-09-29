import Vue from "vue";
import Router from "./router";
import App from "./App.vue";
import VueParticles from "vue-particles";
import BoostrapVue from "bootstrap-vue";

Vue.use(VueParticles);
Vue.use(BoostrapVue);

new Vue({
  el: "#app",
  router: Router,
  render: (h) => h(App),
});
