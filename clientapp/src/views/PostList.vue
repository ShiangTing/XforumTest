<template>
  <div>
    <Navbar />
    <div class="container py-5">
      <div class="row justify-content-center">
        <div class="col-9">
          <div class="card">
            <div class="card-body">
              <h5 class="card-title">標題</h5>
              <h6 class="card-subtitle mb-2 text-muted">作者: 132</h6>
              <hr>
              <p class="card-text">Lorem ipsum dolor sit amet consectetur adipisicing elit. Vel, expedita unde. Minima perspiciatis ut impedit harum illum accusantium tenetur iste temporibus quisquam earum id incidunt dignissimos rerum modi, unde eveniet.</p>
              <img src="https://fakeimg.pl/700x900/123">
            </div>
          </div>
          <div class="card message">
            
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
import Navbar from "../components/common/Navbar"
export default {
  components: { Navbar },
  data () {
    return {

    };
  },
}
</script>
<style lang="scss" scoped>
</style>