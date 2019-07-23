<template>
  <div class="row home">
    <nav class="container-fluid navbar navbar-dark p-0 m-1">
      <a class="navbar-brand" href="#">
        <img src="../assets/K-2.jpg" width="60" height="60" class="d-inline-block align-top" alt="">
        <h4 class="float-right mt-2 ml-1 site-title">KeepSake</h4>
      </a>
      <h1 v-if="user.id" class="home-title">Welcome {{user.username}}</h1>
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

    <div class="container">

    </div>

    <div class="container-fluid mt-5">
      <div class="row justify-content-center">
        <div class="card m-3" style="width: 20rem;" v-for="keep in keeps" :key="keep.id">
          <img :src="keep.img" class="card-img-top" alt="">
          <div class="card-body">
            <h5 class="card-title">{{keep.name}}</h5>
            <p class="card-text">{{keep.description}}</p>
            <img v-if="user.id == keep.userId && keep.isPrivate == true" src="../assets/Trash-Icon-26.png" alt=""
              title="Delete Your Keep" class="delKBtn" @click="deleteYourKeep">

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
      this.$store.dispatch('getPublicKeeps');
      if (this.user.id) {
        this.$store.dispatch('getUserKeeps');
      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      publicKeeps() {
        this.$store.dispatch('getPublicKeeps')
      },
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
      },
      pushToDashboard() {
        this.$router.push({ name: 'Dashboard' })
      },
      deleteYourKeep() {
      }
    }
  };
</script>

<style>
  .home {
    /* height: 100%;
    width: 100%; */
    min-width: 90vw;
    min-height: 90vh;
    margin: 0px 0px;
    padding: 0px 0px;
    background-image: url("../assets/home-bg-3.jpg");
    -webkit-background-size: cover;
    -moz-background-size: cover;
    -o-background-size: cover;
    background-size: 100% 100%;
    background-position: center;
  }

  /* .nbar {
    height: 1vh;
  } */

  .site-title {
    font-family: 'Lobster', cursive;
    font-size: 2rem;
    color: rgb(0, 174, 255);
  }

  .home-title {
    font-family: 'Acme', sans-serif;
    color: rgb(0, 174, 255);
    margin-left: 30rem;
  }

  .menuBtn {
    cursor: pointer;
  }

  form {
    margin-left: 15rem;
  }

  .searchBtn {
    color: rgb(0, 174, 255);
    border-color: rgb(0, 174, 255);
  }

  .delKBtn {
    cursor: pointer;
  }
</style>