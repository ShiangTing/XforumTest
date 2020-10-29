<template lang="pug">
<div>
  <Navbar />
  <div>
  //- <div class="text-center text-primary fa-3x">
  //-   p Welcome Love Wheel
  //- </div>
  <div class="d-flex justify-content-center align-items-center mt-5">
    //- <div class="mx-5">
    //- span.inputMatch(v-text="user.name")
    //- </div>
    //- <div v-if="user.imgLink">
    //- <img :src="user.imgLink"  width="100px" height="100px" class="matchImg">
    //- </div>

    h2.wantText.mx-5 想要與此陌生人配對嗎.....
    <div class="mx-5" v-if="metchUser.matchimgLink">
    h1.inputMatch(v-text="`『${metchUser.matchedName}』`")
    </div>
    <div v-if="metchUser.matchimgLink">
    <img :src="metchUser.matchimgLink" width="100px" height="100px" class="matchImg">
    </div>
      .ground
  #chat-button.button(@click="startChat") 加入好友
  </div>

  //- ICONS -//
- var el = {};

svg(style="opacity:0;height:0")
  path#twitter-icon(
    d="M6.28 3c3.236.001 4.973 3.491 5.72 5.031.75-1.547 2.469-5.021 5.726-5.021 2.058 0 4.274 1.309 4.274 4.182 0 3.442-4.744 7.851-10 13-5.258-5.151-10-9.559-10-13 0-2.676 1.965-4.193 4.28-4.192zm.001-2c-3.183 0-6.281 2.187-6.281 6.192 0 4.661 5.57 9.427 12 15.808 6.43-6.381 12-11.147 12-15.808 0-4.011-3.097-6.182-6.274-6.182-2.204 0-4.446 1.042-5.726 3.238-1.285-2.206-3.522-3.248-5.719-3.248z"
  )
    g#myspace-icon
      path(
        d="M23.156,10.582c2.893,0,5.239-2.371,5.239-5.291C28.396,2.368,26.049,0,23.156,0c-2.895,0-5.239,2.368-5.239,5.291C17.917,8.211,20.262,10.582,23.156,10.582z M23.156,12c-2.483,0-4.626,1.449-5.661,3.553c-0.013-2.544-2.058-4.603-4.58-4.603c-1.748,0-3.267,0.988-4.038,2.44v-0.925c0-1.771-1.424-3.21-3.179-3.21c-1.756,0-3.179,1.438-3.179,3.21v6.841h5.814v6.128h8.497V32H29.48V18.387C29.48,14.86,26.648,12,23.156,12z M5.698,8.543c1.454,0,2.632-1.189,2.632-2.658S7.152,3.227,5.698,3.227S3.064,4.416,3.064,5.885S4.244,8.543,5.698,8.543z M12.914,9.922c2.097,0,3.796-1.716,3.796-3.831c0-2.117-1.699-3.833-3.796-3.833c-2.095,0-3.794,1.716-3.794,3.833C9.12,8.206,10.819,9.922,12.914,9.922z"
      )
    g#quora-icon
      path(
        d="M2.178 11h-1.178v-2c.488-.001.784-.278.862-.665.637-2.461 3.164-8.335 10-8.335 6.888 0 9.484 6.135 10.294 8.413.15.421.459.584.844.584l.001 2.003h-1.18c.575.459 1.179 1.36 1.179 3.131 0 1.63-.904 3.686-2.877 4.531-2.153 3.445-5.027 5.338-8.123 5.338-3.096 0-5.97-1.893-8.123-5.338-1.974-.845-2.877-2.901-2.877-4.531 0-1.771.603-2.672 1.178-3.131zm12.022 7.459h-4.4c.004.012.626 1.74 2.2 1.74 1.634 0 2.196-1.728 2.2-1.74zm4.517-7.459h-13.435l-.013.515c0 .668-.682 1.114-1.288.844-.169-.075-.43-.073-.617.049-.917.601-.818 3.864 1.425 4.629.916.313 2.364 3.103 3.93.398.542-.934 2.251-1.039 3.281-.297 1.029-.742 2.739-.637 3.28.297 1.566 2.705 3.014-.085 3.931-.398 2.244-.765 2.341-4.028 1.424-4.629-.215-.14-.487-.106-.616-.049-.606.271-1.289-.176-1.289-.844l-.013-.515zm-9.696.996c-.634 0-1.146.62-1.146 1.385s.512 1.385 1.146 1.385c.632 0 1.146-.62 1.146-1.385s-.514-1.385-1.146-1.385zm7.104 1.385c0 .765-.513 1.385-1.146 1.385-.633 0-1.146-.62-1.146-1.385s.513-1.385 1.146-1.385c.633 0 1.146.62 1.146 1.385zm-5.125-11.338c-.735.075-1.4.244-2 .483v3.474c0 .552-.448 1-1 1s-1-.448-1-1v-2.269c-2.153 1.817-2.985 4.513-3.19 5.269h16.395c-.333-1.006-1.189-3.46-3.205-5.177v2.177c0 .552-.448 1-1 1s-1-.448-1-1v-3.406c-.599-.248-1.264-.431-2-.524v2.93c0 .552-.448 1-1 1s-1-.448-1-1v-2.957z"
      )
    g#blogging-icon
      path(
        fill-rule="evenodd",
        clip-rule="evenodd",
        d="M18.028 24h-.018c-.268 0-.49-.213-.499-.483-.05-1.462.19-2.847 2.265-3.08.795-.089.858-.367.996-.977.229-1.008.607-1.922 2.701-2.032.285-.02.512.197.526.473.014.276-.197.512-.473.526-1.512.079-1.618.547-1.778 1.254-.152.667-.359 1.581-1.861 1.751-1.016.113-1.432.423-1.377 2.051.01.276-.207.507-.482.517zm-8.342-18.714c.241.213.53.366.842.444l3.566.896c.3.076.617.051.903-.07 1.082-.461 3.862-1.684 5.062-2.155.76-.299 1.268.63.655 1.097-1.39 1.062-5.714 4.086-5.714 4.086l-.862 3.648s1.785 1.86 2.544 2.7c.423.469.696.919.421 1.595-.481 1.181-1.457 3.477-1.908 4.547-.255.605-1.164.453-1.015-.322.217-1.128.781-4.016.781-4.016l-3.558-1.62s-.253 5.953-.327 7.296c-.019.341-.253.589-.582.588-.249-.001-.508-.173-.612-.596-.534-2.178-2.142-8.99-2.142-8.99-.209-.837-.329-1.53-.053-2.564l.915-3.85s-2.726-3.984-3.709-5.476c-.402-.611.356-1.18.808-.78l3.985 3.542zm-7.178 8.489l-.853.511 2.708 4.524c-1.788.306-2.917 1.904-2.048 3.356.537.897 1.753 1.106 2.622.586 1.034-.619 1.774-1.952.979-3.284l-3.408-5.693zm17.721-5.193l.904 1.669 1.867.344-1.308 1.376.249 1.882-1.712-.819-1.713.819.25-1.882-1.309-1.376 1.867-.344.905-1.669zm-17.298-2.935l-2.934 2.935 2.934 2.935 2.935-2.935-2.935-2.935zm9.055-5.398c1.36-.626 2.972-.03 3.597 1.33.626 1.36.03 2.972-1.33 3.598-1.36.625-2.972.029-3.598-1.331-.625-1.36-.029-2.972 1.331-3.597z"
      )
    g#youtube-icon
      path(
        fill-rule="evenodd",
        clip-rule="evenodd",
        d="M20.5 12.5c0 .828-.56 1.5-1.25 1.5s-1.25-.672-1.25-1.5.56-1.5 1.25-1.5 1.25.672 1.25 1.5zm-7.75-1.5c-.69 0-1.25.672-1.25 1.5s.56 1.5 1.25 1.5 1.25-.672 1.25-1.5-.56-1.5-1.25-1.5zm3.25 8.354c2.235 0 3-2.354 3-2.354h-6s.847 2.354 3 2.354zm12-5.803c0 1.925-.896 4.738-3.317 5.188-1.959 3.492-4.877 5.261-8.683 5.261s-6.724-1.769-8.683-5.26c-2.421-.451-3.317-3.263-3.317-5.189 0-2.147.809-4.093 2.843-4.223.453-5.099 3.946-8.328 9.157-8.328s8.704 3.229 9.157 8.329c2.036.129 2.843 2.073 2.843 4.222zm-2.631-2.116c-.272-.178-.615-.104-.756-.041-.661.293-1.406-.191-1.406-.914 0-1.344-.315-5.007-3.46-6.654 1.304 1.354 1.753 3.792 1.753 5.174h-12.591999999999999c-.09.601-.115 1.124-.115 1.48 0 .723-.745 1.207-1.406.914-.142-.063-.484-.137-.756.041-1.102.716-.798 5.326 1.337 5.367.367.007.702.216.87.543 2.391 4.655 5.981 4.655 7.162 4.655s4.771 0 7.162-4.655c.168-.328.503-.536.87-.543 2.134-.042 2.44-4.651 1.337-5.367zm-.619-6.748c3.797-1.093.375 7.346 7.25 7.313-2.266-1.469-.893-5.476-1.5-8.166-.518-2.293-2.328-2.834-3.5-2.834-1.875 0-3.106 1.106-3.603 1.922.544.478 1.014 1.224 1.353 1.765zm-16.147-1.765c-.497-.816-1.728-1.922-3.603-1.922-1.172 0-2.982.541-3.5 2.834-.607 2.69.766 6.697-1.5 8.166 6.875.033 3.453-8.406 7.25-7.313.339-.541.809-1.287 1.353-1.765z"
      )
    g#facebook-icon
      path(
        fill-rule="evenodd",
        clip-rule="evenodd",
        d="M2.178 11h-1.178v-2.209c.468 0 .774-.474.944-.997.587-1.803 1.59-4.513 4.056-6.212v3.418c0 .552.448 1 1 1s1-.448 1-1v-4.437c.868-.309 1.861-.516 3-.585v3.022c0 .552.448 1 1 1s1-.448 1-1v-3c1.134.094 2.128.327 3 .661v4.339c0 .552.448 1 1 1s1-.448 1-1v-3.269c2.391 1.7 3.463 4.304 4.057 6.063.175.52.475.997.943.997v2.209h-1.179c.575.459 1.179 1.36 1.179 3.131 0 1.63-.904 3.686-2.877 4.531-2.153 3.445-5.027 5.338-8.123 5.338-3.096 0-5.97-1.893-8.124-5.338-1.973-.845-2.876-2.901-2.876-4.531 0-1.771.603-2.672 1.178-3.131zm12.022 7.459h-4.4c.004.012.626 1.74 2.2 1.74 1.634 0 2.196-1.728 2.2-1.74zm4.517-7.459h-13.435l-.013.515c0 .668-.682 1.114-1.288.844-.169-.075-.43-.073-.617.049-.917.601-.819 3.864 1.425 4.629.916.313 2.364 3.103 3.93.398.542-.934 2.251-1.039 3.281-.297 1.029-.742 2.739-.637 3.28.297 1.566 2.705 3.014-.085 3.93-.398 2.244-.765 2.342-4.028 1.425-4.629-.215-.14-.487-.106-.616-.049-.606.271-1.289-.176-1.289-.844l-.013-.515zm-9.696.996c-.634 0-1.146.62-1.146 1.385s.512 1.385 1.146 1.385c.632 0 1.146-.62 1.146-1.385s-.514-1.385-1.146-1.385zm7.104 1.385c0 .765-.513 1.385-1.146 1.385-.633 0-1.146-.62-1.146-1.385s.513-1.385 1.146-1.385c.633 0 1.146.62 1.146 1.385z"
      )
    g#foursquare-icon
      path(
        d="M8.816 1.321c.815-.816 1.941-1.321 3.184-1.321 1.251 0 2.384.512 3.2 1.338 4.056.308 5.687 1.739 7.382 8.486.664.463 1.418 1.436 1.418 3.489 0 1.765-.986 3.991-3.139 4.906-2.348 3.731-5.484 5.781-8.861 5.781-3.377 0-6.513-2.05-8.862-5.781-2.153-.915-3.138-3.141-3.138-4.906 0-2.053.753-3.026 1.417-3.489 1.732-6.779 3.38-8.213 7.399-8.503zm5.584 16.679h-4.8c.004.012.682 1.884 2.4 1.884 1.782 0 2.396-1.872 2.4-1.884zm5.235-11h-3.894c-.807 1.206-2.182 2-3.741 2-1.559 0-2.934-.794-3.741-2h-3.923c-.222.631-.412 1.304-.58 2-.179.746.964.954.917 1.733-.044.722-.76.953-1.421.661-.184-.082-.469-.079-.673.053-1 .651-.893 4.184 1.554 5.012 1 .339 2.579 3.361 4.288.432.591-1.012 2.455-1.126 3.579-.322 1.123-.804 2.988-.69 3.578.322 1.709 2.929 3.288-.093 4.288-.432 2.448-.828 2.554-4.361 1.554-5.012-.235-.152-.531-.115-.672-.053-.661.293-1.36.094-1.374-.629-.016-.818 1.114-.871.89-1.765-.168-.669-.389-1.356-.629-2zm-3.885 2c-1.124 0-2.094.629-2.607 1.546-.373-.116-.744-.174-1.143-.174s-.77.058-1.143.174c-.513-.917-1.483-1.546-2.607-1.546-1.654 0-3 1.346-3 3s1.346 3 3 3c1.231 0 2.285-.748 2.747-1.811.245-.566.394-1.301 1.003-1.301.609 0 .758.735 1.003 1.301.462 1.063 1.516 1.811 2.747 1.811 1.654 0 3-1.346 3-3s-1.346-3-3-3zm0 4.5c-.828 0-1.5-.672-1.5-1.5s.672-1.5 1.5-1.5 1.5.672 1.5 1.5-.672 1.5-1.5 1.5zm-7.5 0c-.828 0-1.5-.672-1.5-1.5s.672-1.5 1.5-1.5 1.5.672 1.5 1.5-.672 1.5-1.5 1.5zm3.75-11.5c1.38 0 2.5 1.12 2.5 2.5s-1.12 2.5-2.5 2.5-2.5-1.12-2.5-2.5 1.12-2.5 2.5-2.5z"
      )
    g#google-plus-icon
      path(
        fill-rule="evenodd",
        clip-rule="evenodd",
        d="M17.5 12.5c0 .828-.56 1.5-1.25 1.5s-1.25-.672-1.25-1.5.56-1.5 1.25-1.5 1.25.672 1.25 1.5zm-7.75-1.5c-.69 0-1.25.672-1.25 1.5s.56 1.5 1.25 1.5 1.25-.672 1.25-1.5-.56-1.5-1.25-1.5zm3.25 8.354c2.235 0 3-2.354 3-2.354h-6s.847 2.354 3 2.354zm13-6.75c0 2.865-.791 5.778-1.933 8.243-.542 1.169-1.163 2.238-1.817 3.153l-3.796-1.917c-1.556 1.187-3.37 1.917-5.454 1.917-1.993 0-3.825-.749-5.408-1.941l-3.842 1.941c-.654-.915-1.275-1.984-1.817-3.153-1.142-2.465-1.933-5.378-1.933-8.243 0-7.59 5.281-12.604 13-12.604s13 5.014 13 12.604zm-5.669 4.285c.123-.202.313-.354.536-.43 2.106-.713 2.57-3.529 1.802-4.746-6.576-.39-10.89-3.363-12.669-6.322-2.257 5.063-5.078 6.628-6.863 6.795-.482 1.714.322 3.706 1.996 4.273.224.076.413.228.536.43 1.708 2.83 4.015 5.111 7.331 5.111 3.318 0 5.624-2.284 7.331-5.111z"
      )
    g#linkedin-icon
      path(
        fill-rule="evenodd",
        clip-rule="evenodd",
        d="M21.292 9.349c-.43-4.813-3.604-9.349-9.292-9.349s-8.862 4.536-9.292 9.349c-1.859.165-2.708 1.921-2.708 3.964 0 1.755.975 3.967 3.104 4.891 2.935 5.371 7.534 5.796 8.896 5.796s5.961-.425 8.896-5.796c2.129-.925 3.104-3.136 3.104-4.891 0-2.019-.841-3.798-2.708-3.964zm-1.425 7.11c-.246.083-.45.259-.569.491-2.406 4.686-6.194 5.05-7.298 5.05s-4.892-.364-7.298-5.05c-.119-.231-.323-.407-.569-.491-2.448-.829-2.553-4.364-1.553-5.012.206-.133.49-.134.671-.053.66.292 1.406-.189 1.406-.914l.02-.566c1.803-.406 4.331-2.774 4.964-4.039-.069.852-.891 3.254-2.076 4.063 2.748 0 6.25-2.507 7.685-4.828.088 2.081 2.114 4.016 4.035 4.311.034.354.058.707.058 1.059 0 .723.745 1.207 1.406.914.141-.063.435-.1.671.053 1 .648.895 4.183-1.553 5.012zm-3.367-3.959c0 .828-.56 1.5-1.25 1.5s-1.25-.672-1.25-1.5.56-1.5 1.25-1.5 1.25.672 1.25 1.5zm-7.75 1.5c-.69 0-1.25-.672-1.25-1.5s.56-1.5 1.25-1.5 1.25.672 1.25 1.5-.56 1.5-1.25 1.5zm.25 3h6s-.765 2.354-3 2.354c-2.153 0-3-2.354-3-2.354zm20 0c-2.781.797-3.717-1.06-4-4-.496-5.152-.973-8.926-4.051-8.255-.378-.844-.84-1.683-1.588-2.477.873-1.127 2.533-2.268 4.431-2.268 7.316 0 3.77 11.491 3.77 14 0 1.5.294 2.323 1.438 3z"
      )

