<template>
  <div>
    <Navbar />
    <div class="container px-4 py-5 p-lg-5">
      <div class="row justify-content-center">
        <div class="card p-lg-5 p-3 w-100" style="max-width: 35rem">
          <div class="card-body">
            <h1 class="login-title">登入</h1>
            <div class="alert alert-danger" role="alert" v-if="error.isError">
              {{ error.message }}
            </div>
            <form>
              <div class="form-group">
                <label for="account">帳號</label>
                <input
                  type="text"
                  class="form-control"
                  id="account"
                  aria-describedby="emailHelp"
                  placeholder="輸入帳號"
                  v-model="loginData.email"
                />
              </div>
              <div class="form-group">
                <label for="password">密碼</label>
                <input
                  type="password"
                  class="form-control"
                  id="password"
                  placeholder="輸入密碼"
                  v-model="loginData.password"
                />
              </div>
              <input
                type="button"
                class="w-100 btn btn-primary"
                v-on:click="login"
                value="登入"
              />
            </form>
            <p class="mt-3 text-center">
              <router-link :to="{ name: 'forgetAccount' }"> 忘記密碼 /</router-link>
              <router-link :to="{ name: 'register' }"> 註冊</router-link>
            </p>
          </div>
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
      loginData: {
        email: "",
        password: "",
      },
      error: {
        isError: false,
        message: "",
      },
    };
  },
  methods: {
    login() {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/JwtHelper/signin";
      vm.$axios
        .post(url, vm.loginData)
        .then((res) => {
          if (res.status == 200 && res.data.issuccessful) {
            let data = {
              refreshToken: res.data.refreshToken,
              token: res.data.token,
              expireTime: res.data.expireTime,
              isAuthorize: true,
            };
            vm.$store.dispatch("setAuth", data);
            vm.$router.push("/");
          } else if (res.status == 200 && !res.data.issuccessful) {
            vm.error.isError = true;
            vm.error.message = res.data.errorMsg;
          }
        })
        .catch((err) => {
          vm.error.isError = true;
          vm.error.message = err.response.data.message;
        });
    },
  },
};
</script>
<style lang="scss" scoped>
@import "@/Assets/scss/style.scss";
.card {
  box-shadow: 0px 0px 20px 10px rgba(168, 173, 175, 0.3);
}
.login-title {
  text-align: center;
  font-size: 35px;
  font-weight: 700;
  margin-bottom: 10px;
  letter-spacing: 3px;
}
label {
  font-size: 16px;
  margin-bottom: 5px;
}
.form-control {
  height: 45px;
  border-radius: 30px;
  padding: 10px 30px;
  transition: 0.5s;
  &:active,
  &:focus {
    transform: scale(1.05);
    color: #495057;
    background-color: #fff;
    border-color: #343a40;
    outline: 0;
    box-shadow: 0 0 0 0.2rem rgba(48, 48, 48, 0.3);
  }
}
.btn {
  height: 45px;
  border-radius: 30px;
  padding: 10px 30px;
}
</style>