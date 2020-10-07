<template>
  <div>
    <b-container fluid>
      <b-row>
        <b-col> <SideBar class="sidebar"/></b-col>
        <b-col cols="8">
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
            <p style="border-bottom: 1px solid gray; padding: 10px 0">
              全部 / 追蹤
            </p>
            <!-- <div v-for="article in articles" :key="article.id"> -->
            <div
              style="border-bottom: 1px solid gray; display: flex"
              v-for="(article, index) in titles"
              :key="index"
            >
              <div style="padding: 30px 20px">
                <font-awesome-icon icon="user" size="lg" />
                <span class="pl-4">{{ article.userName }}</span>
                <h5 class="py-3">{{ article.threadName }}</h5>
                <h5>{{ article.title }}</h5>
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

    <!-- <b-row>
      <b-col> <SideBar /></b-col>
      <b-col cols="8">

      </b-col>
      <b-col> </b-col>
    </b-row> -->
  </div>
</template>

<script>
import detectiveImg from "../assets/img/detective.png";
import InfiniteLoading from "vue-infinite-loading";
import SideBar from "../components/Home/Sidbar";
import axios from "axios";
// import axios from "axios";
// const api = "http://hn.algolia.com/api/v1/items/:id";
export default {
  components: {
    InfiniteLoading,
    SideBar,
  },
  data() {
    return {
      titles: [],
      page: 1,

      detective: detectiveImg,

      articles: [
        {
          userName: "Amy",
          threadName: "推理懸疑區",
          title: "標題1",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Eric",

          threadName: "心情閒聊區",
          title: "標題2",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "John",
          threadName: "推理懸疑區",
          title: "標題3",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",
          threadName: "心情閒聊區",
          title: "標題4",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",
          threadName: "心情閒聊區",
          title: "標題5",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",
          threadName: "心情閒聊區",
          title: "標題6",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",
          threadName: "心情閒聊區",
          title: "標題7",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",
          threadName: "心情閒聊區",
          title: "標題8",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",
          threadName: "心情閒聊區",
          title: "標題8",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",
          threadName: "心情閒聊區",
          title: "標題9",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",
          threadName: "心情閒聊區",
          title: "標題10",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",
          threadName: "心情閒聊區",
          title: "標題11",
          content:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit.Minus odit excepturi dicta blanditiis obcaecati dolores assumenda. Fugiat, unde quidem magnam quis, tempore sitmolestiae at esse, perferendis provident excepturi mollitia?",
        },
        {
          userName: "Allen",
          threadName: "心情閒聊區",
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

    GetAll() {
      const url = process.env.VUE_APP_API + "/api/Forum/GetAll";
      axios
        .get(url)
        .then((response) => {
          console.log(response);
          response.console.log("成功");
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
  created() {
    this.GetAll();
    this.fetchData();
  },
};
</script>

<style lang="scss">
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