//- MIXINS nad FUNCTIONS -//
- var random = function(a, b){
- return Math.floor(Math.random() * (b + 1 - a) + a);
- }

mixin icon(el)
  .icon(class=el.class, id=el.idAttribute, title=el.title)
    svg(viewBox="0 0 25 39")
      use(xlink:href='#' + el.path)

//- FERRIS WHEEL -//
- var icons = ['facebook', 'linkedin', 'google-plus', 'foursquare', 'quora', 'blogging', 'youtube', 'myspace'];
#js-ferris-wheel.ferris-wheel.is-open
  svg.ferris-wheel--script-path(
    width="731px",
    height="560px",
    viewbox="0 0 731 560"
  )
    defs
      path#ferris-script(
        ,
        fill="none",
        stroke="#E30613",
        stroke-width="2",
        stroke-miterlimit="10",
        d="M-522.865,1384.396L57.03,347.583c0,0,67.789-114.568,90.385-152.757l0,0C187.87,123.386,264.57,75.175,352.53,75.175c130.094,0,235.555,105.461,235.555,235.556c0,105.606-69.498,194.983-165.256,224.886L-721.942,922.059"
      )
    text
      textPath#js-ferris-text(, xlink:href="#ferris-script", startOffset="0") data harvested from 60+ social networks

  .ferris-wheel--core
    - for (var i=0; i<12; i++)
      - el = { class: 'n-' + i + ' n-' + icons[i % icons.length], id: '' };
      - icon = { path: icons[i % icons.length] + '-icon' };
      .cabin(class=el.class, id=el.id)
        .cabin--handle
        .cabin--core
          .cabin--core2
            +icon(icon)
            .cabin--base
            - for (var j=0; j<random(2,3); j++)
              - el = { class: 'human-' + j, id: '' };
              .human(class=el.class, id=el.id)

    .ferris-wheel--circle1
    .ferris-wheel--circle2

    - var spikesCnt = 24;
    - for (var i=0; i<spikesCnt; i++)
      .ferris-wheel--spike(class='n-' + i)

    - for (var i=0; i<spikesCnt; i++)
      .ferris-wheel--spike(class='s-' + i)

  .ferris-base
    .ferris-base--center
      - el = { path: 'twitter-icon' };
      +icon(el)
    .ferris-base--top
    .ferris-base--main
    .ferris-base--spike.is-1
    .ferris-base--spike.is-2
    .ferris-base--handle

