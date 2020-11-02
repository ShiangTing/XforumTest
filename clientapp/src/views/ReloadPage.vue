<template>
  <div>

  </div>
</template>
<script>
export default {
  name: "ReloadPaage",
  beforeRouteEnter (to, from, next) {
    next(vm => {
      vm.$router.replace(from.path);
    });
  }
}
</script>