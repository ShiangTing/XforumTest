<template>
  <div>
    <b-card
      overlay
      img-src="https://picsum.photos/900/250/?image=3"
      img-alt="Card Image"
      text-variant="white"
      :title="$route.params.routeName"
    >
      <b-card-text></b-card-text>
    </b-card>
    <vue-particles
      color="#dedede"
      :particleOpacity="0.7"
      :particlesNumber="80"
      shapeType="circle"
      :particleSize="4"
      linesColor="#fa0"
      :linesWidth="1"
      :lineLinked="true"
      :lineOpacity="0.4"
      :linesDistance="150"
      :moveSpeed="5"
      :hoverEffect="false"
      hoverMode="grab"
      :clickEffect="false"
      clickMode="push"
    >
    </vue-particles>
    <p style="border-bottom: 1px solid gray; padding: 10px 0">全部 / 追蹤</p>
    <!-- <div v-for="article in articles" :key="article.id"> -->
    <div
      style="border-bottom: 1px solid gray; display: flex"
      v-for="(article, index) in titles"
      :key="index"
    >
      <div style="padding: 30px 20px">
        <font-awesome-icon icon="user" size="lg" />
        <span class="pl-4">{{ article.userName }}</span>
        <h5 class="pt-3">{{ article.title }}</h5>
        <p id="KKKK">{{ article.content }}</p>
      </div>
    </div>
    <!-- </div> -->
    <infinite-loading
      v-if="titles.length"
      spinner="spiral"
      @infinite="infiniteScroll"
    ></infinite-loading>
  </div>
</template>

<script>
import InfiniteLoading from "vue-infinite-loading";
export default {
  components: {
    InfiniteLoading,
  },
  data() {
    return {
      titles: [],
      page: 1,
      articles: [
        {
          userName: "Amy",

          title: "標題1",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Eric",

          title: "標題2",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "John",

          title: "標題3",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",

          title: "標題4",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",

          title: "標題5",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",

          title: "標題6",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",

          title: "標題7",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",

          title: "標題8",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",

          title: "標題8",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",

          title: "標題9",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",

          title: "標題10",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",

          title: "標題11",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",

          title: "標題12",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
      ],
    };
  },
  methods: {
    //  async fetchData() {
    //       const response = await axios.get(this.url);
    //       this.titles = response.data;
    //     },
    async fetchData() {
      // const response = await axios.get(this.url);
      this.titles = this.articles;
    },
    infiniteScroll($state) {
      setTimeout(() => {
        this.page++;
        if (this.articles.length > 10) {
          this.articles.forEach((item) => this.titles.push(item));
          $state.loaded();
        } else {
          $state.complete();
        }

        // axios
        //   .get(this.url)
        //   .then((response) => {
        //     if (response.data.length > 1) {
        //       response.data.forEach((item) => this.titles.push(item));
        //       $state.loaded();
        //     } else {
        //       $state.complete();
        //     }
        //   })
        //   .catch((err) => {
        //     console.log(err);
        //   });
      }, 500);
    },
  },
  created() {
    this.fetchData();
  },
  computed: {},
};
</script>

<style lang="scss">
#KKKK {
  width: 20%;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
  display: inline-block;
  color: #000;
}
</style>