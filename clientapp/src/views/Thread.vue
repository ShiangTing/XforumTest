<template>
  <div>
    <b-container fluid>
      <b-row>
        <b-col cols="2"> <Sidebar class="sidebar" /></b-col>
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

            <div
              class="infinite-scroll"
              v-infinite-scroll="loadMoreData"
              infinite-scroll-disabled="busy"
              infinite-scroll-distance="15"
            >
              <div
                style="border-bottom: 1px solid gray; display: flex"
                v-for="(article, $index) in infiniteArticles"
                :key="$index"
              >
                <!-- Hacker News item loop -->
                <div style="padding: 30px 20px">
                  <font-awesome-icon icon="user" size="lg" />
                  <span class="pl-4">{{ article.userName }}</span>
                  <h5 class="py-3" id="forumName">{{ article.forumName }}</h5>
                  <h5>{{ article.title }}</h5>
                  <div v-html="article.description"></div>
                  <!-- <div :id="'article' + index"></div> -->
                  <p>{{ article.createdDate }}</p>
                </div>
              </div>
              <!-- //此處為自訂的loading icon，並設定當只有在兩個陣列長度不相等時才會顯示 -->
              <div
                class="d-flex justify-content-center mt-3"
                v-if="infiniteArticles.length !== articles.length"
              >
                <span class="mr-5 text-primary">載入中請稍等哦!!</span>
                <b-spinner label="Loading..."></b-spinner>
              </div>
              <div v-else class="text-center mt-3 text-primary">載入完畢!!</div>
            </div>

            <!-- <div v-for="article in articles" :key="article.id"> -->
            <!-- <div
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
            </div> -->
            <!-- </div> -->
          </div></b-col
        >
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
import Sidebar from "../components/Home/Sidbar";

export default {
  components: {
    Sidebar,
  },
  data() {
    return {
      page: 1,
      list: [],
      count: 0, //要推入的資料筆數
      infiniteArticles: [], //inifinite scroll渲染的部分
      busy: false, //true觸發載入，false停止載入
      articles: [], //全部的資料

      /////////////////

      // articles: [
      //   {
      //     userName: "Amy",

      //     title: "標題1",
      //     content:
      //       "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
      //   },
      //   {
      //     userName: "Eric",

      //     title: "標題2",
      //     content:
      //       "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
      //   },
      //   {
      //     userName: "John",

      //     title: "標題3",
      //     content:
      //       "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
      //   },
      //   {
      //     userName: "Allen",

      //     title: "標題4",
      //     content:
      //       "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
      //   },
      //   {
      //     userName: "Allen",

      //     title: "標題5",
      //     content:
      //       "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
      //   },
      //   {
      //     userName: "Allen",

      //     title: "標題6",
      //     content:
      //       "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
      //   },
      //   {
      //     userName: "Allen",

      //     title: "標題7",
      //     content:
      //       "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
      //   },
      //   {
      //     userName: "Allen",

      //     title: "標題8",
      //     content:
      //       "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
      //   },
      //   {
      //     userName: "Allen",

      //     title: "標題8",
      //     content:
      //       "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
      //   },
      //   {
      //     userName: "Allen",

      //     title: "標題9",
      //     content:
      //       "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
      //   },
      //   {
      //     userName: "Allen",

      //     title: "標題10",
      //     content:
      //       "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
      //   },
      //   {
      //     userName: "Allen",

      //     title: "標題11",
      //     content:
      //       "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
      //   },
      //   {
      //     userName: "Allen",

      //     title: "標題12",
      //     content:
      //       "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
      //   },
      // ],
    };
  },
  methods: {
    loadMoreData: function () {
      if (this.infiniteArticles.length <= this.articles.length) {
        this.busy = true;
        setTimeout(() => {
          for (var i = 0, j = 5; i < j; i++) {
            if (this.count === this.articles.length) {
              break;
            }
            this.infiniteArticles.push(this.articles[this.count++]);
          }
          this.busy = false;
        }, 1000);
      }
    },
    getThreadData() {
      const url = process.env.VUE_APP_API + "/api/Post/GetForum";
      this.$axios
        .get(url)
        .then((response) => {
          console.log(response);
          console.log(response.data);
          response.data.forEach((item) => {
            console.log(item);
            this.articles.push(item);
          });
        })
        .catch((err) => {
          console.log(err);
        });
    },

    ///////////////////////
    // getThreadData() {
    //   const url = process.env.VUE_APP_API + "/api/Post/GetForum";
    //   axios
    //     .get(url)
    //     .then((response) => {
    //       console.log(response);
    //       console.log("成功");
    //     })
    //     .catch((err) => {
    //       console.log(err);
    //     });
    // },
    // infiniteScroll($state) {
    //   setTimeout(() => {
    //     this.page++;
    //     if (this.articles.length > 10) {
    //       this.articles.forEach((item) => this.titles.push(item));
    //       $state.loaded();
    //     } else {
    //       $state.complete();
    //     }
    //   }, 500);
    // },
  },

  async created() {
    await this.getThreadData();
    // this.$bus.$on("specialEvent", (event) => {
    //   // alert(event.event.img);
    //   this.threadDetail.name = event.name;
    //   this.threadDetail.img = event.img;
    //   // this.threadDetail.routeName = event.routeName;
    // });
  },
  beforeDestroy: function () {
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


