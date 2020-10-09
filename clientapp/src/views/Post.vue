<template>
  <!-- Two-way Data-Binding -->
  <div>
    <Navbar />
    <b-row class="">
      <b-col> </b-col>
      <b-col cols="8">
        <!-- <h1>selected: {{ select }}</h1> -->
        <span>會員名稱:</span>
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
            placeholder="請輸入標題名稱"
          ></b-input>
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
        <button @click="saveContent">發文</button>
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

export default {
  components: { Navbar, VueEditor },
  name: "App",

  data() {
    return {
      //editor section
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
      //
      postData: {
        ForumId: "",
        PostId: null,
        Title: "",
        Description: "",
        CreatedDate: "",
        UserId: "",
        State: false,
      },
      selectThread: {
        threadName: [],
        threadId: [],
        select: "",
      },
      selectPlaceHolder: "請選擇看板",
      titleContent: "",
    };
  },
  methods: {
    getOptionIdx: function (event, selectedIndex) {
      console.log(event, selectedIndex);
      console.log(event.target.querySelectorAll("option")[selectedIndex].id);
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
      this.$axios({
        url: "https://api.imgur.com/3/image",
        method: "POST",
        headers: {
          Authorization: "Client-ID " + CLIENT_ID,
        },
        data: formData,
      })
        .then((result) => {
          console.log(result);
          console.log("成功");
          let url = result.data.data.link;
          console.log(url);
          Editor.insertEmbed(cursorLocation, "image", url);
        })
        .catch((err) => {
          console.log(err);
        });
    },
    getThreadName: function () {
      const url = process.env.VUE_APP_API + "/api/Forum/GetAll";
      this.$axios
        .get(url)
        .then((response) => {
          console.log(response.data);
          console.log("成功");
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
      this.postData.CreatedDate = new Date();
      this.postData.UserId = "0e42d4e5-2cbb-47dc-b7e9-25c1bac99ef5";
      this.postData.State = true;
      this.$axios
        .post(process.env.VUE_APP_API + "/api/Post/Create", this.postData)
        .then((response) => {
          console.log(response);
          console.log("成功");
          vm.$router.push("/");
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
  async created() {
    await this.getThreadName();
  },
};
</script>

<style>
</style>
