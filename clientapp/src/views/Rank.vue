<template>
  <div>
    <Navbar />
    <div class="container">
      <h2 class="pt-3 text-center">購買稱號</h2>
      <div class="d-flex justify-content-between">
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
      <button type="button" class="btn btn-primary" @click="buyRank">
        購買
      </button>
      <table class="table table-dark">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col">稱號名稱</th>
            <th scope="col">稱號點數</th>
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
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar";
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
      wantedRankName: "",
      wantedRankPrice: "",
    };
  },
  methods: {
    buyRank() {
      let vm = this;
      if (this.wantedRankName == "") {
        alert("請先選擇想要買的稱號哦!");
      } else {
        const buyRankUrl = process.env.VUE_APP_API + "/api/Title/BuyTitle";

        let data = {
          userid: this.user.userId,
          titleid: this.wantedRankName,
        };
        vm.$axios
          .post(buyRankUrl, data)
          .then((res) => {
            console.log(res);
          })
          .catch((err) => console.log(err.response));
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
      vm.$axios
        .get(getPointsUrl + "/" + vm.user.userId)
        .then((res) => {
          vm.user.points = res.data;
        })
        .catch((err) => console.log(err.response));
    },
    getAllRank() {
      let vm = this;
      const getAllRankUrl = process.env.VUE_APP_API + "/api/Title/GetAllTitles";
      vm.$axios
        .get(getAllRankUrl)
        .then((res) => {
          console.log(res.data);
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
        vm.$axios
          .all([
            vm.$axios({
              url: getIdUrl,
              method: "GET",
              headers: { Authorization: `Bearer ${token}` },
            }),
            vm.$axios({
              url: getNameurl,
              method: "GET",
              headers: { Authorization: `Bearer ${token}` },
            }),
          ])
          .then(
            vm.$axios.spread((resId, resName) => {
              vm.user.userId = resId.data;
              vm.user.userName = resName.data;
              vm.getPoints();
            })
          )
          .catch((err) => console.log(err.response));
      }
    },
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
span {
  font-size: 20px;
  color: #111;
  line-height: 10;
}
.rankData {
  cursor: pointer;
  &:hover {
    background: darkkhaki;
  }
}
</style>