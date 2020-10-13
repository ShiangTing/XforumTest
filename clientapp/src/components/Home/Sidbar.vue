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
      // vm.dataId=id;
      // vm.$router.beforeEach((to, from, next) => {
      //     to.meta.forumId = id;
      //     next();
      // });
      // this.$bus.$emit("threadId", id);

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
    // doSomethingSpecial(event) {
    //   setTimeout(() => {
    //     console.log(event);
    //     // emit the event and pass with it an object of "event data".
    //     this.$bus.$emit(
    //       "specialEvent",
    //       event
    //       // routeName: event.routeName,
    //     );
    //   }, 100);
    // },
  },

  async created() {
    await this.getSideBar();
  },
};
</script>

<style></style>
