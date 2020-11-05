<template>
  <div class="background bg-secondary">
    <Navbar />
    <div class="bg-secondary">
      <div class="container py-5">
        <div class="row justify-content-center">
          <div class="col-lg-9 col-12">
            <div class="card">
              <div class="card-body">
                <div class="row justify-content-between">
                  <div class="col-6">
                    <h3 class="card-title">{{ article.title }}</h3>
                    <h6 class="card-subtitle mb-2 text-success">
                      作者: {{ article.userName }}
                    </h6>
                    <p class="card-date text-muted">
                      {{
                        article.createDate
                          .replace(/-/g, "/")
                          .replace("T", " ")
                          .replace(/\.\d+/, "")
                      }}
                    </p>
                  </div>
                  <div class="col-3 d-flex justify-content-end align-items-center">
                    <a v-if="article.userId === reply.userId" class="title-btn rounded-circle" @click="
                        $bvModal.show('edit');
                        saveOrginArticle();
                      ">
                      <font-awesome-icon icon="pen" size="lg" />
                    </a>
                    <a v-if="article.userId === reply.userId" class="title-btn rounded-circle" @click="deleteArticle">
                      <font-awesome-icon icon="trash" size="lg" />
                    </a>
                  </div>
                </div>
                <hr />
                <div class="article-content">
                  <div v-html="article.description"></div>
                  <div class="col-6 d-flex align-items-center p-0">
                    <div class="mr-2 d-flex align-items-center">
                      <a class="rounded-circle title-btn" :class="!articleCurrentThumbStatus.isLike ? '' : 'active'"
                        @click.prevent="likeArticle">
                        <font-awesome-icon icon="thumbs-up" size="lg" />
                      </a>
                      <span class="text-secondary px-2">{{
                        article.likeNumber
                      }}</span>
                    </div>
                    <div class="mr-2 d-flex align-items-center">
                      <a class="rounded-circle title-btn" :class="!articleCurrentThumbStatus.isDisLike ? '' : 'active'"
                        @click.prevent="dislikeArticle">
                        <font-awesome-icon icon="thumbs-down" size="lg" />
                      </a>
                      <span class="text-secondary px-2">{{
                        article.disLikeNumber
                      }}</span>
                    </div>
                  </div>
                </div>
              </div>
              <div class="reply-group border p-3">
                <div class="reply-item d-flex justify-content-between" v-for="(message, index) in messageList"
                  :key="message.messageId">
                  <div class="col-12 col-md-9 d-flex p-0">
                    <a class="user-img">
                      <font-awesome-icon icon="user" size="lg" v-if="!isLogin" />
                      <img :src="message.userImg" alt="userImg" v-else />
                    </a>
                    <div class="reply-content">
                      <a class="replay-user mr-2 d-inline-block">{{
                        message.userName
                      }}</a>
                      <span class="card-date text-muted">{{
                        message.createdDate
                          .replace(/-/g, "/")
                          .replace("T", " ")
                          .replace(/\.\d+/, "")
                      }}</span>
                      <p>{{ message.context }}</p>
                    </div>
                  </div>
                  <div class="col-12 col-md-3 d-flex align-items-center justify-content-end p-0">
                    <a class="title-btn msg-btn border-0 rounded-circle" v-if="message.userId === reply.userId"
                      @click.prevent="deleteMessage(message.messageId)">
                      <font-awesome-icon icon="trash" size="sm" />
                    </a>
                    <div class="d-flex align-items-center">
                      <a class="title-btn msg-btn border-0 rounded-circle"
                        :class="msgCurrentThumbStatusList[index].isLike ? 'active' : ''"
                        @click.prevent="likeMessage(index)">
                        <font-awesome-icon icon="thumbs-up" size="sm" />
                      </a>
                      <span class="msg-num">{{ message.likeNumber }}</span>
                    </div>
                    <div class="d-flex align-items-center">
                      <a class="title-btn msg-btn border-0 rounded-circle"
                        :class="msgCurrentThumbStatusList[index].isDisLike ? 'active' : ''"
                        v-if=" messageList.length > 0" @click.prevent="dislikeMessage(index)">
                        <font-awesome-icon icon="thumbs-down" size="sm" />
                      </a>
                      <span class="msg-num">{{ message.disLikeNumber }}</span>
                    </div>
                  </div>
                </div>
                <div class="reply-item border-0">
                  <div class="input-group">
                    <a class="user-img text-secondary bg-white">
                      <font-awesome-icon icon="user" size="lg" v-if="!isLogin" />
                      <img :src="memberImg" alt="memberImg" v-else />
                    </a>
                    <textarea class="form-control" placeholder="留個言吧~" v-model="reply.context"></textarea>
                    <button class="btn btn-secondary h-100" @click.prevent="postMessage"
                      :disabled="reply.context.trim() !== ''? false:true">
                      送出
                    </button>
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
      <div class="input-group input-group-sm mb-3">
        <div class="input-group-prepend h-100">
          <label class="input-group-text bg-dark text-white" id="articleTitle">標題</label>
        </div>
        <input type="text" class="form-control h-100" aria-label="Sizing example input" aria-describedby="articleTitle"
          v-model="article.title">
      </div>
      <vue-editor id="editor" useCustomImageHandler @image-added="handleImageAdded"
        :customModules="customModulesForEditor" :editorOptions="editorSettings" v-model="article.description">
      </vue-editor>
    </b-modal>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar";
