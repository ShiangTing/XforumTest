<template>
  <div id="app">
    <router-view v-if="routerAlive" />
  </div>
</template> 
<script> 
export default {
  data () {
    return { routerAlive: true }
  },
  provide () {
    return { routerRefresh: this.routerRefresh }
  },
  methods: {
    routerRefresh () {
      this.routerAlive = false;
      this.$nextTick(() => { this.routerAlive = true; });
    },
  }
}

</script>

<style lang="scss">
  @import "@/assets/scss/style.scss";
</style>