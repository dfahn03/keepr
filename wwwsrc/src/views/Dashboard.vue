<template>
  <div class="row dashboard">

    <nav class="container-fluid navbar navbar-dark p-0 m-1">
      <a class="navbar-brand" href="#" @click="pushToHome">
        <img src="../assets/K-2.jpg" width="60" height="60" class="d-inline-block align-top" alt="">
        <h4 class="float-right mt-2 ml-1 site-title">KeepSake</h4>
      </a>
      <h1 v-if="user.id" class="home-title mt-2">{{user.username}}'s Dashboard</h1>
      <div class="dropdown dropleft">
        <img src="../assets/Menu-Icon-40.png" alt="" title="Dropdown Menu" class="btn dropdown-toggle menuBtn"
          id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        <div v-if="user.id" class="dropdown-menu" aria-labelledby="dropdownMenu2">
          <button class="dropdown-item" type="button" @click="logout">Logout</button>
        </div>
        <div v-else class="dropdown-menu" aria-labelledby="dropdownMenu2">
          <button class="dropdown-item" type="button" @click="pushToLogin">Login</button>
        </div>
      </div>
    </nav>

    <div class="container controls d-flex justify-content-center">
      <div class="row">
        <button class="btn v-create" type="button" data-toggle="modal" data-target="#createVaultModal"
          title="Create Vault">
          <img src="../assets/Add-Icont-BBW-25.png" alt="Add Vault" title="Create a Vault" class="mt-1">
          <h3 class="float-right text-white">Vault</h3>
        </button>
        <button class="btn v-keep ml-5" type="button" data-toggle="modal" data-target="#createKeepModal"
          title="Create Keep">
          <img src="../assets/Add-Icont-BBW-25.png" alt="Add Vault" title="Create a Vault" class="mt-1">
          <h3 class="float-right text-white">Keep</h3>
        </button>
      </div>
      <vault-modal />
      <keep-modal />
    </div>


    <!-- <div class="container-fluid">
      <div class="row justify-content-center">
        <div class="card v-card" style="width: 18rem;">
          <img src="" class="" alt="">
          <div class="card-body">
            <h5 class="card-title">{{vault.name}}</h5>
            <p class="card-text">
            </p>
            <a href="#" class="btn btn-primary"></a>
          </div>
        </div>
      </div>
    </div> -->

  </div>
</template>

<script>
  import VaultModal from "@/Components/VaultModal.vue";
  import KeepModal from "@/Components/KeepModal.vue";

  export default {
    name: "Dashboard",
    data() {
      return {}
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      vaults() {
        return this.$store.state.vaults
      }
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
    },
    components: {
      VaultModal,
      KeepModal
    }
  }
</script>

<style scoped>
  .dashboard {
    min-width: 100vw;
    min-height: 100vh;
    margin: 0px 0px;
    padding: 0px 0px;
    background-image: url("../assets/dashboard-bg-3.jpg");
    -webkit-background-size: cover;
    -moz-background-size: cover;
    -o-background-size: cover;
    background-size: 100% 100%;
    background-position: center;
  }

  .controls {
    max-height: 10vh;
  }

  .navbar {
    height: 10vh;
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
    /* color: white; */
    text-shadow:
      -1px -1px 0 #000,
      1px -1px 0 #000,
      -1px 1px 0 #000,
      1px 1px 0 #000;
    margin-right: 7rem;
  }

  .menuBtn {
    cursor: pointer;
  }
</style>