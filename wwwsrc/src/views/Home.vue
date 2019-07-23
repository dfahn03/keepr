<template>
  <div class="home">
    <div class="row d-flex">
      <div class="col">
        <nav class="navbar navbar-light d-flex">
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
    </div>
    <div class="row">
      <div class="col">
        <!-- <div class="card" style="width: 18rem;">
          <img src="..." class="card-img-top" alt="...">
          <div class="card-body">
            <h5 class="card-title">Card title</h5>
            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's
              content.
            </p>
            <a href="#" class="btn btn-primary">Go somewhere</a>
          </div>
        </div> -->
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
  .site-title {
    font-family: 'Lobster', cursive;
    font-size: 2rem;
  }

  .home-title {
    /* font-family: 'Yanone Kaffeesatz', sans-serif; */
    font-family: 'Acme', sans-serif;
  }
</style>