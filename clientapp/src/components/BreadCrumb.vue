<template>
  <!-- <b-breadcrumb :items="items"></b-breadcrumb> -->
  <div class="breadcrumb">
    <ul>
      <li
        v-for="(breadcrumb, idx) in breadcrumbList"
        :key="idx"
        @click="routeTo(idx)"
        :class="{ linked: !!breadcrumb.link }"
      >
        {{ breadcrumb.name }}
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "Breadcrumb",
  data() {
    return {
      breadcrumbList: [],
    };
  },
  mounted() {
    this.updateList();
    console.log(this);
  },
  watch: {
    $route() {
      this.updateList();
    },
  },
  methods: {
    routeTo(pRouteTo) {
      if (this.breadcrumbList[pRouteTo].link)
        this.$router.push(this.breadcrumbList[pRouteTo].link);
    },
    updateList() {
      this.breadcrumbList = this.$route.meta.breadcrumb;
    },
  },
  //   data() {
  //     return {
  //       items: [
  //         {
  //           text: "Home",
  //           to: { name: "home" },
  //         },
  //         {
  //           text: "",
  //           href: "#bar",
  //         },
  //         // {
  //         //   text: "Library",
  //         //   href: "#bar",
  //         // },
  //       ],
  //     };
  //   },
};
</script>

<style scoped>
.breadcrumb {
  margin-bottom: line(3);
}
ul {
  display: flex;
  list-style: none;
  padding: 0;
  font-size: font(1);
}
li {
  cursor: pointer;
  color: #000;
}
li:last-child {
  cursor: default;
}
li:not(:last-child):after {
  content: ">";
  margin: 5px;
  color: #ddd;
}
</style>