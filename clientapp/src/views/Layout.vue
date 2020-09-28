<template>
  <div>
    <Navbar />
    <router-view />
  </div>
</template>

<script>
import Navbar from "./Navbar";
export default {
  components: { Navbar },
  data() {
    return {};
  },
};
</script>

<style></style>
