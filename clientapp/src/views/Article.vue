<template>
  <div>
    <Navbar />
    <div class="container py-5">
      <div class="row justify-content-center">
        <div class="col-9">
          <div class="card">
            <div class="card-body">
              <div class="row">
                <div class="col-6">
                  <h3 class="card-title">{{article.title}}</h3>
                  <h6 class="card-subtitle mb-2 text-muted">作者: {{article.author}}</h6>
                  <p>日期: {{article.createDate}}</p>
                </div>
                <div class="col-6 d-flex justify-content-end align-items-center">
                  <a class="title-btn text-secondary border rounded-circle">
                    <font-awesome-icon icon="thumbs-up" size="lg" />
                  </a>
                  <a class="title-btn text-secondary border rounded-circle">
                    <font-awesome-icon icon="thumbs-down" size="lg" />
                  </a>
                  <a class="title-btn text-secondary border rounded-circle">
                    <font-awesome-icon icon="pen" size="lg" />
                  </a>
                  <a class="title-btn text-secondary border rounded-circle">
                    <font-awesome-icon icon="trash" size="lg" />
                  </a>
                </div>
              </div>
              <hr>
              <div class="article-content">
                <div v-html="article.description"></div>
              </div>
            </div>
          </div>
          <div class="reply-group border p-3">
            <div class="reply-item d-flex justify-content-between" v-for="message in messageList"
              :key="message.messageId">
              <div class="d-flex">
                <a class="user-img">
                  <font-awesome-icon icon="user" size="lg" />
                </a>
                <div class="reply-content">
                  <a class="replay-user mr-2 d-inline-block">{{message.userName}}</a>
                  <span>{{message.createdDate}}</span>
                  <p>{{message.context}}</p>
                </div>
              </div>
              <div class="d-flex">
                <p class="mr-2">Like : {{message.disLikeNumber === null ? 0 : message.disLikeNumber}}</p>
                <p>Unlike : {{message.disLikeNumber === null ? 0 : message.disLikeNumber }}</p>
              </div>
            </div>
            <div class="p-3">
              <div class="input-group">
                <a class="user-img">
                  <font-awesome-icon icon="user" size="lg" />
                </a>
                <textarea class="form-control h-100" placeholder="留個言吧~"></textarea>
                <button class="btn btn-dark h-100">送出</button>
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
        title: "",
        author: "",
        createDate: "",
        like: 0,
        unlike: 0,
        edit: false,
        delete: false,
        description: ""
      },
      messageList: [],
    };
  },
  methods: {
    getArticle () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/Post/getSingle/" + vm.$route.params.id;
      vm.$axios.get(url).then(res => {
        vm.article = {
          title: res.data.title,
          author: res.data.userName,
          createDate: res.data.createdDate,
          description: res.data.description,
          like: 0,
          unlike: 0,
        }
      })
    },
    getMessages () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/RMessage/GetAllMessages/" + "B2160343-1272-45AE-980D-B1E3BBDCB969";
      vm.$axios.get(url).then(res => {
        if (res.data.issuccessful) {
          vm.messageList = res.data.data;
        }
      })
    },
  },
  created () {
    this.getArticle()
    this.getMessages()
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
  /deep/ .article-content img {
    width: 100% ;
  }
  a.title-btn {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 40px;
    height: 40px;
    border: $border-color;
    margin-right: 5px;
    &:hover,
    &:active,
    &:focus {
      border: 1px solid red;
    }
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