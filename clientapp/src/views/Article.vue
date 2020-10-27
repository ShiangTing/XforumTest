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
                    <h6 class="card-subtitle mb-2 text-success">作者: {{article.userName}}</h6>
                    <p class="card-date text-muted">
                      {{article.createDate.replace(/-/g, "/").replace("T"," ").replace(/\.\d+/, "")}}
                    </p>
                  </div>
                  <div class="col-3 d-flex justify-content-end align-items-center">
                    <a v-if="article.userId === reply.userId" class="title-btn rounded-circle"
                      @click="$bvModal.show('edit'); saveOrginArticle();">
                      <font-awesome-icon icon="pen" size="lg" />
                    </a>
                    <a v-if="article.userId === reply.userId" class="title-btn rounded-circle" @click="deleteArticle">
                      <font-awesome-icon icon="trash" size="lg" />
                    </a>
                  </div>
                </div>
                <hr>
                <div class="article-content">
                  <div v-html="article.description"></div>
                  <div class="col-6 d-flex align-items-center p-0">
                    <div class="mr-2 d-flex align-items-center">
                      <a href="javascript:;" class="rounded-circle title-btn"
                        :class="!templike.articleLike ? '' : 'active'" @click.prevent="likeArticle">
                        <font-awesome-icon icon="thumbs-up" size="lg" />
                      </a>
                      <span class="text-secondary px-2">{{article.like}}</span>
                    </div>
                    <div class="mr-2 d-flex align-items-center">
                      <a href="javascript:;" class="rounded-circle title-btn"
                        :class="!templike.articleDislike ? '' : 'active'" @click.prevent="dislikeArticle">
                        <font-awesome-icon icon="thumbs-down" size="lg" />
                      </a>
                      <span class="text-secondary px-2">{{article.dislike}}</span>
                    </div>
                  </div>
                </div>
              </div>
              <div class="reply-group border p-3">
                <div class="reply-item row justify-content-between" v-for="(message,index) in messageList"
                  :key="message.messageId">
                  <div class="col-12 col-md-10 d-flex">
                    <a class="user-img">
                      <font-awesome-icon icon="user" size="lg" v-if="!isLogin" />
                      <img :src="message.userImg" alt="userImg" v-else>
                    </a>
                    <div class="reply-content">
                      <a class="replay-user mr-2 d-inline-block">{{message.userName}}</a>
                      <span
                        class="card-date text-muted">{{message.createdDate.replace(/-/g, "/").replace("T"," ").replace(/\.\d+/, "")}}</span>
                      <p>{{message.context}}</p>
                    </div>
                  </div>
                  <div class="col-12 col-md-2 d-flex align-items-center">
                    <a href="javascript:;" class="title-btn msg-btn border-0 rounded-circle"
                      :class="!templike.messagelikeList[index].like ? '' : 'active'"
                      @click.prevent="likeMessage(index)">
                      <font-awesome-icon icon="thumbs-up" size="sm" />
                    </a>
                    <span class="px-2">{{message.likeNumber}}</span>
                    <a href="javascript:;" class="title-btn msg-btn border-0 rounded-circle"
                      :class="!templike.messagelikeList[index].dislike ? '' : 'active'"
                      @click.prevent="dislikeMessage(index)">
                      <font-awesome-icon icon="thumbs-down" size="sm" />
                    </a>
                    <span class="px-2">{{message.disLikeNumber}}</span>
                  </div>
                </div>
                <div class="reply-item border-0">
                  <div class="input-group">
                    <a class="user-img text-secondary bg-white">
                      <font-awesome-icon icon="user" size="lg" v-if="!isLogin" />
                      <img :src="memberImg" alt="memberImg" v-else>
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
    <b-modal id="edit" title="編輯文章" size="lg" centered ok-title="儲存" cancel-title="取消" @ok="editArticle"
      @cancel="cancelEdit">
      <vue-editor id="editor" useCustomImageHandler @image-added="handleImageAdded"
        :customModules="customModulesForEditor" :editorOptions="editorSettings" v-model="article.description">
      </vue-editor>
    </b-modal>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar"