import { VueEditor } from "vue2-editor";
import { ImageDrop } from "quill-image-drop-module";
import ImageResize from "quill-image-resize";
import axios from "axios";
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
        likeNumber: 0,
        disLikeNumber: 0,
        description: "",
        state: false,
      },
      //留言
      messageList: [],
      // 編輯暫存
      tempTitle: "",
      tempDescription: "",
      // 使用者回覆
      memberImg: "",
      reply: {
        postId: "",
        context: "",
        userId: "",
      },
      // 儲存原始按讚資料
      articleOriginThumbStatus: {
        postId: "",
        userId: "",
        likeNumber: 0,
        disLikeNumber: 0,
        isLike: false,
        isDisLike: false,
      },
      // 按讚變化
      articleCurrentThumbStatus: {
        postId: "",
        userId: "",
        likeNumber: 0,
        disLikeNumber: 0,
        isLike: false,
        isDisLike: false,
      },
      msgOriginThumbStatusList: [],
      msgCurrentThumbStatusList: [],

      articletimer: null,
      msgTimer: null
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

      return vm.$axios
        .get(userUrl)
        .then((res) => {
          vm.reply.userId = res.data.data.userId;
          vm.memberImg = res.data.data.imgLink;
          vm.isLogin = true;
        })
        .catch((err) => {
          console.log(err);
        });
    },
    checkLogin () {
      let vm = this;
      if (!vm.isLogin) {
        vm.$swal({
          title: `請先登入喔`,
          text: "登入才能做此操作",
          type: "question",
          showCancelButton: true,
          confirmButtonText: "前往登入",
          cancelButtonText: "取消",
        }).then((result) => {
          if (result.value) {
            vm.$router.push('/login')
          }
        });
        return false
      } else {
        return true
      }
    },
    // 文章內容
    getArticle () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/Post/getSingle/" + vm.$route.params.id;
      return vm.$axios.get(url).then((res) => {
        vm.article = {
          postId: res.data.postId,
          userId: res.data.userId,
          title: res.data.title,
          userName: res.data.userName,
          createDate: res.data.createdDate,
          description: res.data.description,
          likeNumber: res.data.likeNumber,
          disLikeNumber: res.data.disLikeNumber,
          state: res.data.state,
        };
        vm.reply.postId = res.data.postId;
      }).then(() => {
        vm.getUserThumbStatus(vm.article.postId, vm.articleOriginThumbStatus, vm.articleCurrentThumbStatus)
        vm.articleOriginThumbStatus.postId = vm.article.postId
        vm.articleCurrentThumbStatus.postId = vm.article.postId
        vm.articleOriginThumbStatus.userId = vm.reply.userId
        vm.articleCurrentThumbStatus.userId = vm.reply.userId
      });

    },
    saveOrginArticle () {
      let vm = this;
      vm.tempDescription = vm.article.description;
      vm.tempTitle = vm.article.title;
    },
    cancelEdit () {
      let vm = this;
      vm.article.description = vm.tempDescription;
      vm.article.title = vm.tempTitle
    },
    editArticle () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/Post/Edit";
      let data = {
        postId: vm.article.postId,
        title: vm.article.title,
        description: vm.article.description,
        state: true,
      };
      vm.$axios
        .post(url, data)
        .then((res) => {
          if (res.status === 200) {
            vm.$swal({
              position: "top-end",
              title: "編輯成功",
              icon: "success",
              showConfirmButton: false,
              timer: 1000,
            });
          }
        })
        .catch((err) => {
          vm.$swal({
            position: "top-end",
            title: "編輯失敗" + err,
            icon: "error",
            showConfirmButton: false,
            timer: 1000,
          });
        });
    },
    deleteArticle () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/Post/Delete";
      let data = {
        postId: vm.article.postId,
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
          vm.$axios
            .post(url, data)
            .then((res) => {
              if (res.status === 200) {
                vm.$swal({
                  position: "top-end",
                  title: "刪除成功",
                  icon: "success",
                  showConfirmButton: false,
                  timer: 1500,
                });
                vm.$router.push("/");
              }
            })
            .catch((err) => {
              vm.$swal("失敗", err);
            });
        }
      });
    },
    //留言內容
    getMessages () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/RMessage/GetAllMessages/" + vm.$route.params.id;
      return vm.$axios.get(url).then((res) => {
        if (res.data.issuccessful) {
          vm.messageList = res.data.data;
          vm.messageList.forEach(() => {
            let defaultData = {
              messageId: "",
              userId: "",
              isLike: false,
              isDisLike: false,
              likeNumber: 0,
              disLikeNumber: 0
            };
            vm.msgOriginThumbStatusList.push(defaultData);
            vm.msgCurrentThumbStatusList.push(defaultData);
          })
        }
      }).then(() => {
        vm.messageList.forEach((item, index) => {
          vm.getUserThumbStatus(item.messageId, vm.msgOriginThumbStatusList[index], vm.msgCurrentThumbStatusList[index]);
          vm.msgOriginThumbStatusList[index].messageId = item.messageId;
          vm.msgCurrentThumbStatusList[index].messageId = item.messageId;
          vm.msgOriginThumbStatusList[index].userId = vm.reply.userId;
          vm.msgCurrentThumbStatusList[index].userId = vm.reply.userId;
        })
      });

    },
    postMessage () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/RMessage/CreateMessage";
      vm.$axios
        .post(url, vm.reply)
        .then((res) => {
          if (res.data.issuccessful) {
            vm.reply.context = "";
            vm.getMessages();
          }
        })
        .catch(() => {
          alert("請先登入再留言");
        });
    },

    deleteMessage (messageId) {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/RMessage/DeleteMessages";
      vm.$swal({
        title: `刪除留言`,
        text: "你確定要刪除嗎",
        type: "question",
        showCancelButton: true,
        confirmButtonText: "確定",
        cancelButtonText: "取消",
      }).then((result) => {
        if (result.value) {
          vm.$axios({
            method: 'delete',
            url: url,
            data: {
              id: messageId
            }
          }).then((res) => {
            console.log(res);
            vm.$swal({
              position: "top-end",
              title: "刪除成功",
              icon: "success",
              showConfirmButton: false,
              timer: 1500,
            });

          }).then(() => {
            vm.getMessages()
          })
        }
      });

    },
    getUserThumbStatus (id, origin, current) {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/LikeAndDisLike/GetUserLikeHistory"
      let data = {
        userId: vm.reply.userId,
        id: id
      }
      if (vm.isLogin) {
        return vm.$axios.post(url, data).then(res => {
          origin.isLike = res.data.data.isLike
          origin.isDisLike = res.data.data.isDisLike
          current.isLike = res.data.data.isLike
          current.isDisLike = res.data.data.isDisLike
        }).catch(err => {
          console.log(err);
        })
      }
      return
    },
    thumbUpCheck (orignThumbStatus, currentThumbStatus, viewData) {
      if (this.articleCurrentThumbStatus.isLike === this.articleOriginThumbStatus.isLike
        && this.articleCurrentThumbStatus.isDisLike === this.articleOriginThumbStatus.isDisLike) {
        this.articleCurrentThumbStatus.likeNumber = this.articleOriginThumbStatus.likeNumber
        this.articleCurrentThumbStatus.disLikeNumber = this.articleOriginThumbStatus.disLikeNumber
      }
      if (!currentThumbStatus.isLike && !currentThumbStatus.isDisLike) {
        currentThumbStatus.isLike = true
        currentThumbStatus.likeNumber = 1
        viewData.likeNumber += 1
        return;
      }

      if (currentThumbStatus.isLike && !currentThumbStatus.isDisLike) {
        currentThumbStatus.isLike = false
        currentThumbStatus.likeNumber = -1
        viewData.likeNumber -= 1
        return;
      }
      if (!currentThumbStatus.isLike && currentThumbStatus.isDisLike) {
        currentThumbStatus.isLike = true
        currentThumbStatus.likeNumber = 1
        viewData.likeNumber += 1
        currentThumbStatus.isDisLike = false
        currentThumbStatus.disLikeNumber = -1
        viewData.disLikeNumber -= 1
        return;
      }
    },
    thumbDownCheck (orignThumbStatus, currentThumbStatus, viewData) {
      if (this.articleCurrentThumbStatus.isLike === this.articleOriginThumbStatus.isLike
        && this.articleCurrentThumbStatus.isDisLike === this.articleOriginThumbStatus.isDisLike) {
        this.articleCurrentThumbStatus.likeNumber = this.articleOriginThumbStatus.likeNumber
        this.articleCurrentThumbStatus.disLikeNumber = this.articleOriginThumbStatus.disLikeNumber
      }
      if (!currentThumbStatus.isLike && !currentThumbStatus.isDisLike) {
        currentThumbStatus.isDisLike = true
        currentThumbStatus.disLikeNumber = 1
        viewData.disLikeNumber += 1
        return;
      }
      if (currentThumbStatus.isLike && !currentThumbStatus.isDisLike) {
        currentThumbStatus.isLike = false
        currentThumbStatus.likeNumber = -1
        viewData.likeNumber -= 1
        currentThumbStatus.isDisLike = true
        currentThumbStatus.disLikeNumber = 1
        viewData.disLikeNumber += 1
        return;
      }
      if (!currentThumbStatus.isLike && currentThumbStatus.isDisLike) {
        currentThumbStatus.isDisLike = false
        currentThumbStatus.disLikeNumber = -1
        viewData.disLikeNumber -= 1
        return;
      }
    },
    likeArticle () {
      let vm = this;
      if (vm.checkLogin()) {
        vm.thumbUpCheck(vm.articleOriginThumbStatus, vm.articleCurrentThumbStatus, vm.article);
        vm.updateArticleStatus(vm.articleCurrentThumbStatus).then(() => {
          vm.getUserThumbStatus(vm.article.postId, vm.articleOriginThumbStatus, vm.articleCurrentThumbStatus)
        })
      }
    },
    dislikeArticle () {
      let vm = this;
      if (vm.checkLogin()) {
        vm.thumbDownCheck(vm.articleOriginThumbStatus, vm.articleCurrentThumbStatus, vm.article);
        vm.updateArticleStatus(vm.articleCurrentThumbStatus).then(() => {
          vm.getUserThumbStatus(vm.article.postId, vm.articleOriginThumbStatus, vm.articleCurrentThumbStatus)
        })
      }
    },
    likeMessage (index) {
      let vm = this;
      if (vm.checkLogin()) {
        vm.thumbUpCheck(vm.msgOriginThumbStatusList[index],vm.msgCurrentThumbStatusList[index], vm.messageList[index])
        vm.updateMessageStatus(vm.msgCurrentThumbStatusList[index])
          .then(() => {
            vm.getUserThumbStatus(vm.msgCurrentThumbStatusList[index].messageId, vm.msgOriginThumbStatusList[index], vm.msgCurrentThumbStatusList[index])
          })
      }

    },
    dislikeMessage (index) {
      let vm = this;
      if (vm.checkLogin()) {
        vm.thumbDownCheck(vm.msgOriginThumbStatusList[index],vm.msgCurrentThumbStatusList[index], vm.messageList[index])
        vm.updateMessageStatus(vm.msgCurrentThumbStatusList[index])
          .then(() => {
            vm.getUserThumbStatus(vm.msgCurrentThumbStatusList[index].messageId, vm.msgOriginThumbStatusList[index], vm.msgCurrentThumbStatusList[index])
          })
      }

    },

    updateArticleStatus (current) {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/LikeAndDisLike/PostLikeAndDisLike";
      if (vm.isLogin) {
        return vm.$axios.put(url, current).then(res => {
          console.log("送出post狀態", res);
        })
      }
      return
    },
    updateMessageStatus (current) {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/LikeAndDisLike/MsgLikeAndDisLike";
      if (vm.isLogin) {
        return vm.$axios.post(url, current).then(res => {
          console.log("送出msg狀態", res);
        })
      }
      return
    }
  },
  async created () {
    let vm = this;
    if (vm.$store.state.tokenModule.isAuthorize) {
      await vm.getUserInfo();
    }
    await vm.getArticle();
    await vm.getMessages();
  },
  beforeDestroy () {
  },
};
</script>
<style lang="scss" scoped>
  $border-color: 1px solid rgba(0, 0, 0, 0.125);
  .background {
    min-height: 100vh;
  }
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
  }

  a.active {
    border: 1px solid rgb(244, 156, 66);
    color: rgb(244, 156, 66);
  }

  a.msg {
    &-btn {
      width: 25px;
      height: 25px;
      margin: 0;
      text-decoration: none;
    }
  }
  span.msg-num {
    display: inline-block;
    width: 30px;
    height: 25px;
    text-align: center;
    line-height: 25px;
    font-size: 12px;
  }
  textarea.form-control {
    padding: 4px 8px;
    display: block;
    overflow: auto;
    resize: none;
    height: 100%;
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
    display: flex;
    align-items: center;
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
  // modal
  /deep/ .modal-backdrop {
    background-color: rgba(0, 0, 0, 0.5);
  }
</style>