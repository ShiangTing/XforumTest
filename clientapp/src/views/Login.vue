<template>
  <div>
    <Navbar />
    <div class="container">
      <div class="row justify-content-center m-5">
        <div class="card p-5" style="width: 35rem;">
          <div class="card-body">
            <h1 class="login-title">登入</h1>
            <form>
              <div class="form-group">
                <label for="account">帳號</label>
                <input type="text" class="form-control" id="account" aria-describedby="emailHelp" placeholder="輸入帳號"
                  v-model="loginData.username">
              </div>
              <div class="form-group">
                <label for="password">密碼</label>
                <input type="password" class="form-control" id="password" placeholder="輸入密碼" v-model="loginData.password">
              </div>
              <div class="form-group form-check text-center">
                <input type="checkbox" class="form-check-input" id="Remember">
                <label class="form-check-label" for="Remember">記住我</label>
              </div>
              <input type="button" class="w-100 btn btn-primary" v-on:click="login" value="登入">
            </form>
            <p class="mt-3 text-center"><a href="javascript:;">忘記密碼</a> / <a href="javascript:;">註冊</a></p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar"
import axios from "axios"
export default {
  components: { Navbar },
  data () {
    return {
      loginData: {
        username: "",
        password: ""
      }
    };
  },
  methods: {
    login () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/JwtHelper/signin"
			axios.post(url,vm.loginData).then(res => {
        console.log(res);
        if(res.status == 200){
          window.sessionStorage.setItem("token", res.data.token);
          let { token, isAuthorize} = { token: res.data.token , isAuthorize: true };
          vm.$store.dispatch("setAuth",{ token, isAuthorize})
          vm.$router.push("/home");
        }
			})
    }
  }
}
</script>
<style lang="scss" scoped>
  @import "@/Assets/scss/style.scss";
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