import { VueEditor } from "vue2-editor";
import { ImageDrop } from "quill-image-drop-module";
import ImageResize from "quill-image-resize";
import axios from 'axios'
export default {
  components: { Navbar, VueEditor },
  data () {
    return {
      isLogin: false,
      //編輯器
      customModulesForEditor: [
        { alias: "imageDrop", module: ImageDrop },
        { alias: "imageResize", module: ImageResize },
      ],
      editorSettings: {
        modules: {
          imageDrop: true,
          imageResize: {},
        },
      },
      //文章
      article: {
        postId: "",
        userId: "",
        title: "",
        userName: "",
        createDate: "",
        like: 0,
        dislike: 0,
        description: "",
        state: false
      },
      tempDescription: "",
      messageList: [],
      reply: {
        postId: "",
        context: "",
        userId: "",
      },
      memberImg: "",
      templike: {
        articleLike: false,
        articleDislike: false,
        messageLike: false,
        messageDisLike: false,
        messagelikeList: []
      }
    };
  },
  methods: {
    //圖片編輯器
    handleImageAdded (file, Editor, cursorLocation) {
      const CLIENT_ID = "3d78cf6e67ed6af";
      var formData = new FormData();
      formData.append("image", file);
      axios({
        url: "https://api.imgur.com/3/image",
        method: "POST",
        headers: {
          Authorization: "Client-ID " + CLIENT_ID,
        },
        data: formData,
      })
        .then((result) => {
          let url = result.data.data.link;
          Editor.insertEmbed(cursorLocation, "image", url);
        })
        .catch((err) => {
          console.log(err);
        });
    },
    getUserInfo () {
      let vm = this;
      let userUrl = process.env.VUE_APP_API + "/api/Users/getSingleMember";
      vm.$axios.get(userUrl).then(res => {
        vm.reply.userId = res.data.data.userId
        vm.memberImg = res.data.data.imgLink
        vm.isLogin = true
      }).catch(err => {
        console.log(err);
      })
    },
    getArticle () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/Post/getSingle/" + vm.$route.params.id;
      vm.$axios.get(url).then(res => {
        vm.article = {
          postId: res.data.postId,
          userId: res.data.userId,
          title: res.data.title,
          userName: res.data.userName,
          createDate: res.data.createdDate,
          description: res.data.description,
          like: res.data.likeNumber,
          dislike: res.data.disLikeNumber,
          state: res.data.state
        }
        vm.reply.postId = res.data.postId
      })
    },
    saveOrginArticle () {
      let vm = this;
      vm.tempDescription = vm.article.description
    },
    cancelEdit () {
      let vm = this;
      vm.article.description = vm.tempDescription;
    },
    getMessages () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/RMessage/GetAllMessages/" + vm.$route.params.id;
      vm.$axios.get(url).then(res => {
        if (res.data.issuccessful) {
          vm.messageList = res.data.data;
          res.data.data.forEach((item) => {
            let messageItem =
            {
              postId: item.postId,
              like: false,
              dislike: false
            }
            vm.templike.messagelikeList.push(messageItem)
          })
        }
      })
    },
    editArticle () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/Post/Edit";
      let data = {
        postId: vm.article.postId,
        title: vm.article.title,
        description: vm.article.description,
        state: true
      }
      vm.$axios.post(url, data).then(res => {
        console.log(res);
        if (res.status === 200) {
          vm.$swal({
            position: 'top-end',
            title: "編輯成功",
            icon: "success",
            showConfirmButton: false,
            timer: 1000
          })
        }
      }).catch(err => {
        console.log(err);
        vm.$swal({
          position: 'top-end',
          title: "編輯失敗" + err,
          icon: "error",
          showConfirmButton: false,
          timer: 1000
        })
      })
    },
    deleteArticle () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/Post/Delete";
      let data = {
        postId: vm.article.postId
      };
      vm.$swal({
        title: `刪除文章`,
        text: "你確定要刪除嗎",
        type: "question",
        showCancelButton: true,
        confirmButtonText: "確定",
        cancelButtonText: "取消",
      }).then((result) => {
        if (result.value) {
          vm.$axios.post(url, data).then(res => {
            console.log(res);
            if (res.status === 200) {
              vm.$swal({
                position: 'top-end',
                title: "刪除成功",
                icon: "success",
                showConfirmButton: false,
                timer: 1500
              })
              vm.$router.push('/');
            }
          }).catch(err => {
            vm.$swal("失敗", err)
          })
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
      if (!vm.templike.articleLike) {
        vm.templike.articleLike = true;
        vm.article.like += 1;
        if (vm.templike.articleDislike) {
          vm.templike.articleDislike = false;
          vm.article.dislike -= 1;
        }
      } else {
        vm.templike.articleLike = false;
        vm.article.like -= 1;
      }
    },
    dislikeArticle () {
      let vm = this;
      if (!vm.templike.articleDislike) {
        vm.templike.articleDislike = true;
        vm.article.dislike += 1;
        if (vm.templike.articleLike) {
          vm.templike.articleLike = false;
          vm.article.like -= 1;
        }
      } else {
        vm.templike.articleDislike = false;
        vm.article.dislike -= 1;
      }
    },
    likeMessage (index) {
      let vm = this;
      if (!vm.templike.messagelikeList[index].like) {
        vm.templike.messagelikeList[index].like = true
        vm.messageList[index].likeNumber += 1
        if (vm.templike.messagelikeList[index].dislike) {
          vm.templike.messagelikeList[index].dislike = false;
          vm.messageList[index].disLikeNumber -= 1
        }
      } else {
        vm.templike.messagelikeList[index].like = false
        vm.messageList[index].likeNumber -= 1
      }
    },
    dislikeMessage (index) {
      let vm = this;
      if (!vm.templike.messagelikeList[index].dislike) {
        vm.templike.messagelikeList[index].dislike = true;
        vm.messageList[index].disLikeNumber += 1
        if (vm.templike.messagelikeList[index].like) {
          vm.templike.messagelikeList[index].like = false;
          vm.messageList[index].likeNumber -= 1
        }
      } else {
        vm.templike.messagelikeList[index].dislike = false
        vm.messageList[index].disLikeNumber -= 1
      }
    },
    async saveLikeData () {
      let vm = this;
      let article = {
        url: process.env.VUE_APP_API + "/api/LikeAndDisLike/PostLikeAndDislike",
        data: {
          postId: vm.article.postId,
          likeNumber: vm.article.like,
          disLikeNumber: vm.article.dislike
        },
        post: function () {
          return vm.$axios.put(article.url, article.data).then(res => {
            console.log(res);
          }).catch(err => console.log(err))
        }
      }

      let message = {
        url: process.env.VUE_APP_API + "/api/LikeAndDisLike/MsgLikeAndDislike",
        data: [],
        post: function () {
          return message.data.forEach(item => {
            console.log(item);
            vm.$axios.post(message.url, item).then(res => {
              console.log(res);
            }).catch(err => console.log(err))
          }
          )
        }
      }
      vm.messageList.forEach(item => {
        let msgData = {
          messageId: item.messageId,
          likeNumber: item.likeNumber,
          disLikeNumber: item.disLikeNumber
        }
        message.data.push(msgData)
      })
      await article.post();
      await message.post();
    }
  },
  async created () {
    await this.getArticle()
    await this.getMessages()
    await this.getUserInfo()
  },
  beforeDestroy () {
    this.saveLikeData()
  },
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
      max-width: 100%;
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
    margin: 0 5px;
    transition: all 0.3s;
    &:hover {
      border: 1px solid rgb(244, 156, 66);
      color: rgb(244, 156, 66);
    }
  }

  a.active {
    border: 1px solid rgb(244, 156, 66);
    color: rgb(244, 156, 66);
  }

  a.msg-btn {
    width: 25px;
    height: 25px;
    margin: 0;
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
    > img {
      width: 100%;
      height: 100%;
      border-radius: 50%;
    }
  }
</style>