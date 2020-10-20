<template>
  <div>
    <Navbar />
    <div class="bg-secondary">
      <div class="container py-5">
        <div class="row justify-content-center">
          <div class="col-lg-9 col-12">
            <div class="card">
              <div class="card-body">
                <div class="row justify-content-between">
                  <div class="col-6 ">
                    <h3 class="card-title">{{article.title}}</h3>
                    <h6 class="card-subtitle mb-2 text-success">作者: {{article.author}}</h6>
                    <p class="card-date text-muted">
                      {{article.createDate.replace(/-/g, "/").replace("T"," ").replace(/\.\d+/, "")}}
                    </p>
                  </div>
                  <div class="col-3 d-flex justify-content-end align-items-center">
                    <a v-if="article.userId === reply.userId" href="javascript:;" class="title-btn rounded-circle">
                      <font-awesome-icon icon="pen" size="lg" />
                    </a>
                    <a v-if="article.userId === reply.userId" href="javascript:;" class="title-btn rounded-circle">
                      <font-awesome-icon icon="trash" size="lg" />
                    </a>
                  </div>
                </div>
                <hr>
                <div class="article-content">
                  <div v-html="article.description"></div>
                  <div class="col-6 d-flex align-items-center p-0">
                    <div class="mr-2 d-flex align-items-center">
                      <a href="javascript:;" class="rounded-circle"
                        :class="!templike.postlike ? 'title-btn' : 'btn-active'" @click.prevent="likeArticle">
                        <font-awesome-icon icon="thumbs-up" size="lg" />
                      </a>
                      <span class="text-secondary px-2">{{article.like}}</span>
                    </div>
                    <div class="mr-2 d-flex align-items-center">
                      <a href="javascript:;" class="rounded-circle"
                        :class="!templike.postdislike ? 'title-btn' : 'btn-active'" @click.prevent="dislikeArticle">
                        <font-awesome-icon icon="thumbs-down" size="lg" />
                      </a>
                      <span class="text-secondary px-2">{{article.dislike}}</span>
                    </div>
                  </div>
                </div>
              </div>
              <div class="reply-group border p-3">
                <div class="reply-item row justify-content-between" v-for="message in messageList"
                  :key="message.messageId">
                  <div class="col-12 col-md-10 d-flex">
                    <a class="user-img">
                      <font-awesome-icon icon="user" size="lg" />
                    </a>
                    <div class="reply-content">
                      <a class="replay-user mr-2 d-inline-block">{{message.userName}}</a>
                      <span
                        class="card-date text-muted">{{message.createdDate.replace(/-/g, "/").replace("T"," ").replace(/\.\d+/, "")}}</span>
                      <p>{{message.context}}</p>
                    </div>
                  </div>
                  <div class="col-12 col-md-2 d-flex align-items-center">
                    <a href="javascript:;" class="title-btn msg-btn border-0 rounded-circle m-1">
                      <font-awesome-icon icon="thumbs-up" size="sm" />
                    </a>
                    <span class="px-2">{{message.likeNumber}}</span>
                    <a href="javascript:;" class="title-btn msg-btn border-0 rounded-circle m-1">
                      <font-awesome-icon icon="thumbs-down" size="sm" />
                    </a>
                    <span class="px-2">{{message.disLikeNumber}}</span>
                  </div>
                </div>
                <div class="reply-item border-0">
                  <div class="input-group">
                    <a class="user-img text-secondary bg-white">
                      <font-awesome-icon icon="user" size="lg" />
                    </a>
                    <textarea class="form-control h-100" placeholder="留個言吧~" v-model="reply.context"></textarea>
                    <button class="btn btn-secondary h-100" @click.prevent="postMessage">送出</button>
                  </div>
                </div>
              </div>
            </div>

          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar"
