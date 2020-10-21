<template>
  <div>
    <Navbar />
    <div class="container">
      <b-form @submit="onSubmit" @reset="onReset" v-if="show">
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
              <!-- <div class="d-flex">
                <b-form-input
                  v-model="user.age"
                  required
                  :disabled="inputCanChange"
                ></b-form-input>
              </div> -->
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
            <h4><b>性別</b></h4>
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
        <h4><b>已經擁有的稱號</b></h4>
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

        <div></div>

        <!-- <b-form-group id="input-group-4">
          <b-form-checkbox-group v-model="user.checked" id="checkboxes-4">
            <b-form-checkbox value="me"></b-form-checkbox>
            <b-form-checkbox value="that"></b-form-checkbox>
          </b-form-checkbox-group>
        </b-form-group> -->

        <b-button type="submit" variant="primary">Submit</b-button>
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
        <b-button type="reset" variant="danger">Reset</b-button>
      </b-form>
      <b-card class="mt-3" header="Form Data Result">
        <pre class="m-0">{{ user }}</pre>
      </b-card>
    </div>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar";
export default {
  components: { Navbar },
  data() {
    return {
      inputCanChange: true,
      user: {
        userId: "",
        email: "",
        name: "",
        age: "",
        phone: "",
        points: "",
        roleName: "",
        gender: "",
        ownerRank: "",
        checked: [],
      },
      hasRank: [],
      foods: [
        { text: "Select One", value: null },
        "Carrots",
        "Beans",
        "Tomatoes",
        "Corn",
      ],
      show: true,
      selectGender: "",
      genderList: ["female", "male"],
    };
  },
  methods: {
    getOptionIdx: function (event, selectedIndex) {
      console.log(event);
      this.user.gender = event.target.querySelectorAll("option")[
        selectedIndex
      ].id;
      // this.selectGender = event.target.querySelectorAll("option")[
      //   selectedIndex
      // ].id;
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
    onSubmit(evt) {
      evt.preventDefault();
      alert(JSON.stringify(this.form));
    },
    onReset(evt) {
      evt.preventDefault();
      // Reset our form values

      this.user.email = "";
      this.user.name = "";
      this.user.food = null;
      this.user.checked = [];
      // Trick to reset/clear native browser form validation state
      this.show = false;
      this.$nextTick(() => {
        this.show = true;
      });
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
            console.log(res.data.data);
            vm.user.email = res.data.data.email;
            vm.user.name = res.data.data.name;
            vm.user.userId = res.data.data.userId;
            vm.user.ownerRank = res.data.data.titleName;
            vm.user.age = res.data.data.age;
            vm.user.gender = res.data.data.gender;
            vm.user.phone = res.data.data.phone;
            vm.user.points = res.data.data.points;
            vm.user.roleName = res.data.data.roleName;

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