<template>
    <div>
        <Navbar />
        <b-row class="text-center">
        <b-col></b-col>
        <b-col cols="8"></b-col>
        <b-col></b-col>
        </b-row>
    </div>
</template>

<script>
export default {
    components: {
        Navbar: () => import("@/components/common/Navbar"),
    },
};
</script>

<style lang="scss" scoped>
</style>