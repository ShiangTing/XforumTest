<template>
  <div>
    <b-container fluid>
      <b-row class="">
        <b-col>
          <b-list-group style="max-width: 250px">
            <b-list-group-item v-for="(thread, index) in threads" :key="index">
              <font-awesome-icon :icon="thread.iconName" size="lg" />
              <router-link :to="`/${thread.routeName}`">{{
                thread.name
              }}</router-link>
            </b-list-group-item>
          </b-list-group>
        </b-col>
        <b-col cols="8">
          <div>
            <router-view />

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
        </b-col>
        <b-col> </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import detectiveImg from "../assets/img/detective.png";
import InfiniteLoading from "vue-infinite-loading";
// import axios from "axios";
// const api = "http://hn.algolia.com/api/v1/items/:id";
export default {
  components: {
    InfiniteLoading,
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

      threads: [
        {
          iconName: "coffee",
          // img: img1,
          name: "心情閒聊區",
          routeName: "SecretGarden",
        },
        {
          // img: img2,
          iconName: "angry",
          name: "新書怒灌區",
          routeName: "Talk",
        },
        {
          // img: img3,
          iconName: "ghost",
          name: "推理懸疑區",
          routeName: "Detective",
        },
        {
          // img: img3,
          iconName: "book-dead",
          name: "奇幻冒險區",
          routeName: "Adventure.",
        },
        {
          // img: img3,
          iconName: "user-graduate",
          name: "人物傳記區",
          routeName: "Biography",
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
