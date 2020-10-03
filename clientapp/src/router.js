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
          meta: {
            breadcrumb: [
              {
                name: "首頁",
                link: "/",
              },
            ],
          },
          children: [
            {
              path: ":routeName",
              component: () => import("./views/Thread.vue"),
              meta: {
                breadcrumb: [
                  {
                    name: "首頁",
                    link: "/",
                  },
                  {
                    name: "Xforum討論區！！",
                    // link: `${$route.params.routeName}`,
                  },
                ],
              },
              // meta: {
              //   breadcrumb: [
              //     {
              //       name: "123",
              //     },
              //     // {
              //     //   name: "關於我",
              //     // },
              //   ],
              // },
            },
          ],
        },
      ],
    },
  ],
});

// {
//   path: "/courses",
//   component: Courses,
//   children: [
//     {
//       path: "",
//       component: CourseList,
//     },
//     {
//       path: ":id",
//       component: CourseDetail,
//     },
//   ],
// },