.ground
  #js-button.button 開始配對

.ground
  #hide-button.button 重新配對
    </div>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar";
import * as signalR from "@aspnet/signalr";
import $ from "jquery";
// import axios from "axios";
export default {
  components: { Navbar },
  data() {
    return {
      user: {
        userId: "",
        name: "",
        ownerRank: "",
        age: "",
        gender: "",
        imgLink: "",
      },
      self: {
        userId: "",
      },
      metchUser: {
        matchedName: "",
        matchedUserId: "",
        matchimgLink: "",
      },
      chatData: {
        userId: "",
        friendId: "",
      },
      sendMsgJson: {
        UserId: "ba8ccd2b-b320-43cc-a023-edb75ca0b8dd",
        UserMessage: "我傳訊息了",
      },
      hubConnection: new signalR.HubConnectionBuilder()
        .configureLogging(signalR.LogLevel.Debug) //設定顯示log
        .withUrl(process.env.VUE_APP_API + "/chathub")
        .build(),
    };
  },
  methods: {
    connectHub() {
      let vm = this;
      vm.hubConnection
        .start()
        .then(() => {
          vm.getConnectionId();
        })
        .then(() => {
          vm.listenToHub();
        })
        .catch(() => {
          console.log("失敗");
        });
    },
    sendMsgToHub() {
      let vm = this;
      // let a = JSON.stringify(vm.sendMsgJson);
      // vm.sendMsgJson.userId = vm.user.userId;
      vm.hubConnection.send("SendMessageToMember", vm.sendMsgJson).then(() => {
        // console.log(vm.sendMsgJson);
        console.log("msg send");
      });
    },
    listenToHub() {
      let vm = this;
      vm.hubConnection.on("SendMessage", (id, msg) => {
        console.log(id, msg);
      });
    },
    getConnectionId() {
      let vm = this;
      vm.hubConnection.invoke("GetConnectionId").then((msg) => {
        console.log("connectionId");
        console.log("connectionId", msg);
        vm.sendMsgJson.UserId = msg;
      });
    },
    startChat() {
      this.$swal({
        title: `您配對到的是${this.metchUser.matchedName}`,
        text: "要加入好友列表嗎",
        type: "question",
        showCancelButton: true,
        confirmButtonText: "確定",
        cancelButtonText: "取消",
      }).then((result) => {
        if (result.value) {
          let vm = this;
          const chatUrl = process.env.VUE_APP_API + "/api/Match/AddToChatList";
          vm.$axios({
            url: chatUrl,
            method: "POST",
            data: vm.chatData,
          })
            .then(() => {
              vm.sendMsgToHub();
              // vm.$router.push("/");
            })
            .catch((err) => {
              console.log(err);
            });
        }
      });
    },
  },
  created() {
    let vm = this;
    vm.connectHub();
  },
  mounted() {
    $(".wantText").hide();
    $("#hide-button").hide();
    $("#chat-button").hide();
    $("#hide-button").on("click", function () {
      location.reload();
    });
    // $("#chat-button").on("click", function () {

    // });
    let carousel = $("#js-ferris-wheel");
    let vm = this;
    $("#js-button").on("click", function () {
      $("#js-button").hide();
      $("#hide-button").show();
      $("#chat-button").show();
      $(".wantText").show();
      carousel.toggleClass("is-open");
      const url = process.env.VUE_APP_API + "/api/Users/GetSingleMember";
      vm.$axios({
        url: url,
        method: "GET",
      })
        .then((res) => {
          vm.user.userId = res.data.data.userId;
          vm.self.userId = res.data.data.userId;
          vm.user.name = res.data.data.name;
          vm.user.age = res.data.data.age;
          vm.user.gender = res.data.data.gender;
          vm.user.ownerRank = res.data.data.titleName;
          vm.user.imgLink = res.data.data.imgLink;
          const matchUrl = process.env.VUE_APP_API + "/api/Match/MatchUser";
          vm.$axios({
            url: matchUrl,
            method: "POST",
            data: vm.self,
          })
            .then((res) => {
              vm.metchUser.matchedName = res.data.data.matchedName;
              vm.metchUser.matchedUserId = res.data.data.matchedUserId;
              vm.metchUser.matchimgLink = res.data.data.matchimgLink;
              vm.chatData.userId = vm.self.userId;
              vm.chatData.friendId = vm.metchUser.matchedUserId;
            })

            .catch((err) => {
              console.log(err);
            });
        })

        .catch((err) => {
          console.log(err);
        });
    });
  },
};
</script>

