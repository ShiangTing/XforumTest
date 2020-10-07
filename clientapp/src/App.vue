<template>
  <div>
    <router-view />
  </div>
</template>

<script>
export default {
  data() {
    return {};
  },
  created() {
    console.log(process.env.VUE_APP_API);
  },
};
</script>
