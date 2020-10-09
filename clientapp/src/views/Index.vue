<template>
  <div>
    <b-container fluid>
      <b-row>
        <b-col> <Sidebar class="sidebar" /></b-col>
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
                <div :id="'article' + index"></div>
                <p>{{ article.createdDate }}</p>
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
// import axios from "axios";
// const api = "http://hn.algolia.com/api/v1/items/:id";

export default {
  components: {
    InfiniteLoading,
    // SideBar,
    Sidebar: () => import("@/components/Home/Sidbar"),
  },
  data() {
    return {
      titles: [],
      page: 1,

      detective: detectiveImg,

      articles: [],
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
      const url = process.env.VUE_APP_API + "/api/Post/GetAllPosts";
      this.$axios
        .get(url)
        .then((response) => {
          console.log(response);
          console.log("成功");

          response.data.forEach((item) => {
            console.log(item);
            this.articles.push(item);
          });
          this.$nextTick(() => {
            this.articles.forEach((item, index) => {
              console.log("article" + index);
              let temp = document.getElementById("article" + index);
              console.log(temp);
              temp.innerHTML = item.description;
            });
          });
        })
        .catch((err) => {
          console.log(err);
        });
    },
    // GetArticleAndSideBar() {
    //   let vm = this;

    //   axios.all([vm.getSideBar(), vm.GetAll()]).then(
    //     axios.spread((SidebarResponse, ArticleResponse) => {
    //       SidebarResponse.data.forEach((item) => {
    //         console.log(item);
    //       });
    //       ArticleResponse.data.forEach((item) => {
    //         console.log(item);
    //         vm.articles.push(item);
    //       });
    //       vm.$nextTick(() => {
    //         vm.articles.forEach((item, index) => {
    //           console.log("article" + index);
    //           let temp = document.getElementById("article" + index);
    //           console.log(temp);
    //           temp.innerHTML = item.description;
    //         });
    //       });
    //     })
    //   );
    // },
    // GetAll() {
    //   const url = process.env.VUE_APP_API + "/api/Post/GetAllPosts";
    //   return axios.get(url);
    //   //  this.first_request: 'first request began'
    // },
    // getSideBar() {
    //   const url = process.env.VUE_APP_API + "/api/Forum/GetAll";
    //   return axios.get(url);
    // },
  },
  async created() {
    // await this.GetArticleAndSideBar();
    await this.GetAll();
    await this.fetchData();
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
