<template>
  <div>
    <b-breadcrumb :items="items"></b-breadcrumb>
    <b-container fluid>
      <b-row class="">
        <b-col>
          <b-list-group style="max-width: 250px;">
            <b-list-group-item>
              <!-- <b-avatar class="mr-3"></b-avatar> -->
              <font-awesome-icon icon="coffee" size="lg" />
              <router-link :to="`/${courses[0].id}`">心情閒聊版</router-link>
              <!-- <span></span> -->
              <!-- <b-badge>5</b-badge> -->
            </b-list-group-item>
            <b-list-group-item>
              <!-- <b-avatar variant="primary" text="Talk Shit" class="mr-3"></b-avatar> -->
              <font-awesome-icon icon="angry" size="lg" />
              <span>新書怒灌區</span>
            </b-list-group-item>
            <b-list-group-item>
              <img :src="detective" style="width:20px" />
              <span class="">偵探區</span>
            </b-list-group-item>
          </b-list-group>
        </b-col>
        <b-col cols="8">
          <div>
            <router-view />
            <p>全部 / 追蹤</p>
            <div style="border:solid 1px red ;display:flex">
              <div style="padding:30px 20px">
                <font-awesome-icon icon="user" size="lg" />
                <span>Account</span>
                <h2>Title</h2>
                <p>
                  Lorem ipsum dolor sit amet consectetur, adipisicing elit.
                  Minus odit excepturi dicta blanditiis obcaecati dolores
                  assumenda. Fugiat, unde quidem magnam quis, tempore sit
                  molestiae at esse, perferendis provident excepturi mollitia?
                </p>
              </div>
              <img
                style="padding:30px 20px"
                src="https://picsum.photos/50/50/?image=3"
                alt=""
              />
            </div>
          </div>
        </b-col>
        <b-col> </b-col>
      </b-row>
    </b-container>

    <vue-particles
      color="#dedede"
      :particleOpacity="0.7"
      :particlesNumber="80"
      shapeType="circle"
      :particleSize="4"
      linesColor="#dedede"
      :linesWidth="1"
      :lineLinked="true"
      :lineOpacity="0.4"
      :linesDistance="150"
      :moveSpeed="5"
      :hoverEffect="true"
      hoverMode="grab"
      :clickEffect="false"
      clickMode="push"
    >
    </vue-particles>
  </div>
</template>

<script>
import detectiveImg from "../assets/img/detective.png";

export default {
  data() {
    return {
      detective: detectiveImg,

      courses: [
        {
          id: 1,
          // img: img1,
          name: "心情閒聊版",
          routeName: "SecretGarden",
        },
        {
          id: 2,
          // img: img2,
          name: "新書怒灌區",
          routeName: "Talk",
        },
        {
          id: 3,
          // img: img3,
          name: "偵探區",
          routeName: "Detective",
        },
      ],

      items: [
        {
          text: "Home",
          to: { name: "home" },
        },
        {
          text: "Manage",
          href: "#bar",
        },
        {
          text: "Library",
          href: "#bar",
        },
      ],
    };
  },
};
</script>

<style lang="scss"></style>
