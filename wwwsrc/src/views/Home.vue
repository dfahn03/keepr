<template>
  <div class="row home">
    <div class="col-12 p-0">
      <nav class="navbar navbar-dark p-1">
        <a class="navbar-brand" href="#">
          <img src="../assets/K-2.jpg" width="60" height="60" class="d-inline-block align-top" alt="">
          <h4 class="float-right mt-2 ml-1 site-title">KeepSake</h4>
        </a>
        <h1 class="home-title mt-2">Welcome {{user.username}}</h1>
        <button v-if="user.id" @click="logout" class="btn btn-sm btn-danger">Logout</button>
        <router-link v-else :to="{name: 'Login'}"><button type="button" class="btn btn-sm btn-success">Login</button>
        </router-link>
      </nav>
    </div>

    <div class="col">
      <div class="card" style="width: 18rem;">
        <img src="" class="card-img-top" alt="...">
        <div class="card-body">
          <h5 class="card-title">Card title</h5>
          <p class="card-text"> </p>
        </div>
      </div>
    </div>
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
  .home {
    /* height: 100%;
    width: 100%; */
    min-width: 100vw;
    min-height: 100vh;
    margin: 0px 0px;
    padding: 0px 0px;
    background-image: url("../assets/home-bg-2.jpg");
    -webkit-background-size: cover;
    -moz-background-size: cover;
    -o-background-size: cover;
    background-size: 100% 100%;
    background-position: center;
  }

  .site-title {
    font-family: 'Lobster', cursive;
    font-size: 2rem;
  }

  .home-title {
    font-family: 'Acme', sans-serif;
    color: white;
    /* font-family: 'Yanone Kaffeesatz', sans-serif; */
  }
</style>