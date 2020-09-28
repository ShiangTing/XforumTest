import Vue from "vue";
import VueRouter from "vue-router";

import Courses from "./components/Courses";
import CourseList from "./components/CourseList.vue";
import CourseDetail from "./components/CourseDetail.vue";
import Booking from "./components/Booking";
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
          component: () => import("./components/Index.vue"),
        },
        {
          path: "/about",
          component: () => import("./components/About.vue"),
          // component: About,
          // children: [
          // { path: "", component: AboutHome },
          // { path: "us", name: "come-on", component: AboutUs },
          // { path: "you", component: AboutYou },
          // ],
        },

        {
          path: "/courses",
          component: Courses,
          children: [
            {
              path: "",
              component: CourseList,
            },
            {
              path: ":id",
              component: CourseDetail,
            },
          ],
        },
        { path: "/booking", component: Booking },
      ],
    },

    {
      path: "/courses",
      component: Courses,
      children: [
        {
          path: "",
          component: CourseList,
        },
        {
          path: ":id",
          component: CourseDetail,
        },
      ],
    },
    { path: "/booking", component: Booking },
    // { path: "/products/:id?", name: "prod", component: Products },
    // { path: "*", redirect: "/about" },
  ],
});
