<template>
  <div class="main-nav">
    <b-navbar toggleable="lg" type="dark" variant="dark">
      <router-link class="title mx-5 my-2" to="/">Xforum</router-link>
      <!-- <b-navbar-brand href="#">Xforum</b-navbar-brand> -->

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav class="ml-auto">
          <b-nav-form>
            <b-form-input
              size="sm"
              class="mr-sm-2 mx-5"
              placeholder="Search"
            ></b-form-input>
            <b-button size="sm" class="my-2 ml-5 my-sm-0" type="submit"
              >Search</b-button
            >
          </b-nav-form>
          <b-nav-item to="/post" class="mx-5 my-2">Po文!</b-nav-item>
          <!-- <router-link class="mx-5 my-2" to="/post">Po文!</router-link> -->

          <b-nav-item-dropdown class="mx-5 my-2">
            <!-- Using 'button-content' slot -->
            <template v-slot:button-content>
              <font-awesome-icon icon="user" size="lg"/>
            </template>
            <b-dropdown-item href="#">會員中心</b-dropdown-item>
            <b-dropdown-item href="#" v-if="!isLogin">註冊</b-dropdown-item>
            <b-dropdown-item to="/login" v-if="!isLogin">登入</b-dropdown-item>
            <b-dropdown-item v-else @click.prevent="logout">登出</b-dropdown-item>
          </b-nav-item-dropdown>
          <b-nav-item href="jacascript:;" class="mx-5 my-2">{{name}}</b-nav-item>
          <!-- Using 'button-content' slot -->
          <b-nav-item class="sidebarGroup"><SideBar /></b-nav-item>
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
  data(){
    return {
      name: "訪客",
      isLogin: false
    }
  },
  methods:{
    logout(){
      let vm = this;
      vm.$store.dispatch("clearAuth");
      window.localStorage.clear();
      vm.$router.go(0);
    }
  },
  created(){
    let vm = this;
    let auth = vm.$store.state.tokenModule;
    let isAuth =  auth.isAuthorize;
    let token = auth.token;
    let url = process.env.VUE_APP_API+"/api/JwtHelper/username"
    console.log(auth);
    if(isAuth){
      vm.isLogin = true
      vm.$axios({
        url: url,
        method: "GET",
        headers: {"Authorization": `Bearer ${token}` }
      }).then(res => {
        vm.name = res.data
      })
    }
  }
};
</script>

<style lang="scss" scoped>
@media screen and (min-width: 996px) {
  .sidebarGroup {
    display: none;
  }
}
</style>
