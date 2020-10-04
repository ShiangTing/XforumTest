<template>
  <div>
    <b-list-group style="max-width: 250px">
      <b-list-group-item
        v-for="(thread, index) in threads"
        :key="index"
        @click="doSomethingSpecial(thread)"
      >
        <font-awesome-icon :icon="thread.iconName" size="lg" />
        <router-link :to="`/${thread.routeName}`">{{
          thread.name
        }}</router-link>
      </b-list-group-item>
    </b-list-group>
    <!-- <button @click="doSomethingSpecial()">doShowAlerts</button> -->
  </div>
</template>

<script>
export default {
  data() {
    return {
      threads: [
        {
          iconName: "coffee",
          img: "talkking.jpg",
          name: "心情閒聊區",
          routeName: "SecretGarden",
        },
        {
          img: "angry.jpg",
          iconName: "angry",
          name: "新書怒灌區",
          routeName: "Talk",
        },
        {
          img: "detective.png",
          iconName: "ghost",
          name: "推理懸疑區",
          routeName: "Detective",
        },
        {
          img: "adventure.jpg",
          iconName: "book-dead",
          name: "奇幻冒險區",
          routeName: "Adventure.",
        },
        {
          img: "biography.jpg",
          iconName: "user-graduate",
          name: "人物傳記區",
          routeName: "Biography",
        },
        {
          img: "programming.jpg",
          iconName: "user-graduate",
          name: "程式討論區",
          routeName: "Programming",
        },
      ],
    };
  },
  methods: {
    showAlert(msg) {
      console.log(msg);
    },
    doSomethingSpecial(event) {
      console.log(event);
      // emit the event and pass with it an object of "event data".
      this.$bus.$emit("specialEvent", {
        event,
        // routeName: event.routeName,
      });
    },
  },
  //   created() {
  //     this.$bus.$on("alert:message", (msg) => {
  //       // 並將接收到的 message 傳給自己的 methods showAlert 去觸發 alert 事件。
  //       this.showAlert(msg);
  //     });
  //   },
  //   beforedestory: function () {
  //     this.$bus.$off("alert:message");
  //   },
};
</script>

<style>
</style>