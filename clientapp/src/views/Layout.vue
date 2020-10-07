<template>
  <div>
    <Navbar />
    <!-- <BreadCrumb /> -->
    <router-view />
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar";
// import BreadCrumb from "../components/BreadCrumb";
export default {
  components: { Navbar },
  data() {
    return {};
  },
};
</script>

<style lang="scss">
@import "../assets/scss/style.scss";
</style>
