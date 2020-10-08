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

          <select class="selectpicker" ref="select" v-model="select">
            <option v-for="(l, idx) in listData" :key="idx">{{ l }}</option>
          </select>
          <!-- <b-form-select
            v-on:change="getSelectedItem"
            id="inline-form-custom-select-pref"
            class="mb-2 mr-sm-2 mb-sm-0"
            :options="options"
          ></b-form-select> -->
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

        <!-- <div class="edit_container">
          <quill-editor
            v-model="content"
            ref="myQuillEditor"
            :options="editorOption"
            @blur="onEditorBlur($event)"
            @focus="onEditorFocus($event)"
            @change="onEditorChange($event)"
          >
          </quill-editor>
          <button class="mt-3" v-on:click="saveHtml">儲存</button>
        </div> -->

        <vue-editor
          id="editor"
          useCustomImageHandler
          @image-added="handleImageAdded"
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
import axios from "axios";

// Advanced Use - Hook into Quill's API for Custom Functionality
import { VueEditor } from "vue2-editor";
import Qs from "qs";
// import { quillRedefine } from "../../node_modules/vue-quill-editor-upload";

export default {
  components: { Navbar, VueEditor },
  name: "App",

  data() {
    return {
      replyObj: {
        ForumId: "",
        PostId: null,
        Title: "",
        Description: "",
        CreatedDate: "",
        UserId: "",
        State: false,
      },

      Base64Img: {},
      listData: [
        "心情閒聊區",
        "新書怒灌區",
        "推理懸疑區",
        "奇幻冒險區",
        "人物傳記區",
        "程式討論區",
      ],
      select: "心情閒聊區",
      titleContent: "",
      editorContent: "",
    };
  },
  methods: {
    handleImageAdded(file, Editor, cursorLocation) {
      // const CLIENT_ID = "993793b1d8d3e2e";
      var formData = new FormData();
      formData.append("image", file);
      console.log("以下是formData的值");
      for (var value of formData.values()) {
        console.log(value);
      }

      let base64Obj = { base64String: file.name };
      console.log(base64Obj);
      // console.log(typeof);
      let url = process.env.VUE_APP_API + "/api/Img";

      axios({
        url: url,
        method: "POST",
        headers: {
          "Content-Type": "application/x-www-form-urlencoded",
        },
        data: Qs.stringify(base64Obj),
        // headers: {
        //   Authorization: "Client-ID " + CLIENT_ID,
        // },

        // data: formData,
        // headers: { "Content-Type": "multipart/form-data" },
      })
        .then((result) => {
          console.log(result);
          console.log("upload success");
          let url = result.data.data.link;
          console.log(url);
          Editor.insertEmbed(cursorLocation, "image", url);
        })
        .catch((err) => {
          console.log(err);
          console.log("upload fail");
        });
    },
    // // onEditorReady(editor) {
    // //   // 準備編輯器
    // // },
    // onEditorBlur() {}, // 失去焦點事件
    // onEditorFocus() {}, // 獲得焦點事件
    // onEditorChange() {}, // 內容改變事件
    saveContent: function () {
      let vm = this;
      this.replyObj.ForumId = "e356a9a0-5f15-4c75-a2dc-19011a823fb3";
      this.replyObj.Title = this.titleContent;
      this.replyObj.Description = this.content;
      this.replyObj.CreatedDate = new Date();
      this.replyObj.UserId = "0e42d4e5-2cbb-47dc-b7e9-25c1bac99ef5";
      this.replyObj.State = true;
      axios
        .post(process.env.VUE_APP_API + "/api/Post/Create", this.replyObj)
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
};
</script>

<style>
</style>