export default {
  components: { Navbar },
  data () {
    return {
      article: {
        userId: "",
        title: "",
        author: "",
        createDate: "",
        like: 0,
        dislike: 0,
        edit: false,
        delete: false,
        description: ""
      },
      messageList: [],
      reply: {
        postId: "",
        context: "",
        userId: "",
      },
      templike: {
        postlike: false,
        postdislike: false,
      }
    };
  },
  methods: {
    getUserId () {
      let vm = this;
      let userIdUrl = process.env.VUE_APP_API + "/api/Users/getUserId";

      vm.$axios.get(userIdUrl).then(res => {
        vm.reply.userId = res.data
      }).catch(() => {
        alert("請先登入才能按讚加留言");
      })
    },
    getArticle () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/Post/getSingle/" + vm.$route.params.id;
      vm.$axios.get(url).then(res => {
        console.log("article", res.data);
        vm.article = {
          userId: res.data.userId,
          title: res.data.title,
          author: res.data.userName,
          createDate: res.data.createdDate,
          description: res.data.description,
          like: res.data.likeNumber,
          dislike: res.data.disLikeNumber,
        }
        vm.reply.postId = res.data.postId
      })
    },
    getMessages () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/RMessage/GetAllMessages/" + vm.$route.params.id;
      vm.$axios.get(url).then(res => {
        if (res.data.issuccessful) {
          vm.messageList = res.data.data;
        }
      })
    },
    postMessage () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/RMessage/CreateMessage";
      vm.$axios.post(url, vm.reply).then(res => {
        console.log(res);
        if (res.data.issuccessful) {
          vm.reply.context = ""
          vm.getMessages();
        }
      }).catch(() => {
        alert("請先登入再留言")
      })
    },
    likeArticle () {
      let vm = this;
      if (!vm.templike.postlike) {
        vm.templike.postlike = true;
        vm.article.like += 1;
      } else {
        vm.templike.postlike = false;
        vm.article.like -= 1;
      }
    },
    dislikeArticle () {
      let vm = this;
      if (!vm.templike.postdislike) {
        vm.templike.postdislike = true;
        vm.article.dislike += 1;
      } else {
        vm.templike.postdislike = false;
        vm.article.dislike -= 1;
      }
    },
    messagelike () {

    },
    messageunlike () {

    },
  },
  async created () {
    await this.getArticle()
    await this.getMessages()
    await this.getUserId()
    this.templike = {
      postlike: this.article.like,
      postdislike: this.article.dislike,
    }
  }
}
</script>
<style lang="scss" scoped>
  $border-color: 1px solid rgba(0, 0, 0, 0.125);
  .input-group {
    height: 35px;
  }
  p {
    margin: 0;
  }
  // card 設定
  .card {
    border: 1.5px solid #6c757d;
    &-title {
      font-weight: 700;
      letter-spacing: 5px;
    }
    &-date {
      font-size: 12px;
    }
  }
  /deep/ .article-content {
    min-height: 350px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    img {
      width: 100%;
    }
  }
  a.title-btn {
    display: flex;
    justify-content: center;
    align-items: center;
    color: #6c757d;
    width: 40px;
    height: 40px;
    border: $border-color;
  }

  .btn-active {
    display: flex;
    justify-content: center;
    align-items: center;
    color: #6c757d;
    width: 40px;
    height: 40px;
    border: 1px solid rgb(244, 156, 66);
    color: rgb(244, 156, 66);
  }
  a.msg-btn {
    width: 25px;
    height: 25px;
  }
  textarea.form-control {
    resize: none;
    border: $border-color;
    &:active,
    &:focus {
      border: $border-color;
      outline: $border-color;
      box-shadow: 0px 0px transparent;
    }
  }
  .reply-group {
    background-color: #f5f5f5;
  }
  .reply-item {
    padding: 10px;
    border-bottom: $border-color;
  }
  .user-img {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 40px;
    height: 40px;
    border-radius: 50%;
    border: 1px solid rgba(0, 0, 0, 0.125);
    margin-right: 10px;
  }
</style>