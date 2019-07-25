<template>
  <div class="col home">
    <navigation />
    <h-p-keeps class="row" />
  </div>
</template>

<script>
  import Navigation from "@/Components/Navigation.vue";
  import HPKeeps from "@/Components/HPKeeps.vue";

  export default {
    name: "Home",
    computed: {},
    methods: {},
    components: {
      Navigation,
      HPKeeps
    }
  };
</script>

<style scoped>
  .home {
    min-width: 90vw;
    min-height: 100vh;
    background-image: url("../assets/home-bg-13.jpg");
    /* -webkit-background-size: contain;
    -moz-background-size: contain;
    -o-background-size: contain; */
    background-size: 100% 100%;
    background-attachment: fixed;
    background-position: center;
    background-size: cover;
    background-repeat: no-repeat;
  }
</style>