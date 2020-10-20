<template>
  <div>
    <Navbar />
    <div class="container">
      <b-form @submit="onSubmit" @reset="onReset" v-if="show">
        <b-form-group
          id="input-group-1"
          label="Email address:"
          label-for="input-1"
          description="We'll never share your email with anyone else."
        >
          <b-form-input
            id="input-1"
            v-model="user.email"
            type="email"
            required
            placeholder="Enter email"
            readonly
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-2" label="Your Name:" label-for="input-2">
          <div class="d-flex">
            <b-form-input
              id="input-2"
              v-model="user.name"
              required
              placeholder="Enter name"
              :disabled="inputCanChange"
            ></b-form-input>

            <b-button
              pill
              variant="outline-secondary"
              class="ml-2"
              v-if="inputCanChange"
              @click="inputChange"
              >修改</b-button
            >
            <b-button
              v-else
              pill
              variant="info"
              class="ml-2"
              @click="inputChange"
              >完成修改</b-button
            >
          </div>
        </b-form-group>
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

        <b-form-group id="input-group-4">
          <b-form-checkbox-group v-model="user.checked" id="checkboxes-4">
            <b-form-checkbox value="me">Check me out</b-form-checkbox>
            <b-form-checkbox value="that">Check that out</b-form-checkbox>
          </b-form-checkbox-group>
        </b-form-group>

        <b-button type="submit" variant="primary">Submit</b-button>
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
    };
  },
  methods: {
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
          console.log(resHasRank);
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
  width: 20%;
}
.ownerRank {
  cursor: pointer;
}
</style>