<template>
  <div class="row home">
    <h1 class="home-title">Welcome to Keepr {{user.username}}</h1>
    <button v-if="user.id" @click="logout" class="btn btn-sm btn-danger">Logout</button>
    <router-link v-else :to="{name: 'Login'}"><button type="button" class="btn btn-sm btn-success">Login</button>
    </router-link>
  </div>
</template>

<script>
  export default {
    name: "Home",
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      }
    }
  };
</script>

<style>
  /* .home-title {
    background-color: rgb(0, 110, 255);
  } */
</style>