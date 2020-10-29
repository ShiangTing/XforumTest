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

            <b-card-img
              v-if="ImgLink !== ''"
              class="threadLogo"
              :src="ImgLink"
              width="50"
              height="350"
            ></b-card-img>
            <h1
              v-text="welcomeText(forumName)"
              class="text-center py-2"
              style="color: gray; font-weight: border"
            ></h1>
            <div
              class="infinite-scroll"
              v-infinite-scroll="loadMoreData"
              infinite-scroll-disabled="busy"
              infinite-scroll-distance="15"
            >
              <div
                class="post-section"
                v-for="(article, $index) in infiniteArticles"
                :key="$index"
                @click="goToArticle(article.postId)"
              >
                <div
                  style="padding: 10px 20px"
                  class="d-flex justify-content-between align-items-center w-100"
                >
                  <div>
                    <font-awesome-icon icon="user" size="lg" />
                    <div class="user">
                      <span class="userName">{{ article.userName }}</span>
                      <span
                        class="badge badge-secondary px-1 py-2 text-dark border"
                        :style="{
                          'background-color': article.rankColor,
                        }"
                        ><b> 『{{ article.rank }}』</b></span
                      >
                    </div>

                    <p
                      v-text="createDate(article.createdDate)"
                      class="pt-2"
                    ></p>
                    <h6>{{ article.title }}</h6>
                    <div
                      style="width: 300px"
                      v-html="filterDescription(article.description)"
                    ></div>
                  </div>
                  <div
                    class="previewImg d-flex"
                    v-html="getFirstImg(article.description)"
                  ></div>
                </div>
              </div>
              <div
                class="d-flex justify-content-center mt-3"
                v-if="infiniteArticles.length !== articles.length"
              >
                <span class="mr-5 text-primary">載入中請稍等哦!!</span>
                <b-spinner label="Loading..."></b-spinner>
              </div>
              <!-- <div v-else class="text-center mt-3 text-primary">載入完畢!!</div> -->
            </div>
          </div></b-col
        >
        <b-col>
          <ChatBlock></ChatBlock>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import Sidebar from "../components/Home/Sidbar";
import ChatBlock from "../components/common/Chat"

export default {
  components: {
    Sidebar,
    ChatBlock
  },
  data() {
    return {
      page: 1,
      list: [],
      count: 0, //要推入的資料筆數
      infiniteArticles: [], //inifinite scroll渲染的部分
      busy: false, //true觸發載入，false停止載入
      articles: [], //全部的資料
      routeName: this.$route.params.routeName,
      forumName: "",
      ImgLink: "",
    };
  },
  methods: {
    welcomeText(name) {
      return `${name}`;
    },
    createDate(date) {
      return date.substring(0, 10).replace(/-/g, "/");
    },
    filterDescription(description) {
      let span = document.createElement("span");
      span.innerHTML = description;
      // 刪img
      let imgTag = span.getElementsByTagName("img"),
        index;
      for (index = imgTag.length - 1; index >= 0; index--) {
        imgTag[index].parentNode.removeChild(imgTag[index]);
      }
      // 第一個p
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
    getFirstImg(data) {
      let span = document.createElement("span");
      span.innerHTML = data;
      let imgTag = span.querySelector("img");
      if (imgTag != null) {
        return imgTag.outerHTML;
      } else {
        return `<img src="https://i.imgur.com/Ix6074X.png">`;
      }
    },
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
        .get(url + "/" + this.$route.params.routeName)
        .then((response) => {
          response.data.reverse().forEach((item) => {
            this.forumName = item.forumName;

            this.articles.push(item);
          });
        })
        .catch((err) => {
          console.log(err);
        });
    },
    getThreadImg() {
      const url = process.env.VUE_APP_API + "/api/Forum/GetImgLink";

      this.$axios
        .get(url + "?id=" + this.$route.params.routeName)
        .then((response) => {
          this.ImgLink = response.data;
        })
        .catch((err) => {
          console.log(err);
        });
    },
    goToArticle(id) {
      let vm = this;
      vm.$router.push(`/article/${id}`);
    },
  },
  watch: {},
  beforeDestroy() {},
  async created() {
    await this.getThreadData();
    await this.getThreadImg();
  },
};
</script>

<style lang="scss" scoped>
$description: rgba(0, 0, 0, 1) !important;

.post-section {
  border-bottom: 1px solid rgba($color: gray, $alpha: 0.2);
  display: flex;
  .user {
    display: inline-block;
    padding-left: 5px;
    color: rgba($color: #000000, $alpha: 0.5);
    font-size: 16px;
    .userName {
      &::after {
        content: "・";
        padding: 0 5px;
      }
    }
  }

  h6 {
    color: #000;
    font-size: 18px;
    font-weight: bold;
  }
}
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
/deep/ .previewImg {
  width: 100px;
  height: 100px;
  img {
    height: 100%;
    width: 100%;
  }
}

.ellipsis {
  max-width: 20%;
  overflow: hidden;
  /* word-wrap: break-word; */
  text-overflow: ellipsis;
  white-space: nowrap;
  display: inline-block;
  color: #000;
}
.threadLogo {
  object-fit: fill;
}
@media screen and (max-width: 996px) {
  .sidebar {
    display: none;
  }
}
</style>


