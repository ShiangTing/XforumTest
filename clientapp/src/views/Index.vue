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
              v-for="(article, index) in temp"
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
            <infinite-loading @infinite="infiniteHandler">
              <!-- <span slot="no-more"> 我們是有底線的 </span> -->
            </infinite-loading>
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
      page: 1,
      // list: [],

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
    // infiniteHandler($state) {
    //   setTimeout(() => {
    //     const temp = [];
    //     for (
    //       let i = this.articles.length + 1;
    //       i <= this.articles.length + 10;
    //       i++
    //     ) {
    //       temp.push(i);
    //     }
    //     this.articles = this.articles.concat(temp);
    //     $state.loaded();
    //     $state.complete();
    //   }, 1000);
    // },
    infiniteHandler($state) {
      // axios
      //   .get(api, {
      //     params: {
      //       page: this.page,
      //     },
      //   })
      //   .then(({ data }) => {
      if (this.articles.length > 10) {
        $state.complete();
      } else {
        setTimeout(() => {
          const temp = [];
          for (
            var i = this.articles.length;
            i <= this.articles.length + 10;
            i++
          ) {
            temp.push(this.articles[i]);
          }

          // this.articles.push(temp);
          $state.loaded();
        }, 1000);
      }
    },

    //   if (this.list.length < this.articles.length) {
    //     this.page += 1;
    //     this.list.push(...this.articles);
    //     $state.loaded();
    //   } else {
    //     $state.complete();
    //   }
    //   // });
    // },
  },
  computed: {},
  //   mounted:{
  // data.articles.forEach(element => element.content.length>20)
  //   if () {

  //   }
  // }
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