<style lang="stylus" scoped>
/* MIXINS */
* {
  box-sizing: border-box;
}

center-shift(size) {
  margin-top: -(size / 2);
  margin-left: -(size / 2);
  position: absolute;
  left: 50%;
  top: 50%;
}

rect(size) {
  width: size;
  height: size;
}

circle(size) {
  rect: size;
  border-radius: 50%;
}

random(a, b) {
  return math(math(0, 'random') * (b - a + 1) + a, 'floor');
}

/* ENVIROMENT */
fontSize = 16;
PX = (1 / fontSize)rem;
/* grid size = 10px in rem equivalent */
gs = 10 * PX;

html {
  font-size: fontSize px;
}

body {
  background: #6ED2D2 url() repeat top left;
  position: relative;
}

html, body {
  height: 100%;
}

buttonColor = #DD5754;
buttonHeight = 5 * gs;

.button {
  background: buttonColor;
  border-radius: 3 * PX;
  text-transform: uppercase;
  color: white;
  height: buttonHeight;
  line-height: buttonHeight;
  width: 20 * gs;
  text-align: center;
  letter-spacing: 2 * PX;

  &:hover {
    background-color: lighten(buttonColor, 3);
    cursor: pointer;
  }

  &:active {
    background-color: buttonColor;
  }
}

