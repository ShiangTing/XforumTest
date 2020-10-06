<template>
  <b-list-group>
    <b-list-group-item
      v-for="(thread, index) in threads"
      :key="index"
      @click="doSomethingSpecial(thread)"
    >
      <font-awesome-icon :icon="thread.iconName" size="lg" />
      <router-link :to="`/${thread.routeName}`">{{ thread.name }}</router-link>
    </b-list-group-item>
  </b-list-group>
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
          routeName: "Adventure",
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
  beforeRouteUpdate() {},
  methods: {
    showAlert(msg) {
      console.log(msg);
    },

    doSomethingSpecial(event) {
      setTimeout(() => {
        console.log(event);
        // emit the event and pass with it an object of "event data".
        this.$bus.$emit(
          "specialEvent",
          event
          // routeName: event.routeName,
        );
      }, 100);
    },
  },
};
</script>

<style>
</style>