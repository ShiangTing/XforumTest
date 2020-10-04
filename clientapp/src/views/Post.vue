<template>
  <!-- Two-way Data-Binding -->
  <div>
    <Navbar />
    <b-row class="">
      <b-col></b-col>
      <b-col cols="8">
        <b-form inline class="mt-3">
          <label class="mr-sm-2" for="inline-form-custom-select-pref"
            >選擇看板:</label
          >
          <b-form-select
            id="inline-form-custom-select-pref"
            class="mb-2 mr-sm-2 mb-sm-0"
            :options="[
              { text: '選擇看板名稱', value: null },
              '心情抒發區',
              '新書怒灌區',
              '懸疑哈哈區',
            ]"
            :value="null"
          ></b-form-select>
        </b-form>
        <b-form inline class="mt-3">
          <label class="mr-3">標題:</label>
          <b-input
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

export default {
  components: { Navbar },
  name: "App",
  data() {
    return {
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
    // onEditorReady(editor) {
    //   // 準備編輯器
    // },
    onEditorBlur() {}, // 失去焦點事件
    onEditorFocus() {}, // 獲得焦點事件
    onEditorChange() {}, // 內容改變事件
    saveHtml: function () {
      alert(this.content);
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
</style>