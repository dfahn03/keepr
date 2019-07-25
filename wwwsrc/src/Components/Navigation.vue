<template>
  <div class="row navigation">
    <nav class="container-fluid navbar navbar-dark p-0 m-1">
      <a class="navbar-brand" href="#" @click="pushToHome">
        <img src="../assets/K-2.jpg" width="60" height="60" class="d-inline-block align-top" alt="">
        <h4 class="float-right mt-2 ml-1 site-title">KeepSake</h4>
      </a>
      <h1 v-if="user.id" class="home-title mt-2">Welcome {{user.username}}</h1>
      <form class="form-inline my-2 my-lg-0" @submit.prevent="">
        <input class="form-control mr-sm-2 text-center" type="search" placeholder="Search" aria-label="Search">
        <button class="btn searchBtn my-2 my-sm-0" type="submit">Search</button>
      </form>
      <div class="dropdown dropleft">
        <img src="../assets/Menu-Icon-40.png" alt="" title="Dropdown Menu" class="btn dropdown-toggle menuBtn"
          id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        <div v-if="user.id" class="dropdown-menu" aria-labelledby="dropdownMenu2">
          <button class="dropdown-item" type="button" @click="logout">Logout</button>
          <button class="dropdown-item" type="button" @click="pushToDashboard">Dashboard</button>
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
    props: [],
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
  .site-title {
    font-family: 'Lobster', cursive;
    font-size: 2rem;
    color: rgb(0, 174, 255);
    /* color: white; */
    text-shadow:
      -1px -1px 0 #000,
      1px -1px 0 #000,
      -1px 1px 0 #000,
      1px 1px 0 #000;
  }

  .home-title {
    font-family: 'Acme', sans-serif;
    color: rgb(0, 174, 255);
    /* color: white; */
    text-shadow:
      -1px -1px 0 #000,
      1px -1px 0 #000,
      -1px 1px 0 #000,
      1px 1px 0 #000;
    margin-left: 25rem;
  }

  .menuBtn {
    cursor: pointer;
  }

  /* form {
    margin-left: 15rem;
    justify-content: flex-end;
  } */

  .searchBtn {
    color: rgb(0, 174, 255);
    border-color: rgb(0, 174, 255);
  }
</style>