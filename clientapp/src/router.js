import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

const originalPush = VueRouter.prototype.push;
VueRouter.prototype.push = function push(location) {
  return originalPush.call(this, location).catch(err => err)
}

export default new VueRouter({
  mode: 'hash',
  routes: [

    {
      path: '/Login',
      component: () => import('./views/Login.vue'),
      name: 'login',
    },
    {
      path: '/Register',
      component: () => import('./views/Register.vue'),
      name: 'register',
    },
    {
      path: '/CreateThread',
      component: () => import('./views/CreateThread.vue'),
      name: 'createthread',
    },
    {
      path: '/post',
      component: () => import('./views/Post.vue'),
      name: 'post',
      meta: {
        isAuthorize: true,
        breadcrumb: [
          {
            name: '首頁',
            link: '/',
          },
          {
            name: '發文區',
            link: './views/Post.vue',
          },
        ],
      },
    },
    {
      path: '/LoveWheal',
      component: () => import('./views/LoveWheal.vue')
    },
    {
      path: '/',
      component: () => import('./views/Layout.vue'),
      children: [
        {
          path: '',
          name: 'home',
          component: () => import('./views/Index.vue'),
          meta: {
            breadcrumb: [
              {
                name: '首頁',
                link: '/',
              },
            ],
          },
        },
        {
          path: '/Thread/:routeName',
          component: () => import('./views/Thread.vue'),
          meta: {
            forumId: "",
            breadcrumb: [
              {
                name: '首頁',
                link: '/',

              },
              {
                // name: `${VueRouter.$route.name}`,
                // link: `${Vue.$route.params.routeName}`,
              },
            ],
          },
        },
      ],
    },
    {
      path: '*',
      component: () => import('./views/404.vue'),
      // meta: {
      //   title: 'RagnarokShopV3 - 404',
      // },
    },
    {
      path: '/article',
      component: () => import('./views/Article.vue')
    }
  ],
});