groundHeight = 12 * gs;

.ground {
  position: absolute;
  left: 0;
  bottom: 0;
  height: groundHeight;
  width: 100%;
  background: #493442 url() repeat bottom right;

  .button {
    margin-left: auto;
    margin-right: auto;
    margin-top: ((groundHeight - buttonHeight) / 2);
    position: relative;
    z-index: 2;
  }
}

/* FERRIS WHEEL */
.human {
  background-color: #6e6e6e;
  border-radius: 50%;
  height: 26 * PX;
  width: 10 * PX;
  position: relative;

  &:after {
    content: '';
    position: absolute;
    rect: 7 * PX;
    background-color: inherit;
    top: - 5 * PX;
    border-radius: 50%;
    left: 50%;
    margin-left: - 3 * PX;
  }
}

ferrisWheelTransitionCoef = 0.3s;

.ferris-base {
  margin-left: 50px;
  position: relative;
  width: 238 * PX;
  height: 39 * PX;

  .ferris-base--main {
    background-color: #ce5250;
    rect: 100%;
    position: relative;
    z-index: 1;
    height: 0%;
    top: 100%;

    .is-open & {
      height: 100%;
      top: 0;
      transition: all ferrisWheelTransitionCoef linear;
    }
  }

  baseTopColor = #9b2e2e;
  topWidth = 108%;
  baseTopHeight = 12 * PX;

  top-height, .ferris-base--top {
    position: absolute;
    height: baseTopHeight;
    background-color: baseTopColor;
    z-index: 2;
    width: 0;
    margin-left: 50%;
    overflow: hidden;
    opacity: 0;

    .is-open & {
      width: topWidth;
      margin-left: -4%;
      overflow: visible;
      opacity: 1;
      transition: all ferrisWheelTransitionCoef linear;
      transition-delay: ferrisWheelTransitionCoef;
    }

    triangleWidth = 8 * PX;

    &:before, &:after {
      content: '';
      position: absolute;
      border: baseTopHeight solid rgba(baseTopColor, 0);
      border-left-width: triangleWidth;
      border-right-width: triangleWidth;
      border-top-color: baseTopColor;
      top: 0;
    }

    &:before {
      left: - triangleWidth;
    }

    &:after {
      right: - triangleWidth;
    }
  }

  baseSpikeHeight = 185 * PX;
  baseSpikeWidth = 15 * PX;

  .ferris-base--spike {
    height: baseSpikeHeight - 30 * PX;
    width: baseSpikeWidth;
    background-color: #b33333;
    position: absolute;
    top: - baseSpikeHeight + 23 * PX;
    left: 50%;
    margin-left: -(baseSpikeWidth / 2);
    transform-origin: 50% top;
    z-index: 0;
    height: (baseSpikeHeight / 2);
    opacity: 0;
    transition: all 0.45s ease-out;
    translateSize = baseSpikeHeight;

    &.is-1 {
      transform: rotate(90deg) translateX(translateSize);
    }

    &.is-2 {
      transform: rotate(-90deg) translateX((- translateSize));
    }

    .is-open & {
      rotateAngle = 19deg;
      transition: all (1.5 * ferrisWheelTransitionCoef) linear, opacity 0 linear;
      transition-delay: 2 * ferrisWheelTransitionCoef;
      height: baseSpikeHeight;
      opacity: 1;

      &.is-1 {
        transform: rotate(rotateAngle);
      }

      &.is-2 {
        transform: rotate((- rotateAngle));
      }
    }
  }

  .ferris-base--handle {
    circle: 30 * PX;
    background-color: #ff6d6a;
    position: absolute;
    left: 50%;
    margin-left: - 15 * PX;
    top: - baseSpikeHeight + 10 * PX;
    transform: scale(0);

    .is-open & {
      transform: scale(1);
      transition: all ferrisWheelTransitionCoef cubic-bezier(0.35, 1.65, 0.375, 0.79);
      transition-delay: 4 * ferrisWheelTransitionCoef;
    }

    size = 35%;

    &:after {
      content: '';
      circle: size;
      center-shift: size;
      background-color: #b72737;
    }
  }
}

