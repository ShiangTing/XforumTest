<template>
  <div>
    <ul class="list-group">
      <li class="list-group-item font-weight-bold bg-dark text-white">聊天列表</li>
      <li class="list-group-item" v-for="(item,index) in chatList" :key="index">
        <a class="d-flex align-items-center w-100 h-100" data-toggle="modal" data-target="#chatModal"
          @click="createChatRoom(item.userId)">
          <img :src="item.imgLink" class="chatList-img">
          <p class="m-0 pl-2 w-100 ">{{item.name}}</p>
        </a>
      </li>
    </ul>

    <!--
    console.log('----3', this.chatId) Modal -->
    <div class="modal fade" id="chatModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
      aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">ChatRoom</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body w-100">
            <div class="chat">
              <div class="d-flex flex-column chat-list">
                <div class="chat-message" v-for="(item,index) in receiveMsg" :key="index"
                  :class="item.userName === userData.username ? 'align-self-end right-color': 'align-self-start left-color'">
                  <span class="message-title" v-if="item.userName !== userData.username">{{item.userName}}</span>
                  <span class="message-content"
                    :class="item.userName === userData.username ? 'text-right': 'text-left'">{{ item.text }}</span>
                </div>
              </div>
              <div class="input-group chat-input-group">
                <input type="text" class="form-control chat-input h-100" placeholder="在書城論壇尋求邂逅是否搞錯了甚麼?"
                  v-model="inputMsg">
                <div class="input-group-append">
                  <button class="btn btn-secondary rounded-0" type="button" @click="sendMsgToHub">傳送</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import * as signalR from '@microsoft/signalr'
export default {
  data () {
    return {
      hubConnection: new signalR.HubConnectionBuilder()
        .configureLogging(signalR.LogLevel.Debug) //設定顯示log
        .withUrl(process.env.VUE_APP_API + '/chathub')
        .withAutomaticReconnect()
        .build(),
      chatList: [],
      show: false,
      inputMsg: "",
      receiveMsg: [],
      friendId: "",
      chatId: "",
      userData: {
        userId: "",
        username: ""
      }
    }
  },
  methods: {
    getUserInfo () {
      let vm = this;
      let userUrl = process.env.VUE_APP_API + "/api/Users/getSingleMember";
      return vm.$axios
        .get(userUrl)
        .then((res) => {
          vm.userData.userId = res.data.data.userId;
          vm.userData.username = res.data.data.name;
        })
        .catch((err) => {
          console.log(err);
        });
    },
    connectHub () {
      let vm = this;
      return vm.hubConnection.start().then(() => {
        vm.listenToHub();
      }).catch(() => {
        console.log("失敗");
      })
    },
    sendMsgToHub () {
      let vm = this;
      let data = {
        roomId: vm.chatId,
        userName: vm.userData.username,
        text: vm.inputMsg,
        dataTime: new Date()
      }
      vm.hubConnection.send('SendMessageToGroup', data).then(() => {
        console.log('msg send');
      })
      vm.inputMsg = "";
    },
    listenToHub () {
      let vm = this;
      vm.hubConnection.on('ReceiveGroupMessage', (roomId,username, text) => {
        console.log("回來囉");
        console.log(roomId, text, username);
        vm.receiveMsg.push(
          {
            userName: username,
            text: text,
          }
        )
      });
    },
    getChatList () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/Match/GetAllChatList"
      let data = {
        userId: vm.userData.userId
      }
      return vm.$axios.post(url, data).then(res => {
        vm.chatList = res.data.data
      })
    },
    getChatRoomId (friendId) {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/Chat/GetChatRoomId"
      let data = {
        userId: vm.userData.userId,
        FriendId: friendId
      }
      return vm.$axios.post(url, data).then(res => {
        vm.chatId = res.data.data
      })
    },
    joinGroup () {
      let vm = this;
      return vm.hubConnection.invoke('JoinGroup', vm.chatId)
        .then(() => {
          console.log('join Group');
        })
    },
    stopConnection () {
      let vm = this;
      return vm.hubConnection.stop().then(res => {
        console.log("中斷成功", res);
      })
    },
    getUserMessageHistory () {
      let vm = this;
      let url = process.env.VUE_APP_API + "/api/Match/GetAllChatDetails"
      let data = {
        roomId: vm.chatId
      }
      return vm.$axios.post(url, data).then((res) => {
        res.data.data.forEach(item => {
          vm.receiveMsg.push({
            userName: item.userName.trim(),
            text: item.text,
          })
        })
      })
    },
    async createChatRoom (friendId) {
      let vm = this;
      if (vm.friendId === "" || vm.friendId !== friendId) {
        vm.receiveMsg = [];
      }
      await vm.getChatRoomId(friendId);
      await vm.joinGroup()
      await vm.getUserMessageHistory();
    }
  },
  async created () {
    let vm = this;
    if (vm.$store.state.tokenModule.isAuthorize) {
      await vm.connectHub()
      await vm.getUserInfo()
      await vm.getChatList()
    }
  },
  beforeDestroy () {
    let vm = this;
    vm.stopConnection()
  }
}

</script>

<style lang="scss" scoped>
  a {
    text-decoration: none;
    cursor: pointer;
    color: #000;
  }
  .chatList-img {
    width: 30px;
    height: 30px;
    border-radius: 50%;
  }
  .message {
    &-title {
      display: block;
      letter-spacing: 1px;
      font-weight: 700;
      font-size: 10px;
      color: #6c6c6c;
    }
    &-content {
      display: block;
    }
  }
  .left-color {
    background-color: #f0bbd1;
  }
  .right-color {
    background-color: rgb(67, 199, 33);
  }
  .chat {
    width: 100%;
    height: 500px;
    padding: 10px;

    &-list {
      width: 100%;
      height: 90%;
      background: linear-gradient(
          to left top,
          rgba(255, 255, 255, 0.2),
          rgba(255, 255, 255, 0.2)
        ),
        url("https://images.unsplash.com/photo-1507842217343-583bb7270b66?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1000&q=60");
      background-position: center;
      background-repeat: no-repeat;
      background-size: cover;
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
      max-width: 200px;
      flex-direction: column;
      word-wrap: break-word;
      padding: 10px 10px;
      margin: 5px;
      border-radius: 6px;
    }
    .form-control:focus {
      outline: 1px solid #000;
      border: 1px solid #000;
    }
  }
</style>
