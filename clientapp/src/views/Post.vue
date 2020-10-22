<template>
  <!-- Two-way Data-Binding -->
  <div>
    <Navbar />
    <b-row class="">
      <b-col> </b-col>
      <b-col cols="8">
        <!-- <h1>selected: {{ select }}</h1> -->
        <!-- <span>會員名稱:{{ userId }}</span> -->
        <b-form inline class="mt-3">
          <label class="mr-sm-2" for="inline-form-custom-select-pref"
            >選擇看板:</label
          >

          <select @change="getOptionIdx($event, $event.target.selectedIndex)">
            <option disabled selected>請選擇看板</option>
            <option
              v-for="(item, idx) in selectThread.threadName"
              :key="idx"
              :id="selectThread.threadId[idx]"
            >
              {{ item }}
            </option>
          </select>
        </b-form>
        <b-form inline class="mt-3">
          <label class="mr-3">標題:</label>
          <b-input
            v-model="titleContent"
            id="inline-form-input-name"
            class="mb-2 mr-sm-2 mb-sm-0"
            placeholder="請輸入文字"
            :class="{ 'is-invalid': inputDataCheck.TitleError }"
            maxlength="15"
          ></b-input>
          <div class="text-danger small mt-1">
            {{ inputDataCheck.TitleErrorMsg }}
          </div>
        </b-form>

        <p class="my-4">內文:</p>
        <vue-editor
          id="editor"
          useCustomImageHandler
          @image-added="handleImageAdded"
          :customModules="customModulesForEditor"
          :editorOptions="editorSettings"
          v-model="editorContent"
        ></vue-editor>
        <b-button
          :disabled="AddVerify == false"
          class="btn btn-primary mt-3"
          @click="saveContent"
        >
          發文
        </b-button>
      </b-col>
      <b-col></b-col>
    </b-row>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar";
// Advanced Use - Hook into Quill's API for Custom Functionality
import { VueEditor } from "vue2-editor";
import { ImageDrop } from "quill-image-drop-module";
import ImageResize from "quill-image-resize";
import axios from 'axios'

export default {
  components: { Navbar, VueEditor },
  name: "App",

  data() {
    return {
      userId: "",
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
      editorContent: "",
      customToolbar: [
        ["bold", "italic", "underline"],
        [{ list: "ordered" }, { list: "bullet" }],
        ["image", "code-block"],
      ],
      postData: {
        ForumId: "",
        Title: "",
        Description: "",
        UserId: "",
      },
      selectThread: {
        threadName: [],
        threadId: [],
        select: "",
      },
      selectPlaceHolder: "請選擇看板",
      titleContent: "",
      isLogin: "",
      inputDataCheck: {
        TitleError: false,
        TitleErrorMsg: "",
      },
      AddVerify: true,
    };
  },
  methods: {
    getOptionIdx: function (event, selectedIndex) {
      this.selectThread.select = event.target.querySelectorAll("option")[
        selectedIndex
      ].id;
    },
    //connect imgur api to upload img , from base64 to img
    handleImageAdded(file, Editor, cursorLocation) {
      const CLIENT_ID = "3d78cf6e67ed6af";
      var formData = new FormData();
      formData.append("image", file);
      console.log("底下是formdata");
      console.log(formData);
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
    getUserId: function () {
      let vm = this;
      let auth = vm.$store.state.tokenModule;
      let isAuth = auth.isAuthorize;
      let token = auth.token;
      const url = process.env.VUE_APP_API + "/api/Users/GetUserId";
      if (isAuth) {
        vm.isLogin = true;
        vm.$axios({
          url: url,
          method: "GET",
          headers: { Authorization: `Bearer ${token}` },
        })
          .then((res) => {
            vm.userId = res.data;
          })
          .catch((err) => console.log(err.response));
      }
    },
    getThreadName: function () {
      const url = process.env.VUE_APP_API + "/api/Forum/GetAll";
      this.$axios
        .get(url)
        .then((response) => {
          response.data.forEach((item) => {
            this.selectThread.threadName.push(item.forumName);
            this.selectThread.threadId.push(item.forumId);
          });
          this.selectThread.select = response.data[0].forumName;
        })
        .catch((err) => {
          console.log(err);
        });
    },
    saveContent: function () {
      let vm = this;
      this.postData.ForumId = this.selectThread.select;
      this.postData.Title = this.titleContent;
      this.postData.Description = this.editorContent;
      this.postData.UserId = this.userId;
      this.$axios
        .post(process.env.VUE_APP_API + "/api/Post/Create", this.postData)
        .then((response) => {
          console.log(response.data);
          console.log("成功Po文");
          vm.$router.push("/");
        })
        .catch((err) => {
          console.log(err);
        });
    },
    checkAddVerify() {
      for (let index in this.inputDataCheck) {
        if (this.inputDataCheck[index] == true) {
          console.log(this.inputDataCheck[index]);
          this.AddVerify = false;
          return;
        }
      }
      this.AddVerify = true;
    },
  },
  watch: {
    titleContent: {
      immediate: true,
      handler: function () {
        if (this.titleContent == "") {
          this.inputDataCheck.TitleError = true;
          this.inputDataCheck.TitleErrorMsg = "請輸入文字哦!";
        } else if (this.titleContent.length == 15) {
          this.inputDataCheck.TitleError = true;
          this.inputDataCheck.TitleErrorMsg = "最多只能15個字哦!";
        } else {
          this.inputDataCheck.TitleError = false;
          this.inputDataCheck.TitleErrorMsg = "";
        }
        this.checkAddVerify();
      },
    },
  },
  async created() {
    await this.getUserId();
    await this.getThreadName();
  },
};
</script>

<style>
</style>
