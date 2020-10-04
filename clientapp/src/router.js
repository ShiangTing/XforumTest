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
      path: "/post",
      component: () => import("./views/Post.vue"),
      name: "post",
      meta: {
        breadcrumb: [
          {
            name: "首頁",
            link: "/",
          },
          {
            name: "發文區",
            link: "./views/Post.vue",
          },
        ],
      },

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
                    // name: `${VueRouter.$route.name}`,
                    // link: `${Vue.$route.params.routeName}`,
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
