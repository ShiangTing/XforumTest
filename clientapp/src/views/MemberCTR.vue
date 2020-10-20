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
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-2" label="Your Name:" label-for="input-2">
          <b-form-input
            id="input-2"
            v-model="user.name"
            required
            placeholder="Enter name"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-3" label="Food:" label-for="input-3">
          <b-form-select
            id="input-3"
            v-model="user.food"
            :options="foods"
            required
          ></b-form-select>
        </b-form-group>

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
      user: {
        email: "",
        name: "",
        age: "",
        phone: "",
        points: "",
        roleName: "",
        gender: "",
        food: null,
        checked: [],
      },
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

<style>
</style>