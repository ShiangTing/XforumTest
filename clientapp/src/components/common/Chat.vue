<template>
  <div>
    <ul class="list-group">
      <li class="list-group-item font-weight-bold bg-dark text-white">聊天列表</li>
      <li class="list-group-item" v-for="(item,index) in chatList" :key="index">
        <a class="d-flex align-items-center text-black w-100 h-100" data-toggle="modal" data-target="#chatModal">
          <img :src="item.imgLink" alt="" style="width: 30px; height: 30px">
          <p class="m-0 pl-2 text-black">{{item.name}}</p>
        </a>
      </li>
    </ul>

    <!-- Modal -->
    <div class="modal fade" id="chatModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
      aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body w-100">
            <div class="chat">
              <div class="d-block chat-list">
                <p class="chat-message" v-for="(text,index) in receiveMsg" :key="index">
                  {{ text }}
                </p>
              </div>
              <div class="input-group chat-input-group">
                <input type="text" class="form-control chat-input h-100" placeholder="在書城論壇尋求邂逅是否搞錯了甚麼?"
                  v-model="inputMsg">
                <div class="input-group-append">
                  <button class="btn btn-secondary " type="button" @click="sendMsgToHub">傳送</button>
                </div>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import * as signalR from '@aspnet/signalr'
export default {
  data () {
    return {
      userId: "",
      hubConnection: new signalR.HubConnectionBuilder()
        .configureLogging(signalR.LogLevel.Debug) //設定顯示log
        .withUrl(process.env.VUE_APP_API + '/chathub').build(),
      chatList: [],
      show: false,
      inputMsg: "",
      receiveMsg: [],
    }
  },
  methods: {
    connectHub () {
      let vm = this;
      vm.hubConnection.start().then(() => {
        vm.listenToHub();
      }).catch(() => {
        console.log("失敗");
      })
    },
    sendMsgToHub () {
      let vm = this;
      console.log();
      vm.hubConnection.send('Receive', vm.inputMsg).then(() => {
        console.log('msg send');
      })
      vm.inputMsg = "";
    },
    listenToHub () {
      let vm = this;
      vm.hubConnection.on('ReceiveMessage', (result) => {
        console.log("回來囉");
        vm.receiveMsg.push(result)
      });
    },
    callHubConnection () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/Chat/GetMessage?msg=" + vm.inputMsg
      vm.$axios.get(url).then(res => {
        console.log("安安", res);
      })
    },
    getChatList () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/Match/GetAllChatList"
      let data = {
        userId: vm.userId
      }
      console.log(data);
      vm.$axios.post(url, data).then(res => {
        vm.chatList = res.data.data
      })
    }
  },
  created () {
    let vm = this;
    vm.$bus.$on("getUserId", msg => {
      vm.userId = msg;
      vm.getChatList()
    });
    vm.connectHub();

  },
  beforeDestroy () {
    this.$bus.$off("getUserId");
  }
}

</script>

<style lang="scss" scoped>
  li {
    list-style: none;
  }
  .chat {
    width: 100%;
    height: 500px;
    padding: 10px;
    &-list {
      width: 100%;
      height: 90%;
      padding: 5px;
      overflow: auto;
      border: 1px solid #000;
    }
    &-input {
      &-group {
        width: 100%;
        height: 10%;
      }

      border: 1px solid #000;
      border-radius: 0%;
    }
    &-message {
      display: flex;
      align-items: center;
      width: 100%;
      max-width: 150px;
      word-wrap: break-word;
      height: 30px;
      padding: 10px 5px;
      margin: 5px;
      border-radius: 6px;
      background-color: rgba(67, 199, 33, 0.2);
    }
    .form-control:focus {
      outline: 1px solid #000;
      border: 1px solid #000;
    }
  }
</style>
