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

        <div class="edit_container">
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
        </div>
      </b-col>
      <b-col></b-col>
    </b-row>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar";
import axios from "axios";
export default {
  components: { Navbar },
  name: "App",
  data() {
    return {
      replyObj: {
        createdDate: "",
        img: "",
        moderatorId: "",
        description: "",
        forumName: "",
      },
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
      message: "我是寫在helloworld.vue的,訊息",
      content: `<p>hello world</p>`,
      editorOption: {},
    };
  },
  computed: {
    editor() {
      return this.$refs.myQuillEditor.quill;
    },
  },
  methods: {
    updated() {
      this.$refs.select.selectpicker("refresh");
    },
    getSelectedItem() {
      console.log(this.selected);
    },
    // onEditorReady(editor) {
    //   // 準備編輯器
    // },
    onEditorBlur() {}, // 失去焦點事件
    onEditorFocus() {}, // 獲得焦點事件
    onEditorChange() {}, // 內容改變事件
    saveHtml: function() {
      this.replyObj.forumName = this.select;
      this.replyObj.img = "";
      this.replyObj.description = this.content;
      this.replyObj.createdDate = "";
      this.replyObj.moderatorId = "";
      console.log(process.env.VUE_APP_API + "/api/Forum/Create");
      // let json = JSON.stringify(this.replyObj);
      // console.log(json);
      axios
        .post(process.env.VUE_APP_API + "/api/Forum/Create", this.replyObj)
        .then((response) => {
          console.log(response);
          console.log("成功");
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.ql-container {
  overflow-y: auto;
  height: 15rem !important;
}
.ql-editor {
  min-height: 25rem;
}
</style>
