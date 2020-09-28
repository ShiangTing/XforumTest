<template>
  <div class="hero-wrap js-fullheight">
    <div class="overlay"></div>
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
      :moveSpeed="3"
      :hoverEffect="true"
      hoverMode="grab"
      :clickEffect="true"
      clickMode="push"
    >
    </vue-particles>
    <div class="container">
      <div
        class="row no-gutters slider-text align-items-center justify-content-center"
        data-scrollax-parent="true"
      >
        <div
          class="col-md-6 ftco-animate text-center"
          data-scrollax=" properties: { translateY: '70%' }"
        >
          <h1
            class="mb-4"
            data-scrollax="properties: { translateY: '30%', opacity: 1.6 }"
          >
            We love to create <strong>Beautiful</strong> websites
          </h1>
          <p data-scrollax="properties: { translateY: '30%', opacity: 1.6 }">
            <a href="#" class="btn btn-primary btn-outline-white px-5 py-3"
              >Get in touch</a
            >
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// import particles from '../assets/js/particle'
export default {};
</script>

<style lang="scss" scoped>
@import "../assets/scss/style.scss";
</style>
