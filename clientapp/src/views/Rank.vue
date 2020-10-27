<template>
  <div>
    <Navbar />
    <div class="container">
      <h2 class="pt-3 text-center">購買稱號</h2>
      <div class="d-flex justify-content-between title-context">
        <div>
          <span>會員名稱:</span>
          <span>{{ user.userName }}</span>
        </div>
        <div>
          <span>您目前的點數:</span>
          <span>${{ user.points }}</span>
        </div>
        <div>
          <span>想要購買的稱號:</span>
          <span>{{ wantedRankName }}</span>
        </div>
      </div>

      <h4><b>已經擁有的稱號</b></h4>
      <div v-for="(item, idx) in hasRank" :key="idx" class="d-inline-block">
        <span class="badge badge-info m-3 p-2">{{ item.titleName }}</span>
      </div>
      <h4><b>可以購買的稱號</b></h4>
      <table class="table table-dark">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">稱號名稱</th>
            <th scope="col">稱號點數</th>
            <th scope="col"></th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="(rank, idx) in allRank"
            :key="idx"
            class="rankData"
            @click="selectRank(rank.titleName, rank.price)"
          >
            <th scope="row">{{ idx + 1 }}</th>
            <td>{{ rank.titleName }}</td>
            <td>${{ rank.price }}</td>
            <td>
              <button
                type="button"
                class="btn btn-primary"
                @click="buyRank(rank.titleName)"
              >
                購買
              </button>
            </td>
          </tr>
        </tbody>
      </table>
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
      user: {
        userId: "",
        userName: "",
        points: "",
      },
      allRank: [],
      hasRank: [],
      wantedRankName: "",
      wantedRankPrice: "",

      inputCheck: [],

      buyRankData: {
        UserId: "",
        TitleId: "",
      },
    };
  },
  methods: {
    buyRank(rankName) {
      let vm = this;
      if (this.wantedRankName == "") {
        vm.$swal("請先選擇想要買的稱號哦!");
      } else {
        this.$swal({
          title: `${rankName}`,
          text: "你確定要購買嗎",
          type: "question",
          showCancelButton: true,
          confirmButtonText: "確定",
          cancelButtonText: "取消",
        }).then((result) => {
          if (result.value) {
            const buyRankUrl = process.env.VUE_APP_API + "/api/Title/BuyTitle";
            vm.buyRankData.UserId = vm.user.userId;
            vm.buyRankData.TitleId = vm.wantedRankName;
            axios({
              url: `${buyRankUrl}`,
              method: "POST",
              data: vm.buyRankData,
            })
              .then(() => {
                console.log("成功購買");
                vm.$router.go(0);
              })
              .catch((err) => console.log(err.response));
          } else {

            console.log("購買失敗");
          }
        });
      }
    },
    selectRank(rankName, rankPrice) {
      console.log(rankName);
      this.wantedRankName = rankName;
      this.wantedRankPrice = rankPrice;
    },
    getPoints() {
      let vm = this;
      const getPointsUrl = process.env.VUE_APP_API + "/api/Title/GetPoints";
      axios
        .get(getPointsUrl + "/" + vm.user.userId)
        .then((res) => {
          vm.user.points = res.data;
        })
        .catch((err) => console.log(err.response));
    },
    getHasRank() {
      let vm = this;
      const getHasRank = process.env.VUE_APP_API + "/api/Title/GetHasTitles";
      axios({
        url: getHasRank + "/" + vm.user.userId,
        method: "GET",
      })
        .then((resHasRank) => {
          resHasRank.data.forEach((element) => {
            vm.hasRank.push(element);
          });
        })
        .catch((err) => console.log(err.response));
    },
    getAllRank() {
      let vm = this;
      const getAllRankUrl = process.env.VUE_APP_API + "/api/Title/GetAllTitles";
      axios
        .get(getAllRankUrl)
        .then((res) => {
          res.data.forEach((element) => {
            vm.allRank.push(element);
          });
        })
        .catch((err) => console.log(err.response));
    },

    getAllAxios() {
      let vm = this;
      let auth = vm.$store.state.tokenModule;
      let isAuth = auth.isAuthorize;
      let token = auth.token;
      vm.isLogin = true;
      const getIdUrl = process.env.VUE_APP_API + "/api/Users/GetUserId";
      const getNameurl = process.env.VUE_APP_API + "/api/Users/GetUserName";

      if (isAuth) {
        axios
          .all([
            axios({
              url: getIdUrl,
              method: "GET",
              headers: { Authorization: `Bearer ${token}` },
            }),
            axios({
              url: getNameurl,
              method: "GET",
              headers: { Authorization: `Bearer ${token}` },
            }),
          ])
          .then(
            axios.spread((resId, resName) => {
              vm.user.userId = resId.data;
              vm.user.userName = resName.data;
              vm.getPoints();
              vm.getHasRank();
            })
          )
          .catch((err) => console.log(err.response));
      }
    },
  },
  computed: {
    selectCheck() {
      return this.inputCheck.length > 0;
    },
  },
  updated() {
    let vm = this;
    vm.hasRank.forEach(function (item) {
      vm.allRank.forEach((data, idx, arr) => {
        if (item.titleName == data.titleName) {
          arr.splice(idx, 1);
          console.log(arr);
        }
      });
    });
  },
  async created() {
    await this.getAllAxios();
    await this.getAllRank();
  },
};
</script>

<style lang="scss" scoped>
h2 {
  font-size: 50px;
}
.title-context {
  span {
    font-size: 20px;
    color: #111;
    line-height: 10;
  }
}
input[type="checkbox"] {
  width: 25px; /*Desired width*/
  height: 25px; /*Desired height*/
}
.rankData {
  cursor: pointer;
  &:hover {
    background: darkkhaki;
  }
}
</style>