spikeHeight = 38 * PX;
cabinSize = 44 * PX;
ferrisWheelSize = 375;

/* 4a3bad0ec6b13193efca6723a150cfba */
.ferris-wheel {
  rect: ferrisWheelSize * PX;
  z-index: 0;
  position: absolute;
  bottom: groundHeight + 14 * PX;
  left: 50%;
  margin-left: -190 * PX;

  .ferris-wheel--script-path {
    position: absolute;
    top: - 16 * gs;
    left: - 20 * gs;

    text {
      fill: #493542;
      font-size: 4 * gs;
    }
  }

  .ferris-wheel--core {
    animation-fill-mode: both;
    animation: ferris-wheel-rotate 30s linear infinite;
  }

  .cabin--core {
    animation-fill-mode: both;
    animation: ferris-cabin-rotate 30s linear infinite;
  }

  &.is-open {
    .ferris-base {
      transform: translateY(0);
      transition: all 0 linear;
    }

    .ferris-base--center {
      transform: scale(1);
      transition: all ferrisWheelTransitionCoef cubic-bezier(0.35, 1.65, 0.375, 0.79);
      transition-delay: 4.5 * ferrisWheelTransitionCoef;
    }

    .ferris-wheel--circle2 {
      transform: scale(1);
      transition: all ferrisWheelTransitionCoef cubic-bezier(0.35, 1.65, 0.375, 0.79);
      transition-delay: 5 * ferrisWheelTransitionCoef;
    }

    .ferris-wheel--circle1 {
      transform: scale(1);
      transition: all ferrisWheelTransitionCoef cubic-bezier(0.35, 1.65, 0.375, 0.79);
      transition-delay: 5.5 * ferrisWheelTransitionCoef;
    }

    .ferris-wheel--spike {
      transition: all ferrisWheelTransitionCoef linear;
      transition-delay: 6 * ferrisWheelTransitionCoef;
      height: spikeHeight;
      opacity: 1;
      spikeAngle = 60;
      spikesCircleSize = (ferrisWheelSize * 0.69);
      cnt = 24;
      PI = 3.141598;
      step = ((2 * PI) / cnt);
      rotateStep = (360 / cnt);
      rotateAngle = 0;
      centerX = (ferrisWheelSize / 2) - 1;
      centerY = (ferrisWheelSize / 2);
      radius = (spikesCircleSize / 2);
      angle = 0;

      for i in 0 .. (cnt - 1) {
        &.n-{i} {
          x = centerX + cos(angle) * radius;
          y = centerY + sin(angle) * radius;
          transform: translateX(x * PX) translateY(y * PX - (spikeHeight / 2)) rotate((rotateAngle - spikeAngle) deg);
          transform-origin: 50% 50%;
        }

        rotateAngle = rotateAngle + rotateStep;
        angle = angle + step;
      }

      rotateAngle = 0;
      angle = 0.16;

      for i in 0 .. (cnt - 1) {
        &.s-{i} {
          x = centerX + cos(angle) * radius;
          y = centerY + sin(angle) * radius;
          transform: translateX(x * PX) translateY(y * PX - (spikeHeight / 2)) rotate((rotateAngle + spikeAngle) deg);
          transform-origin: 50% 50%;
        }

        rotateAngle = rotateAngle + rotateStep;
        angle = angle + step;
      }
    }

    .cabin {
      opacity: 1;
      transition-duration: 0;
      cnt = 12;
      PI = 3.141598;
      step = ((2 * PI) / cnt);
      rotateStep = (360 / cnt);
      rotateAngle = 0;
      centerX = (ferrisWheelSize / 2);
      centerY = (ferrisWheelSize / 2);
      radius = (ferrisWheelSize / 2);
      angle = 0;

      .human {
        transition: top ferrisWheelTransitionCoef linear;
      }

      for i in 0 .. (cnt - 1) {
        &.n-{i} {
          .human-0 {
            top: - 5 * PX;
            right: 20%;
            transition-delay: 7 * ferrisWheelTransitionCoef + (random(0, 25) / 100);
          }

          .human-1 {
            top: - random(0, 5) * PX;
            right: 40%;
            transition-delay: 7 * ferrisWheelTransitionCoef + (random(0, 25) / 100);
          }

          .human-2 {
            top: - random(3, 7) * PX;
            right: 60%;
            transition-delay: 7 * ferrisWheelTransitionCoef + (random(0, 25) / 100);
          }
        }
      }
    }

    .cabin--handle {
      height: 40 * PX;
      transition: all ferrisWheelTransitionCoef linear;
      transition-delay: 6 * ferrisWheelTransitionCoef;
    }

    .cabin--core2 {
      transform: scale(1);
      transition: all ferrisWheelTransitionCoef linear;
      transition-delay: 6.5 * ferrisWheelTransitionCoef;
    }
  }

  .ferris-wheel--core {
    rect: 100%;
    position: absolute;
    transform-origin: 50% 50%;
  }

  .cabin--core {
    transform-origin: 50% 50%;
  }

  .ferris-base {
    position: absolute;
    z-index: 2;
    left: 20 * PX;
    bottom: - 15 * PX;
    transform: translateY(300px);
    transition: all ferrisWheelTransitionCoef line;
  }

  size = 115 * PX;

  .ferris-base--center {
    background-color: #ff6d6a;
    circle: size;
    transform: scale(0);
    z-index: 0;
    top: - 222 * PX;
    position: absolute;
    left: 50%;
    margin-left: -(size / 2);
    iconSize = 67.5%;

    .icon {
      position: absolute;
      fill: #fff;
      rect: iconSize;
      left: ((100% - iconSize) / 1.65);
      top: ((100% - iconSize) / 1.65);
    }
  }

  .ferris-wheel--spike {
    width: 3 * PX;
    height: 0;
    height: spikeHeight;
    background-color: #9a3333;
    position: absolute;
    z-index: 0;
    transform-origin: 50% 50%;
    opacity: 0;
    spikeAngle = 60;
    spikesCircleSize = (ferrisWheelSize * 0.69);
    cnt = 24;
    PI = 3.141598;
    step = ((2 * PI) / cnt);
    rotateStep = (360 / cnt);
    rotateAngle = 0;
    centerX = (ferrisWheelSize / 2) - 0;
    centerY = (ferrisWheelSize / 2);
    radius = (spikesCircleSize / 2) - 15;
    angle = 0;

    for i in 0 .. (cnt - 1) {
      &.n-{i} {
        x = centerX + cos(angle) * radius;
        y = centerY + sin(angle) * radius;
        transform: translateX(x * PX) translateY(y * PX - (spikeHeight / 2)) rotate(rotateAngle deg);
      }

      rotateAngle = rotateAngle + rotateStep;
      angle = angle + step;
    }

    rotateAngle = 0;
    angle = 0.16;

    for i in 0 .. (cnt - 1) {
      &.s-{i} {
        x = centerX + cos(angle) * radius;
        y = centerY + sin(angle) * radius;
        transform: translateX(x * PX) translateY(y * PX - (spikeHeight / 2)) rotate(rotateAngle deg);
      }

      rotateAngle = rotateAngle + rotateStep;
      angle = angle + step;
    }
  }

  circle1Size = 85%;

  .ferris-wheel--circle1 {
    position: absolute;
    circle: circle1Size;
    border: 17 * PX solid #c94a4a;
    left: ((100% - circle1Size) / 2);
    top: ((100% - circle1Size) / 2);
    z-index: 1;
    transform: scale(0);
    transition: all ferrisWheelTransitionCoef linear;
    transition-delay: ferrisWheelTransitionCoef;
  }

  circle2Size = 65%;

  .ferris-wheel--circle2 {
    position: absolute;
    circle: circle2Size;
    // border 10*PX solid #c94a4a
    border: 10 * PX solid white;
    left: ((100% - circle2Size) / 2);
    top: ((100% - circle2Size) / 2);
    z-index: 1;
    transform: scale(0);
    transition: all ferrisWheelTransitionCoef linear;
    transition-delay: 2 * ferrisWheelTransitionCoef;
  }

  .cabin {
    position: absolute;
    nw: 0;
    opacity: 1;

    // z-index 10
    .icon {
      fill: #3f797f;
    }
  }

  cnt = 12;
  PI = 3.141598;
  step = ((2 * PI) / cnt);
  rotateStep = (360 / cnt);
  rotateAngle = 0;
  centerX = (ferrisWheelSize / 2);
  centerY = (ferrisWheelSize / 2);
  radius = (ferrisWheelSize / 2);
  angle = 0;

  for i in 0 .. (cnt - 1) {
    .n-{i} {
      x = centerX + cos(angle) * radius;
      y = centerY + sin(angle) * radius;
      transform: translateX(x * PX - (cabinSize / 2)) translateY(y * PX - (cabinSize / 2));

      .cabin--handle {
        transform: rotate((90 + rotateAngle)deg);
        z-index: -1;
      }

      .human {
        position: absolute;
        top: 12 * PX;
      }

      .human-0 {
        right: 20%;
      }

      .human-1 {
        right: 40%;
      }

      .human-2 {
        right: 60%;
      }
    }

    .n-google-plus, .n-youtube, .n-quora {
      .icon {
        fill: #f46f53;
      }
    }

    .n-blogging {
      .icon {
        fill: #8fa2a8;
      }
    }

    rotateAngle = rotateAngle + rotateStep;
    angle = angle + step;
  }
}

