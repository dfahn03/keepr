<template>
  <div class="row home">
    <div class="col-12 container-fluid nbar p-0">
      <nav class="navbar navbar-dark p-1">
        <a class="navbar-brand" href="#">
          <img src="../assets/K-2.jpg" width="60" height="60" class="d-inline-block align-top" alt="">
          <h4 class="float-right mt-2 ml-1 site-title">KeepSake</h4>
        </a>
        <h1 v-if="user.id" class="home-title mt-2">Welcome {{user.username}}</h1>
        <div class="dropdown dropleft">
          <img src="../assets/Menu-Icon-40.png" alt="" title="Dropdown Menu" class="btn dropdown-toggle menuBtn"
            id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
          <div v-if="user.id" class="dropdown-menu" aria-labelledby="dropdownMenu2">
            <button class="dropdown-item" type="button" @click="logout">Logout</button>
            <button class="dropdown-item" type="button" @click="">Dashboard</button>
          </div>
          <div v-else class="dropdown-menu" aria-labelledby="dropdownMenu2">
            <button class="dropdown-item" type="button" @click="pushToLogin">Login</button>
          </div>
        </div>
      </nav>
    </div>

    <div class="col-12 mt-4">
      <div class="row">
        <div class="col-4" v-for="keep in keeps" :key="keep.id">
          <div class="card" style="width: 15rem;">
            <img :src="keep.img" class="card-img-top" alt="...">
            <div class="card-body">
              <h5 class="card-title">{{keep.name}}</h5>
              <p class="card-text">{{keep.description}}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "Home",
    mounted() {
      // this.$store.dispatch('getPublicKeeps');
      if (this.user.id) {
        this.$store.dispatch('getUserKeeps');
      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      // publicKeeps() {
      //     this.$store.dispatch('getPublicKeeps')
      // },
      keeps() {
        return this.$store.state.keeps;
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      },
      pushToLogin() {
        this.$router.push({ name: 'Login' });
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

  .nbar {
    height: 1vh;
  }

  .site-title {
    font-family: 'Lobster', cursive;
    font-size: 2rem;
    color: rgb(0, 174, 255);
  }

  .home-title {
    font-family: 'Acme', sans-serif;
    color: rgb(0, 174, 255);
    /* font-family: 'Yanone Kaffeesatz', sans-serif; */
  }

  .menuBtn {
    cursor: pointer;
  }
</style>