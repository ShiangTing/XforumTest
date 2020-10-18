<template>
  <div>
    <Navbar />
    <div class="container">
      <h2 class="pt-3 text-center">購買稱號</h2>
      <div class="d-flex justify-content-around">
        <div>
          <span>會員名稱:</span>
          <span>{{ user.userName }}</span>
        </div>
        <div>
          <span>會員點數:</span>
          <span>{{ user.points }}</span>
        </div>
        <div>
          <span>想要購買的稱號:</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar";
export default {
  components: { Navbar },
  data() {
    return {
      user: {
        userId: "",
        userName: "",
        points: "",
      },
    };
  },
  methods: {
    getUserId: function () {
      let vm = this;
      let auth = vm.$store.state.tokenModule;
      let isAuth = auth.isAuthorize;
      let token = auth.token;
      const url = process.env.VUE_APP_API + "/api/Users/GetUserId";
      if (isAuth) {
        vm.isLogin = true;
        vm.$axios({
          url: url,
          method: "GET",
          headers: { Authorization: `Bearer ${token}` },
        })
          .then((res) => {
            vm.user.userId = res.data;
            // console.log(vm.user.userId);
          })
          .catch((err) => console.log(err.response));
      }
    },
    getUserName: function () {
      let vm = this;
      let auth = vm.$store.state.tokenModule;
      let isAuth = auth.isAuthorize;
      let token = auth.token;
      const url = process.env.VUE_APP_API + "/api/Users/GetUserName";
      if (isAuth) {
        vm.isLogin = true;
        vm.$axios({
          url: url,
          method: "GET",
          headers: { Authorization: `Bearer ${token}` },
        })
          .then((res) => {
            vm.user.userName = res.data;
            // console.log(vm.user.userName);
          })
          .catch((err) => console.log(err.response));
      }
    },
  },

  async created() {
    await this.getUserId();
    await this.getUserName();
  },
};
</script>

<style lang="scss" scoped>
h2 {
  font-size: 50px;
}
span {
  font-size: 20px;
  color: #111;
  line-height: 10;
}
</style>