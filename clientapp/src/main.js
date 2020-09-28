import Vue from "vue";
import Router from "./router";
import App from "./App.vue";
import VueParticles from "vue-particles";

Vue.use(VueParticles);

new Vue({
  el: "#app",
  router: Router,
  render: (h) => h(App),
});
