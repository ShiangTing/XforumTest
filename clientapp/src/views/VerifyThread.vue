<template>
  <div>
    <Navbar />
    <div class="container mt-3">
      <div class="card-group">
        <div class="col-xs-12 col-md-4" v-for="(item, idx) in posts" :key="idx">
          <div class="card">
            <img :src="item.imgLink" class="card-img-top" />
            <div class="card-body">
              <h5 class="card-title text-center">看版：{{ item.forumName }}</h5>
              <p class="card-text text-center">介紹：{{ item.description }}</p>
              <p class="card-text text-center mt-3">
                <small class="text-muted"
                  >申請者 : {{ item.moderatorName }}</small
                >
                <br>
                <small class="text-muted"
                  >申請時間 : {{ item.createdDate }}</small
                >
              </p>
              <div class="d-flex justify-content-around">
                <button
                  type="button"
                  class="btn btn-outline-success"
                  @click="allowCreate(item.routeName)"
                >
                  准許申請
                </button>
                <button
                  type="button"
                  class="btn btn-outline-danger"
                  @click="rejectCreate(item.routeName)"
                >
                  駁回申請
                </button>
              </div>
              <p class="card-text text-center mt-3 bg-danger text-light" v-if="!(item.state) && item.rejectMsg != null">拒絕原因：{{ item.rejectMsg }}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar";
import axios from "axios";
export default {
  components: { Navbar },
  data() {
    return {
      // posts:{
      //   createdDate: "",
      //   description: "",
      //   forumName: "",
      //   imgLink: "",
      //   routeName: ""
      // }
      posts: [],
      changeForumState: {
        RouteName: "",
        State: "",
        RejectMsg: "",
      },
    };
  },
  methods: {
    getAllForumRequest() {
      const url = process.env.VUE_APP_API + "/api/Forum/GetUnauditedForum";
      axios({
        url: url,
        method: "GET",
        // headers: { Authorization: `Bearer ${token}` },
      })
        .then((res) => {
          console.log(res.data);
          res.data.forEach((item) => {
            this.posts.push(item);
          });
          console.log(this.posts);
        })

        .catch((err) => {
          console.log(err);
        });
    },
    allowCreate(routename) {
      const url = process.env.VUE_APP_API + "/api/Forum/ChangeForumState";
      this.changeForumState.RouteName = routename;
      this.changeForumState.State = true;
      console.log(this.changeForumState);
      this.$swal
        .fire({
          title: "確定通過審核?",
          text: "成功後無法修正!",
          icon: "warning",
          showCancelButton: true,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Yes, do it!",
        })
        .then((result) => {
          if (result.isConfirmed) {
            this.changeForumState.RejectMsg = "Passed!";
            axios({
              url: url,
              method: "POST",
              data: this.changeForumState,
            }).then(() => {
              this.$router.go(0);
            })
            .catch((err) => console.log(err.response));
          }
        });
    },
    rejectCreate(routename) {
      const url = process.env.VUE_APP_API + "/api/Forum/ChangeForumState";
      this.changeForumState.RouteName = routename;
      this.changeForumState.State = false;

      console.log(this.changeForumState);

      this.$swal
        .fire({
          title: "確定拒絕審核?",
          text: "",
          input: "text",
          inputLabel: "請輸入原因：",
          inputValue: "",
          inputValidator: (value)=>{
            if(!value){
              return '必須輸入原因！'
            }
          },
          icon: "warning",
          showCancelButton: true,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Yes, do it!",
        })
        .then((result) => {
          if (result.isConfirmed) {
            this.changeForumState.RejectMsg = document.getElementById('swal2-input').value;
            axios({
              url: url,
              method: "POST",
              data: this.changeForumState,
            }).then(() => {
              console.log("駁回申請");
              this.$router.go(0);
            })
            .catch((err) => console.log(err.response));
          }
        });

      // axios({
      //   url: url,
      //   method: "Post",
      //   data: this.changeForumState,
      // }).then(() => {
      //   console.log("駁回申請");
      //   this.$swal.fire("駁回申請", "", "warning").then(()=> {
      //     this.$router.go(0);
      //   });
      // });
    },
  },
  async created() {
    await this.getAllForumRequest();
  },
};
</script>

<style lang="scss" scoped></style>
