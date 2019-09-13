<template>
  <div class="navigation col justify-content-center p-0">
    <nav class="navbar fixed-top navbar-dark p-1">
      <a class="navbar-brand" href="#" @click="pushToHome">
        <img src="../assets/K-2.jpg" width="60" height="60" class="d-inline-block align-top" alt="">
        <h4 class="float-right mt-2 ml-1 site-title">KeepSake</h4>
      </a>
      <h1 v-if="user.id && $route.name == 'Dashboard'" class="home-title mt-2">{{user.username}}'s Dashboard</h1>
      <h1 v-else-if="user.id && $route.name == 'Home'" class="home-title mt-2">Public Keeps</h1>
      <h1 v-else-if="user.id && $route.name == 'VaultKeep'" class="home-title mt-2">VaultKeep</h1>
      <h1 v-else class="home-title mt-2">Welcome</h1>
      <div class="dropdown dropleft">
        <img src="../assets/Menu-Icon-40.png" alt="" title="Dropdown Menu" class="btn dropdown-toggle menuBtn"
          id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        <div v-if="user.id" class="dropdown-menu" aria-labelledby="dropdownMenu2">
          <button class="dropdown-item" type="button" @click="logout">Logout</button>
          <button class="dropdown-item" type="button" @click="pushToDashboard"
            v-if="$route.name != 'Dashboard'">Dashboard</button>
          <button class="dropdown-item" type="button" @click="pushToHome" v-if="$route.name != 'Home'">Home</button>
        </div>
        <div v-else class="dropdown-menu" aria-labelledby="dropdownMenu2">
          <button class="dropdown-item" type="button" @click="pushToLogin">Login</button>
        </div>
      </div>
    </nav>
  </div>
</template>

<script>
  export default {
    name: "Navigation",
    data() {
      return {}
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      },
      pushToLogin() {
        this.$router.push({ name: 'Login' });
      },
      pushToHome() {
        if (this.route != 'Home') {
          this.$router.push({ name: 'Home' });
        }
      },
      pushToDashboard() {
        this.$router.push({ name: 'Dashboard' })
      },
    },
    components: {}
  }
</script>

<style scoped>
  .navbar {
    background-color: rgba(255, 255, 255, 0.699);
  }

  .site-title {
    font-family: 'Lobster', cursive;
    font-size: 2rem;
    color: rgb(0, 174, 255);
    text-shadow:
      -1px -1px 0 #000,
      1px -1px 0 #000,
      -1px 1px 0 #000,
      1px 1px 0 #000;
  }

  .home-title {
    font-family: 'Acme', sans-serif;
    color: rgb(0, 174, 255);
    text-shadow:
      -1px -1px 0 #000,
      1px -1px 0 #000,
      -1px 1px 0 #000,
      1px 1px 0 #000;
    margin-right: 9rem;
  }

  .menuBtn {
    cursor: pointer;
  }
</style>