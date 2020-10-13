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
                  <div
                    style="width: 300px"
                    v-html="
                      $options.filters.filterDescription(article.description)
                    "
                  ></div>
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
          </div>
        </b-col>
        <b-col></b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
export default {
  components: {
    // InfiniteLoading,
    // SideBar,
    Sidebar: () => import("@/components/Home/Sidbar"),
  },
  data() {
    return {
      page: 1,
      list: [],
      count: 0, //要推入的資料筆數
      infiniteArticles: [], //inifinite scroll渲染的部分
      busy: false, //true觸發載入，false停止載入
      articles: [], //全部的資料
      htmlData: [],
      descriptionFirstImg: "",
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
    async GetAll() {
      const url = process.env.VUE_APP_API + "/api/Post/GetAllPosts";
      await this.$axios
        .get(url)
        .then((response) => {
          response.data.forEach((item) => {
            this.articles.push(item);
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
  filters: {
    filterDescription(description) {
      let span = document.createElement("span");
      span.innerHTML = description;

      let imgTag = span.getElementsByTagName("img"),
        index;
      if (imgTag !== null) {
        this.descriptionFirstImg = imgTag[0];
        for (index = imgTag.length - 1; index >= 0; index--) {
          imgTag[index].parentNode.removeChild(imgTag[index]);
        }
      }

      let pTagGroup = span.getElementsByTagName("p");
      for (index = pTagGroup.length - 1; index >= 0; index--) {
        if (index !== 0) {
          pTagGroup[index].parentNode.removeChild(pTagGroup[index]);
        } else {
          pTagGroup[index].classList.add("ellipsis");
        }
      }
      return span.innerHTML;
    },
  },
  async created() {
    await this.GetAll();
  },
};
</script>

<style lang="scss" scoped>
$description: rgba(0, 0, 0, 1) !important;
/deep/ .ellipsis {
  width: 100%;
  font-size: 14px;
  color: $description;
  overflow: hidden;
  /* word-wrap: break-word; */
  text-overflow: ellipsis;
  white-space: nowrap;
  display: inline-block;
  & > * {
    color: $description;
  }
}
@media screen and (max-width: 996px) {
  .sidebar {
    display: none;
  }
}

#forumName {
  color: wheat;
  font-weight: 900;
  font-size: 20px;
}
</style>
