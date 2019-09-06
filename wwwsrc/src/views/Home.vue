<template>
  <div class="home container-fluid">
    <div class="row">
      <navigation />
    </div>
    <div class="row">
      <home-keeps />
    </div>

  </div>
</template>

<script>
  import Navigation from "@/Components/Navigation.vue";
  import HomeKeeps from "@/Components/HomeKeeps.vue";

  export default {
    name: "Home",
    components: {
      Navigation,
      HomeKeeps
    }
  };
</script>

<style scoped>
  .home {
    max-width: 100vw;
    min-height: 100vh;
    background-image: url("../assets/home-bg-13.jpg");
    background-size: 100% 100%;
    background-attachment: fixed;
    background-position: center;
    background-size: cover;
    background-repeat: no-repeat;
    padding-bottom: 2%;
  }
</style>