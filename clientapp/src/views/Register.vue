<template>
  <div>
    <Navbar />
    <div class="container px-4 py-5 p-lg-5">
      <div class="d-flex justify-content-center">
        <div class="card p-lg-5 p-3 w-100" style="max-width: 35rem">
          <div class="card-body">
            <h1 class="login-title">註冊</h1>
            <ValidationObserver v-slot="{ handleSubmit }">
              <form>
                <div class="form-group">

                  <validation-provider rules="required" v-slot="{ errors }">
                    <div class="d-flex align-items-center">
                      <label for="account">暱稱</label>
                      <span class="text-danger text-center px-2 d-inline-block mb-1">{{ errors[0] }}</span>
                    </div>
                    <input id="account" class="form-control" type="text" v-model="registerData.username" />
                  </validation-provider>
                </div>
                <div class="form-group">
                  <validation-provider name="信箱" rules="required|email" v-slot="{ errors }">
                    <div class="d-flex align-items-center">
                      <label for="email">帳號</label>
                      <span class="text-danger text-center px-2 d-inline-block mb-1">{{ errors[0] }}</span>
                    </div>
                    <input id="email" class="form-control" type="text" v-model="registerData.email"
                      :placeholder="registerData.email === '' ? '輸入信箱':''" />
                  </validation-provider>
                </div>
                <div class="form-group">
                  <validation-provider name="confirm" rules="required|min:6" v-slot="{ errors }">
                    <div class="d-flex align-items-center">
                      <label for="password">密碼</label>
                      <span class="text-danger text-center px-2 d-inline-block mb-1">{{ errors[0] }}</span>
                    </div>
                    <input id="password" class="form-control" type="password" v-model="registerData.password"
                      :placeholder="registerData.password === '' ? '輸入超過6字元密碼':''" />
                  </validation-provider>
                </div>
                <div class="form-group">
                  <validation-provider rules="required|password:@confirm" v-slot="{ errors }">
                    <div class="d-flex align-items-center">
                      <label for="confirmPassword">確認密碼</label>
                      <span class="text-danger text-center px-2 d-inline-block mb-1">{{ errors[0] }}</span>
                    </div>
                    <input id="confirmPassword" class="form-control" type="password" v-model="registerData.confirmPassword" :placeholder="registerData.confirmPassword === '' ? '需與密碼相符':''" />
                  </validation-provider>
                </div>
                <div class="form-group">
                  <validation-provider rules="required" v-slot="{ errors }">
                    <div class="d-flex align-items-center">
                      <label for="gender">性別</label>
                      <span class="text-danger text-center px-2 d-inline-block mb-1">{{ errors[0] }}</span>
                    </div>
                    <div class="d-flex">
                      <div class="form-check mr-5">
                        <input class="form-check-input" type="radio" name="gender" id="male" value="male"
                          v-model="registerData.gender" />
                        <label class="form-check-label" for="male">
                          男性
                        </label>
                      </div>
                      <div class="form-check">
                        <input class="form-check-input" type="radio" name="gender" id="female" value="female"
                          v-model="registerData.gender" />
                        <label class="form-check-label" for="female">
                          女性
                        </label>
                      </div>
                    </div>
                  </validation-provider>
                </div>
                <button type="submit" class="w-100 btn btn-primary" @click.prevent="handleSubmit(register)">
                  註冊
                </button>
                <div class="alert mt-3" :class="message.isError ? 'alert-danger' : 'alert-success'" role="alert"
                  v-if="message.display" v-html="message.content"></div>
              </form>
            </ValidationObserver>
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
  data () {
    return {
      registerData: {
        username: "",
        email: "",
        password: "",
        confirmPassword: "",
        gender: "",
      },
      message: {
        display: false,
        isError: false,
        content: "",
      },
      timer: null,
    };
  },
  methods: {
    register () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/Users/Register";
      let data = {
        name: vm.registerData.username,
        Email: vm.registerData.email,
        Password: vm.registerData.password,
        Gender: vm.registerData.gender,
      };
      vm.$axios
        .post(url, data)
        .then((res) => {
          if (res.data.issuccessful) {
            vm.message.display = true;
            vm.message.isError = false;
            vm.message.content = "註冊成功將在5秒後自動跳轉";
            vm.timer = window.setTimeout(() => {
              vm.$router.push("/login");
            }, 5000);
          } else {
            vm.message.content = res.data.errorMsg;
            vm.message.display = true;
            vm.message.isError = true;
          }
        })
        .catch((err) => {
          vm.message.display = true;
          vm.message.isError = true;
          let errorData = err.response.data.errors;
          let str = "";
          str =
            vm.errorMessage(errorData.Name) +
            vm.errorMessage(errorData.Email) +
            vm.errorMessage(errorData.password);

          vm.message.content = str;
        });
    },
    errorMessage (item = []) {
      let str = "";
      item.forEach((data) => {
        str += `<li>${data}</li>`;
      });
      return str;
    },
  },
  beforeDestroy () {
    let vm = this;
    window.clearTimeout(vm.timer);
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
      border-color: rgba(218, 205, 29,0.4);
      outline: 0;
      box-shadow: 0 0 0.2rem 0.2rem rgba(218, 205, 29,0.4) ;
    }
  }
  select.form-control option {
    width: 150px;
  }
  .btn {
    height: 45px;
    border-radius: 30px;
    padding: 10px 30px;
  }
</style>