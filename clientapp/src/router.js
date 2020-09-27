import Vue from "vue";
import VueRouter from "vue-router";
// import Products from "./components/Products";
import About from "./components/About";
import Courses from "./components/Courses";
import CourseList from "./components/CourseList.vue";
import CourseDetail from "./components/CourseDetail.vue";
import Booking from "./components/Booking";

// import AboutHome from "./components/AboutHome";
// import AboutUs from "./components/AboutUs";
// import AboutYou from "./components/AboutYou";

Vue.use(VueRouter);

export default new VueRouter({
  mode: "hash",
  routes: [
    {
      path: "/about",
      component: About,
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
    // { path: "/products/:id?", name: "prod", component: Products },
    // { path: "*", redirect: "/about" },
  ],
});
