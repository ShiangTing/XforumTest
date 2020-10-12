<template>
  <div class="main-nav">
    <b-navbar toggleable="lg" type="dark" variant="dark" class="d-flex align-items-center">
      <router-link class="title mx-5 my-2 text-white" to="/">Xforum</router-link>
      <!-- <b-navbar-brand href="#">Xforum</b-navbar-brand> -->

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav class="ml-auto">
          <b-nav-item class="sidebarGroup">
            <SideBar />
          </b-nav-item>
          <b-nav-item class="pl-4" v-if="isLogin" to="/post">
            <font-awesome-icon icon="pen" />
          </b-nav-item>
          <b-nav-item class="pl-4" v-else to="/login">
            <font-awesome-icon icon="pen" />
          </b-nav-item>
          <!-- <router-link class="mx-5 my-2" to="/post">Po文!</router-link> -->
          <b-nav-item-dropdown class="pl-4" no-caret>
            <!-- Using 'button-content' slot -->
            <template v-slot:button-content>
              <font-awesome-icon icon="user" size="lg" />
              <span class="px-2">{{ name }}</span>
            </template>
            <b-dropdown-item to="/register" v-if="!isLogin">註冊</b-dropdown-item>
            <b-dropdown-item to="/login" v-if="!isLogin">登入</b-dropdown-item>
            <b-dropdown-item v-if="isLogin" href="javascript:;">會員中心</b-dropdown-item>
            <b-dropdown-item v-if="isLogin" @click.prevent="logout">登出</b-dropdown-item>
          </b-nav-item-dropdown>
          <!-- Using 'button-content' slot -->
          <b-nav-form class="pl-4 py-2">
            <b-form-input size="sm" placeholder="Search"></b-form-input>
            <b-button size="sm" type="submit">Search</b-button>
          </b-nav-form>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>

<script>
import SideBar from "../Home/Sidbar";
export default {
  components: {
    SideBar,
  },
  data () {
    return {
      name: "訪客",
      isLogin: false,
    };
  },
  methods: {
    logout () {
      let vm = this;
      window.localStorage.clear();
      vm.$router.go(0);
    },
  },
  created () {
    let vm = this;
    let auth = vm.$store.state.tokenModule;
    let isAuth = auth.isAuthorize;
    let token = auth.token;
    let url = process.env.VUE_APP_API + "/api/JwtHelper/username";
    if (isAuth) {
      vm.isLogin = true;
        vm.$axios({
          url: url,
          method: "GET",
          headers: { "Authorization": `Bearer ${token}` }
        }).then(res => {
          vm.name = res.data
        }).catch(err => {
          console.log(err);
          window.localStorage.clear();
        });
    }
  }
};
</script>

<style lang="scss" scoped>
  /deep/ .list-group .list-group-item {
    background-color: #343a40;
    border: 0;
    span.text-primary {
      color: rgba(255, 255, 255, 0.5) !important;
    }
  }
  @media screen and (min-width: 996px) {
    .sidebarGroup {
      display: none;
    }
    :focus {
      outline: 0px;
    }
  }
</style>
