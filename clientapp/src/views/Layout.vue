<template>
  <div>
    <Navbar />
    <router-view />
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar";
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
