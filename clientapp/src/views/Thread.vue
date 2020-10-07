<template>
  <div>
    <b-container fluid>
      <b-row>
        <b-col cols="2"> <Sidebar class="sidebar"/></b-col>
        <b-col cols="7">
          <div>
            <!-- 這裡是index區域的貼文 -->
            <vue-particles
              color="#dedede"
              :particleOpacity="0.7"
              :particlesNumber="80"
              shapeType="circle"
              :particleSize="4"
              linesColor="#dedede"
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
            <!-- <div v-if="threadDetail.img && threadDetail.name">
              <b-card-img
                :src="require(`@/assets/img/${threadDetail.img}`)"
                width="50"
                height="350"
              ></b-card-img>
              <h2 style="color: wheat">{{ threadDetail.name }}</h2>
            </div> -->
            <p style="border-bottom: 1px solid gray; padding: 10px 0">
              全部 / 追蹤
            </p>

            <!-- <div v-for="article in articles" :key="article.id"> -->
            <div
              style="border-bottom: 1px solid gray; display: flex"
              v-for="(article, index) in titles"
              :key="index"
            >
              <div class="w-100" style="padding: 30px 20px">
                <font-awesome-icon icon="user" size="lg" />
                <span class="pl-4">{{ article.userName }}</span>
                <h3 class="pt-3">{{ article.title }}</h3>
                <p class="ellipsis">{{ article.content }}</p>
              </div>
            </div>
            <!-- </div> -->
            <infinite-loading
              v-if="titles.length"
              spinner="spiral"
              @infinite="infiniteScroll"
            ></infinite-loading></div
        ></b-col>
        <b-col></b-col>
      </b-row>
    </b-container>

    <!-- <div v-else>

    </div> -->

    <!-- <img
      :src="`@/assets/img/${threadDetail.img}`"
      width="50"
      height="50"
      alt="logo"
    /> -->
  </div>
</template>

<script>
import InfiniteLoading from "vue-infinite-loading";
import Sidebar from "../components/Home/Sidbar";
import axios from "axios";
export default {
  components: {
    InfiniteLoading,
    Sidebar,
  },
  data() {
    return {
      titles: [],
      page: 1,
      // threadDetail: { name: "", img: "" },
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
    getThreadData() {
      const url = process.env.VUE_APP_API + "/api/Forum/GetSingle";
      axios
        .get(url)
        .then((response) => {
          console.log(response);
          console.log("成功");
        })
        .catch((err) => {
          console.log(err);
        });
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
    this.getThreadData();
    // this.$bus.$on("specialEvent", (event) => {
    //   // alert(event.event.img);
    //   this.threadDetail.name = event.name;
    //   this.threadDetail.img = event.img;
    //   // this.threadDetail.routeName = event.routeName;
    // });
  },
  beforeDestroy: function() {
    // this.$bus.$off("specialEvent");
  },
  computed: {},
};
</script>

<style lang="scss" scoped>
.ellipsis {
  max-width: 20%;
  overflow: hidden;
  /* word-wrap: break-word; */
  text-overflow: ellipsis;
  white-space: nowrap;
  display: inline-block;
  color: #000;
}
@media screen and (max-width: 996px) {
  .sidebar {
    display: none;
  }
}
</style>
