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
      path: '*',
      redirect: { name: 'home' },
    },
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
      path: '/Rank',
      component: () => import('./views/Rank.vue'),
      name: 'rank',
    },
    {
      path: '/Post',
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
      path: '/MemberCenter',
      component: () => import('./views/MemberCTR.vue'),
      name: 'memberCTR',

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
              },
            ],
          },
        },
      ],
    },
    {
      path: '*',
      component: () => import('./views/404.vue'),
    },
    {
      path: '/article/:id',
      component: () => import('./views/Article.vue')
    },
  ],
});