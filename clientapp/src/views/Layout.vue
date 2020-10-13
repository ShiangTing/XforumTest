<template>
  <div>
    <Navbar />
    <!-- <BreadCrumb /> -->
    <router-view :key="$route.path" />
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
