import Vue from "vue";
import VueRouter from "vue-router";
Vue.use(VueRouter);

export default new VueRouter({
  mode: "hash",
  routes: [
    {
      path: "*",
      redirect: { name: "home" },
      // meta: {
      //   title: 'RagnarokShopV3 - 404',
      // },
    },
    {
      path: "/",
      component: () => import("./views/Layout.vue"),
      children: [
        {
          path: "",
          name: "home",
          component: () => import("./views/Index.vue"),
        },
      ],
    },
  ],
});
