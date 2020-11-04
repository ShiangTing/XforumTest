<template>
  <div>
    <Navbar />
    <div class="container px-4 py-5 p-lg-5">
      <div class="row justify-content-center">
        <div class="card p-lg-5 p-3 w-100" style="max-width: 35rem">
          <div class="card-body">
            <h1 class="login-title">忘記密碼</h1>
            <div
              class="alert alert-danger"
              role="alert"
              v-if="accountErrorMsg.isError"
            >
              {{ accountErrorMsg.message }}
            </div>
            <div
              class="alert alert-danger"
              role="alert"
              v-if="errorMsg.isError"
            >
              {{ errorMsg.message }}
            </div>
            <div
              class="alert alert-danger"
              role="alert"
              v-if="confirmResult.confirmError"
            >
              {{ confirmResult.confirmErrorMsg }}
            </div>
            <form>
              <div class="form-group">
                <label for="account">帳號</label>
                <input
                  type="text"
                  class="form-control"
                  id="Account"
                  aria-describedby="emailHelp"
                  placeholder="輸入帳號"
                  v-model="changedPassword.Email"
                />
              </div>
              <div class="form-group">
                <label for="password">修改密碼</label>
                <input
                  type="password"
                  class="form-control"
                  id="newPassword"
                  placeholder="輸入新密碼"
                  v-model="changedPassword.Password"
                />
              </div>
              <div class="form-group">
                <label for="confirmNewPassword">確認新密碼</label>
                <input
                  type="password"
                  class="form-control"
                  id="confirmNewPassword"
                  placeholder="確認新密碼"
                  v-model="confirmResult.confirmPassword"
                />
              </div>
              <input
                type="button"
                class="w-100 btn btn-primary"
                value="送出修改"
                v-on:click="submitChangedPassword"
              />
            </form>
            <!-- <p class="mt-3 text-center">
              <router-link :to="{ name: 'forgetAccount' }"> 註冊</router-link>
              <router-link :to="{ name: 'register' }"> 註冊</router-link>
            </p> -->
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar";
import axios from "axios";

export default {
  components: { Navbar },
  data() {
    return {
      changedPassword: {
        Email: "",
        Password: "",
      },
      errorMsg: {
        isError: false,
        message: "",
      },
      accountErrorMsg: {
        isError: false,
        message: "",
      },
      confirmResult: {
        confirmPassword: "",
        confirmError: false,
        confirmErrorMsg: "",
      },
    };
  },
  methods: {
    submitChangedPassword() {
      let url = process.env.VUE_APP_API + "/api/Users/EditPasswordIfForgot";
      this.accountErrorMsg.isError = false;
      this.accountErrorMsg.message = "";
      if (this.changedPassword.Email == "") {
        this.errorMsg.isError = true;
        this.errorMsg.message = "請輸入帳號！";
      }
      if (
        this.changedPassword.Email != "" &&
        (this.changedPassword.Password == "" ||
          this.confirmResult.confirmPassword == "")
      ) {
        this.errorMsg.isError = true;
        this.errorMsg.message = "請輸入密碼並確認密碼！";
      }
      if (this.confirmResult.confirmPassword != this.changedPassword.Password) {
        this.confirmResult.confirmError = true;
        this.confirmResult.confirmErrorMsg = "確認密碼不吻合，請再確認！";
      } else {
        axios({
          url: url,
          method: "Patch",
          data: this.changedPassword,
        })
          .then((result) => {
            if (result.status == 200 && result.data.issuccessful) {
              this.$swal
                .fire({
                  title: "完成修改密碼！",
                  text: "請使用新密碼登入!",
                  confirmButtonColor: "#3085d6",
                  cancelButtonColor: "#d33",
                  confirmButtonText: "OK",
                })
                .then((result) => {
                  if (result.isConfirmed) {
                    this.$router.push("/login");
                  }
                });
            }
            if (result.status == 200 && !result.data.issuccessful) {
              this.accountErrorMsg.isError = true;
              this.accountErrorMsg.message = result.data.errorMsg;
            }
          })
          .catch(() => {});
      }
    },
  },
  watch: {
    "confirmResult.confirmPassword": {
      immediate: false,
      handler() {
        if (
          this.confirmResult.confirmPassword != "" &&
          this.confirmResult.confirmPassword != this.changedPassword.Password
        ) {
          this.confirmResult.confirmError = true;
          this.confirmResult.confirmErrorMsg = "確認密碼不吻合，請再確認！";
        } else {
          this.confirmResult.confirmError = false;
          this.confirmResult.confirmErrorMsg = "";
        }
      },
    },
    "changedPassword.Email": {
      immediate: false,
      handler() {
        if (this.changedPassword.Email == "") {
          this.errorMsg.isError = true;
          this.errorMsg.message = "請輸入帳號！";
        } else {
          this.errorMsg.isError = false;
          this.errorMsg.message = "";
        }
      },
    },
    "changedPassword.Password": {
      immediate: false,
      handler() {
        if (this.changedPassword.Password == "") {
          this.errorMsg.isError = true;
          this.errorMsg.message = "請輸入密碼！";
        } else {
          this.errorMsg.isError = false;
          this.errorMsg.message = "";
        }
      },
    },
  },
};
</script>

<style></style>
