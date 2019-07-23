<template>
  <div class="row home">
    <nav class="container-fluid navbar navbar-dark p-0 m-1">
      <a class="navbar-brand" href="#">
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

    <div class="container">

    </div>

    <div class="container-fluid mt-5">
      <div class="row justify-content-center">
        <div class="card m-3" style="width: 20rem;" v-for="keep in keeps" :key="keep.id">
          <img :src="keep.img" class="card-img-top" alt="">
          <div class="card-body">
            <h5 class="card-title">{{keep.name}}</h5>
            <p class="card-text">{{keep.description}}</p>
            <div class="row justify-content-center">
              <div class="col-2 dropdown mr-1">
                <img src="../assets/Add-Icon-Green-30.png" alt="" title="Add to Vault"
                  class="btn dropdown-toggle vaultDropBtn" id="dropdownMenu2" data-toggle="dropdown"
                  aria-haspopup="true" aria-expanded="false">
                <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                  <button class="dropdown-item" type="button" v-for="vault in vaults" :key="vault.id"
                    @click="">{{vault.name}}</button>
                </div>
              </div>
              <div class="col-2">
                <img src="../assets/Share-Icon-30.png" alt="" title="Share Keep" class="shareKBtn ml-2" @click="">
              </div>
              <div class="col-2">
                <img v-if="user.id == keep.userId && keep.isPrivate == true" src="../assets/Trash-Icon-26.png" alt=""
                  title="Delete Keep" class="delKBtn ml-2" @click="deleteKeep(keep.id)">
              </div>
            </div>


            <!-- <img src="../assets/Add-Icon-Green-30.png" alt="" title="Save Keep to Vault" class="saveKBtn" @click=""> -->

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
      keeps() {
        return this.$store.state.keeps;
      },
      vaults() {
        return this.$store.state.vaults;
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
      deleteKeep(keepId) {
        this.$store.dispatch('deleteKeep', keepId);
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
    /* margin-left: 30rem; */
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

  .delKBtn {
    margin-top: 6px;
    cursor: pointer;
  }

  .shareKBtn {
    margin-top: 5px;
    cursor: pointer;
  }

  /* .vaultDropKBtn {
    cursor: pointer;
  } */
</style>