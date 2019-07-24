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
        <vault-modal />
        <keep-modal />
      </div>
    </div>

    <div class="container-fluid">
      <div class="row justify-content-center">
        <div class="card v-card ml-3 mt-3" style="width: 15rem;" v-if="vault.userId == user.id" v-for="vault in vaults"
          :key="vault.id">
          <div class="card-body">
            <h5 class="card-title">{{vault.name}}</h5>
            <p class="card-text">{{vault.description}}</p>
            <img v-if="vault.userId == user.id" src="../assets/Trash-Icon-26.png" alt="" title="Delete Vault"
              class="delVBtn ml-2" @click="deleteVault(vault.id)">
          </div>
        </div>
      </div>
    </div>

    <div class="container-fluid mt-5">
      <div class="row justify-content-center">
        <div class="card m-3" style="width: 12rem;" v-if="keep.userId == user.id" v-for="keep in keeps" :key="keep.id">
          <img :src="keep.img" class="card-img-top" alt="">
          <div class="card-body">
            <h5 class="card-title">{{keep.name}}</h5>
            <p class="card-text">{{keep.description}}</p>
            <div class="row justify-content-center">
              <div class="dropdown mr-1">
                <img src="../assets/Add-Icon-Green-30.png" alt="" title="Add to Vault" class="btn dropdown-toggle"
                  id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                  <button class="dropdown-item" type="button" v-if="vault.userId == user.id" v-for="vault in vaults"
                    :key="vault.id" @click="addKeepToVault(keep.id, vault.id)">{{vault.name}}</button>
                </div>
              </div>
              <div>
                <img src="../assets/Share-Icon-30.png" alt="" title="Share Keep" class="shareKBtn" @click="">
              </div>
              <div>
                <img v-if="user.id == keep.userId && keep.isPrivate == true" src="../assets/Trash-Icon-26.png" alt=""
                  title="Delete Keep" class="delKBtn ml-3" @click="deleteKeep(keep.id)">
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

  </div>
  </div>
</template>

<script>
  import VaultModal from "@/Components/VaultModal.vue";
  import KeepModal from "@/Components/KeepModal.vue";

  export default {
    name: "Dashboard",
    mounted() {
      this.$store.dispatch('getVaults');
      // this.$store.dispatch('getPublicKeeps');
      if (this.user.id) {
        this.$store.dispatch('getUserKeeps');
      }
    },
    data() {
      return {}
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      vaults() {
        return this.$store.state.vaults
      },
      keeps() {
        return this.$store.state.keeps
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
      deleteVault(vaultId) {
        this.$store.dispatch('deleteVault', vaultId);
      },
      deleteKeep(keepId) {
        this.$store.dispatch('deleteKeep', keepId);
      },
      addKeepToVault(kId, vId) {
        this.$store.dispatch('addKeepToVault', kId, vId)
        //TODO Set this up in the store
      }
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
    margin-right: 4rem;
  }

  .menuBtn {
    cursor: pointer;
  }

  .delVBtn {
    cursor: pointer;
  }

  .delKBtn {
    margin-top: 6px;
    cursor: pointer;
  }

  .shareKBtn {
    margin-top: 6px;
    cursor: pointer;
  }

  .dropdown {
    cursor: pointer;
  }
</style>