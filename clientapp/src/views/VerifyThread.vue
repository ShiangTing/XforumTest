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
              <p class="card-text text-center">
                {{ item.routeName }}
              </p>
              <div class="d-flex justify-content-around">
                <button
                  type="button"
                  class="btn btn-outline-success"
                  @click="allowcreate(item.routeName)"
                >
                  給過
                </button>
                <button
                  type="button"
                  class="btn btn-outline-danger"
                  @click="forbidcreate(item.routeName)"
                >
                  不給
                </button>
              </div>
              <p class="card-text text-center mt-3">
                <small class="text-muted"
                  >Created Time: {{ item.createdDate }}</small
                >
              </p>
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
      },
    };
  },
  methods: {
    getallposts() {
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
    allowcreate(routename) {
      const url = process.env.VUE_APP_API + "/api/Forum/ChangeForumState";
      this.changeForumState.RouteName = routename;
      this.changeForumState.State = true;
      console.log(this.changeForumState);
      this.$swal
        .fire({
          title: "Are you sure?",
          text: "You won't be able to revert this!",
          icon: "warning",
          showCancelButton: true,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Yes, do it!",
        })
        .then((result) => {
          if (result.isConfirmed) {
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
    forbidcreate(routename) {
      const url = process.env.VUE_APP_API + "/api/Forum/ChangeForumState";
      this.changeForumState.RouteName = routename;
      this.changeForumState.State = false;
      console.log(this.changeForumState);
      axios({
        url: url,
        method: "Post",
        data: this.changeForumState,
      }).then(() => {
        console.log("拒絕給過！");
        this.$swal.fire("拒絕給過！", "", "warning").then(()=> {
          this.$router.go(0);
        });
      });
    },
  },
  async created() {
    await this.getallposts();
  },
};
</script>

<style lang="scss" scoped></style>
