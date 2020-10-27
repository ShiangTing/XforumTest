<template>
  <div>
    <Navbar />
    <div class="container">
      <div class="d-flex">
        <div class="d-flex flex-column mt-5">
          <h4><b>會員頭像</b></h4>
          <div class="mt-3">
            <img
              style="border: 1px dashed wheat"
              v-if="hasImg"
              id="blah"
              alt="上傳您的頭像"
              width="100"
              height="100"
              :src="user.imgLink"
            />
            <img
              style="border: 1px dashed wheat"
              v-else
              id="blah"
              :src="user.imgLink"
              alt="上傳您的頭像"
              width="100"
              height="100"
            />
          </div>

          <input
            class="mt-3"
            type="file"
            name="file"
            ref="file"
            @change="handleFileUpload"
          />
        </div>
        <div class="d-flex flex-column mt-5 ml-5">
          <h4><b>X幣</b></h4>
          <h3>
            <b>${{ user.points }}</b>
          </h3>
        </div>
      </div>
      <b-form>
        <div class="row mt-5">
          <div class="col">
            <b-form-group>
              <h4><b>帳號名稱</b></h4>
              <b-form-input
                v-model="user.email"
                type="email"
                required
                readonly
              ></b-form-input>
            </b-form-group>
          </div>
          <div class="col">
            <h4><b>暱稱</b></h4>
            <b-form-group>
              <div class="d-flex">
                <b-form-input
                  id="input-2"
                  v-model="user.name"
                  required
                  placeholder="Enter name"
                  :disabled="inputCanChange"
                ></b-form-input>
              </div>
            </b-form-group>
          </div>
          <div class="col">
            <h4><b>年齡</b></h4>
            <b-form-group>
              <div class="d-flex">
                <b-form-input
                  type="number"
                  min="1"
                  v-model="user.age"
                  required
                  :disabled="inputCanChange"
                ></b-form-input>
              </div>
            </b-form-group>
          </div>
        </div>
        <div class="row mt-5">
          <div class="col">
            <h4><b>性別</b></h4>
            <b-form-group>
              <select
                style="
                  width: 51%;
                  height: 38px;
                  border-radius: 5px;
                  background-color: #ddd;
                "
                @change="getOptionIdx($event, $event.target.selectedIndex)"
                :disabled="inputCanChange"
              >
                <option disabled selected>{{ user.gender }}</option>
                <option
                  v-for="(item, idx) in genderList"
                  :key="idx"
                  :id="genderList[idx]"
                >
                  {{ item }}
                </option>
              </select>
            </b-form-group>
          </div>
          <div class="col">
            <h4><b>電話</b></h4>
            <b-form-group>
              <div class="d-flex">
                <b-form-input
                  type="text"
                  v-model="user.phone"
                  required
                  :disabled="inputCanChange"
                ></b-form-input>
              </div>
            </b-form-group>
          </div>
          <div class="col">
            <h4><b>權限</b></h4>
            <b-form-group>
              <div class="d-flex">
                <b-form-input
                  type="text"
                  v-model="user.roleName"
                  readonly
                ></b-form-input>
              </div>
            </b-form-group>
          </div>
        </div>
        <h4 class="text-center my-5"><b>已經擁有的稱號</b></h4>
        <div class="d-flex justify-content-center mb-5">
          <div v-for="(item, idx) in hasRank" :key="idx" class="d-inline-block">
            <div v-if="item.titleName == user.ownerRank">
              <font-awesome-icon icon="crown" />
              <span class="badge badge-primary m-3 p-2">{{
                user.ownerRank
              }}</span>
            </div>
            <span
              class="badge badge-info m-3 p-2 ownerRank"
              v-text="otherRank(item.titleName)"
              @click="changeRank(item.titleName)"
            ></span>
          </div>
        </div>

        <div class="d-flex justify-content-center">
          <b-button pill variant="primary" @click="updateMember"
            >提交修改</b-button
          >
          <b-button
            pill
            variant="outline-secondary"
            class="ml-2"
            v-if="inputCanChange"
            @click="inputChange"
            >修改會員資料</b-button
          >
          <b-button v-else pill variant="info" class="ml-2" @click="inputChange"
            >完成修改</b-button
          >
        </div>
      </b-form>
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
      file: "",
      //////////////////////
      inputCanChange: true,
      user: {
        userId: "",
        email: "",
        password: "",
        name: "",
        age: "",
        phone: "",
        points: "",
        roleName: "",
        gender: "",
        ownerRank: "",
        imgLink: "",
      },
      updateData: {
        name: "",
        password: "",
        age: "",
        phone: "",
        gender: "",
        titleName: "",
        imgLink: "",
      },
      hasRank: [],
      show: true,
      selectGender: "",
      genderList: ["female", "male"],
      hasImg: false,
    };
  },
  methods: {
    handleFileUpload() {
      this.file = this.$refs.file.files[0];
      const CLIENT_ID = "3d78cf6e67ed6af";
      var formData = new FormData();
      formData.append("image", this.file);
      axios({
        url: "https://api.imgur.com/3/image",
        method: "POST",
        headers: {
          Authorization: "Client-ID " + CLIENT_ID,
        },
        data: formData,
      })
        .then((result) => {
          let url = result.data.data.link;
          this.user.imgLink = url;
          this.hasImg = true;
        })
        .catch((err) => {
          console.log(err);
        });
    },
    updateMember() {
      let vm = this;
      vm.updateData.name = vm.user.name;
      vm.updateData.password = vm.user.password;
      vm.updateData.age = vm.user.age;
      vm.updateData.phone = vm.user.phone;
      vm.updateData.gender = vm.user.gender;
      vm.updateData.titleName = vm.user.ownerRank;
      vm.updateData.imgLink = vm.user.imgLink;
      this.$axios
        .patch(
          process.env.VUE_APP_API + "/api/Users/UpdateMember",
          vm.updateData
        )
        .then(() => {
          vm.$router.go(0);
        })
        .catch((err) => {
          console.log(err);
        });
    },
    getOptionIdx: function (event, selectedIndex) {
      this.user.gender = event.target.querySelectorAll("option")[
        selectedIndex
      ].id;
    },
    inputChange() {
      return this.inputCanChange
        ? (this.inputCanChange = false)
        : (this.inputCanChange = true);
    },
    changeRank(rankName) {
      let vm = this;
      vm.user.ownerRank = rankName;
    },
    otherRank(rankName) {
      if (rankName !== this.user.ownerRank) {
        return rankName;
      }
    },
    getSingleMember() {
      let vm = this;
      let auth = vm.$store.state.tokenModule;
      let isAuth = auth.isAuthorize;
      let token = auth.token;
      const url = process.env.VUE_APP_API + "/api/Users/GetSingleMember";
      if (isAuth) {
        vm.$axios({
          url: url,
          method: "GET",
          headers: { Authorization: `Bearer ${token}` },
        })
          .then((res) => {
            vm.user.email = res.data.data.email;
            vm.user.name = res.data.data.name;
            vm.user.userId = res.data.data.userId;
            vm.user.ownerRank = res.data.data.titleName;
            vm.user.age = res.data.data.age;
            vm.user.gender = res.data.data.gender;
            vm.user.phone = res.data.data.phone;
            vm.user.points = res.data.data.points;
            vm.user.roleName = res.data.data.roleName;
            vm.user.imgLink = res.data.data.imgLink;
            vm.user.password = res.data.data.password;

            this.getHasRank();
          })

          .catch((err) => {
            console.log(err);
          });
      }
    },
    getHasRank() {
      let vm = this;
      const getHasRank = process.env.VUE_APP_API + "/api/Title/GetHasTitles";
      vm.$axios({
        url: getHasRank + "/" + vm.user.userId,
        method: "GET",
      })
        .then((resHasRank) => {
          resHasRank.data.forEach((element) => {
            vm.hasRank.push(element);
          });
        })
        .catch((err) => console.log(err.response));
    },
  },
  async created() {
    await this.getSingleMember();
  },
};
</script>

<style lang="scss" scoped>
input {
  width: 80%;
}
.ownerRank {
  cursor: pointer;
}
</style>