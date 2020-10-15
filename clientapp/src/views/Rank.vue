<template>
  <div>
    <Navbar />
    <div class="container">
      <div class="row">
        <h2 class="pt-3 m-auto d-block">購買稱號</h2>
        <div class="d-block">
          <a href="#" class="badge badge-dark">小學生</a>
          <a href="#" class="badge badge-dark">中學生</a>
          <a href="#" class="badge badge-dark">大學生</a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from "../components/common/Navbar";
export default {
  components: { Navbar },
};
</script>

<style>
</style>