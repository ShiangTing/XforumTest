<template>
  <div>
    <h1>products</h1>
    <h1>{{ id }}</h1>
  </div>
</template>

<script>
const productItem = { 18: "shoes", 20: "book", 25: "abc" };

export default {
  computed: {
    id() {
      return productItem[this.$route.params.id];
    },
  },
};
</script>
