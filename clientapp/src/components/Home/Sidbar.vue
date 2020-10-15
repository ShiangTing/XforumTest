<template>
  <b-list-group>
    <b-list-group-item
      v-for="(thread, index) in threads"
      :key="index"
      :forumId="thread.forumId"
      @click="goToThread(thread.routeName)"
    >
      <!-- <font-awesome-icon :icon="thread.iconName" size="lg" /> -->
      <span
        class=""
        style="cursor: pointer; color: rgba(150, 155, 5, 0.8)"
        :forumid="thread.forumid"
      >
        {{ thread.forumName }}</span
      >
    </b-list-group-item>
  </b-list-group>
</template>

<script>
// import axios from "axios";
export default {
  data() {
    return {
      threads: [],
      // dataId:"",
    };
  },
  beforeRouteUpdate() {},
  methods: {
    goToThread(name) {
      const vm = this;
      vm.$router.push(`/Thread/${name}`);
    },

    async getSideBar() {
      const url = process.env.VUE_APP_API + "/api/Forum/GetAll";
      await this.$axios
        .get(url)
        .then((response) => {
          response.data.forEach((item) => {
            this.threads.push(item);
          });
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },

  async created() {
    await this.getSideBar();
  },
};
</script>

<style></style>