.cabin {
  // border-radius 50%
  rect: cabinSize;
  position: relative;

  .cabin--core, .cabin--core2 {
    rect: 100%;
    position: absolute;
    nw: 0;
  }

  .cabin--core2 {
    transform: scale(0);
    transition: all ferrisWheelTransitionCoef linear;
    transition-delay: 0;
  }

  .human {
    z-index: 0;
    position: absolute;
  }

  iconSize = 60%;

  .icon {
    position: absolute;
    z-index: 2;
    rect: iconSize;
    left: ((100% - iconSize) / 2);
    top: ((100% - iconSize) / 2);
  }

  cabinHandleWidth = 18 * PX;

  .cabin--handle {
    background-color: #9a3333;
    width: cabinHandleWidth;
    position: absolute;
    left: 50%;
    top: 50%;
    margin-left: -(cabinHandleWidth / 2);
    z-index: 0;
    transform-origin: 50% top;
    height: 0;
  }

  .cabin--base {
    circle: cabinSize;
    position: absolute;
    background-color: white;
    z-index: 1;
  }
}

@-moz-document url-prefix() {
  .cabin {
    .human {
      animation: cabinFix 0.2s linear infinite;
    }
  }
}

@keyframes ferris-cabin-rotate {
  0% {
    transform: rotate(0);
  }

  100% {
    transform: rotate(360deg);
  }
}

@keyframes ferris-wheel-rotate {
  0% {
    transform: rotate(360deg);
  }

  100% {
    transform: rotate(0);
  }
}

@keyframes cabinFix {
  0% {
    transform: translateZ(0);
  }

  100% {
    transform: translateZ(1px);
  }
}

.inputMatch {
  padding: 10px;
  font-size: 30px;
  color: wheat;
}

#chat-button {
  background-color: #B4DBD9;
  margin: 32px 0 0 400px;
}
</style>