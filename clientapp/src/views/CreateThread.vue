<template>
  <div>
    <Navbar />
    <b-row>
      <b-col></b-col>
      <b-col cols="8">
        <div class="d-flex my-2 align-items-center">
          <label class="mr-3" for="Title">看板名稱:</label>
          <b-input
            v-model="titleContent"
            id="Title"
            class="mb-2 mr-sm-2 mb-sm-0 col-4"
            placeholder="請輸入文字"
            maxlength="4"
          ></b-input>
          <div class="text-danger small mt-1">
            {{ inputDataCheck.TitleErrorMsg }}
          </div>
        </div>
        <div class="d-block">
          <label class="mr-3" for="Textarea">申請說明:</label>
          <input
            class="form-control"
            id="Textarea"
            rows="5"
            placeholder="請輸入文字"
            maxlength="500"
          />
            <upload
        ref="upload"
        name="files"
        :async-save-url="'custom-save-url'"
        :async-remove-url="'custom-remove-url'"
      >
      </upload>
        </div>
      </b-col>
      <b-col></b-col>
    </b-row>
  </div>
</template>




<script>
import '@progress/kendo-ui';
import '@progress/kendo-theme-default/dist/all.css';
// Vue.use(UploadInstaller)
export default {
  components: {

    Navbar: () => import("@/components/common/Navbar"),
    Upload: () => import("@progress/kendo-upload-vue-wrapper"),
    // UploadInstaller: () => import("@progress/kendo-upload-vue-wrapper"),
  },
  data() {
    return {
      titleContent: "",
      isLogin: "",
      inputDataCheck: {
        TitleError: false,
        TitleErrorMsg: "",
      },
    };
  },
  mounted: function () {
    var upload = this.$refs.upload.kendoWidget();
    console.log(upload);
    // upload._module.postFormData = function (url, data, fileEntry, xhr) {
    //   var module = this;
    //   fileEntry.data("request", xhr);
    //   setTimeout(function () {
    //     var e = { target: { responseText: "", statusText: "OK", status: 200 } };
    //     module.onRequestSuccess.call(module, e, fileEntry);
    //   }, 1000);
    // };

    upload._submitRemove = function (fileNames, eventArgs, onSuccess) {
      onSuccess();
    };
  },

  watch: {
    titleContent: {
      immediate: true,
      handler: function () {
        if (this.titleContent == "") {
          this.inputDataCheck.TitleError = true;
          this.inputDataCheck.TitleErrorMsg = "請輸入文字哦!";
        } else if (this.titleContent.length == 4) {
          this.inputDataCheck.TitleError = true;
          this.inputDataCheck.TitleErrorMsg = "最多只能4個字哦!";
        } else {
          this.inputDataCheck.TitleError = false;
          this.inputDataCheck.TitleErrorMsg = "";
        }
        this.checkAddVerify();
      },
    },
  },
};
</script>

<style lang="scss" scoped>
</style>