<template>
  <div>
    <Navbar />
    <b-row>
      <div class="col-3"></div>
      <div class="col-6">
        <div class="d-flex my-2 align-items-center">
          <label class="mr-3 col-2" for="Title">看板名稱:</label>
          <b-input
            v-model="forum.ForumName"
            id="Title"
            class="mb-2 mr-sm-2 mb-sm-0 col-4"
            placeholder="請輸入文字"
            maxlength="4"
          ></b-input>
          <div class="text-danger small mt-1">
            {{ inputDataCheck.TitleErrorMsg }}
          </div>
        </div>
        <div class="d-flex my-2 align-items-center">
          <label class="mr-3 col-2" for="Title">看板英文名稱:</label>
          <b-input
            v-model="forum.RouteName"
            id="Title"
            class="mb-2 mr-sm-2 mb-sm-0 col-4"
            placeholder="請輸入文字"
            maxlength="20"
          ></b-input>
        </div>
        <div class="d-flex my-2 align-items-center">
          <label class="mr-3 col-2" for="Title">看板說明:</label>
          <b-input
            v-model="forum.Description"
            id="Title"
            class="mb-2 mr-sm-2 mb-sm-0 col-4"
            placeholder="請輸入文字"
            maxlength="4"
          ></b-input>
        </div>        
        <div style="padding: 0px 15px">
          <img
            style="border: 1px dashed wheat"
            id="blah"
            :src="forum.ImgLink"
            alt="上傳您的頭像"
            width="100"
            height="100"
            class="my-3"
          />

          <input
            class="d-block mt-3"
            type="file"
            name="file"
            ref="file"
            @change="handleFileUpload"
          />
        </div>
        <div class="d-flex justify-content-end">
          <button class="btn btn-primary p-1 my-5" @click="createForum">
            創版申請
          </button>
        </div>
      </div>
      <div class="col-3"></div>
    </b-row>
  </div>
</template>




<script>
import axios from "axios";
export default {
  components: {
    Navbar: () => import("@/components/common/Navbar"),
  },
  data() {
    return {
      file: "",
      forum: {
        ForumName: "",
        RouteName: "",
        Description: "",
        ModeratorId: "",
        ImgLink: "",
      },
      isLogin: "",
      inputDataCheck: {
        TitleError: false,
        TitleErrorMsg: "",
      },
    };
  },
  mounted: {},
  methods: {
    getUserId: function () {
      let vm = this;
      const url = process.env.VUE_APP_API + "/api/Users/GetUserId";
      vm.$axios({
        url: url,
        method: "GET",
      })
        .then((res) => {
          vm.forum.ModeratorId = res.data;
        })
        .catch((err) => console.log(err.response));
    },
    handleFileUpload() {
      this.file = this.$refs.file.files[0];

      const CLIENT_ID = "3d78cf6e67ed6af";
      var formData = new FormData();
      formData.append("image", this.file);
      axios({
        url: "https://api.imgur.com/3/image",
        method: "POST",
        headers: {
          Authorization: "Client-ID " + CLIENT_ID,
        },
        data: formData,
      })
        .then((result) => {
          this.forum.ImgLink = result.data.data.link;
        })
        .catch((err) => {
          console.log(err);
        });
    },
    createForum() {
      if (
        this.forum.ForumName != "" &&
        this.forum.RouteName != "" &&
        this.forum.Description != "" &&
        this.forum.ImgLink != ""
      ) {
        const url = process.env.VUE_APP_API + "/api/Forum/Create";
        axios
          .post(url, this.forum)
          .then(() => {
            alert("看板創建成功，待審核後上架");
          })
          .catch((err) => {
            console.log(err);
          });
      } else {
        alert("資料沒填好");
      }
    },
  },
  watch: {
    forum: {
      ForumName: {
        immediate: true,
        handler: function () {
          if (this.forum.ForumName == "") {
            this.inputDataCheck.TitleError = true;
            this.inputDataCheck.TitleErrorMsg = "請輸入文字哦!";
          } else if (this.forum.ForumName.length == 4) {
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
  },
  async created() {
    await this.getUserId();
  },
};
</script>

<style lang="scss" scoped>
</style>