<template>
  <div class="col dashboard">
    <navigation />

    <div class="row controls d-flex justify-content-center align-items-center">
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

    <div class="row justify-content-center align-items-center mb-5">
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

    <dash-keeps class="row" />

  </div>
</template>

<script>
  import VaultModal from "@/Components/VaultModal.vue";
  import KeepModal from "@/Components/KeepModal.vue";
  import Navigation from "@/Components/Navigation.vue";
  import DashKeeps from "@/Components/DashKeeps.vue";

  export default {
    name: "Dashboard",
    mounted() {
      this.$store.dispatch('getVaults');
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
    },
    methods: {
      deleteVault(vaultId) {
        this.$store.dispatch('deleteVault', vaultId);
      },
    },
    components: {
      VaultModal,
      KeepModal,
      Navigation,
      DashKeeps
    }
  }
</script>

<style scoped>
  .dashboard {
    min-width: 90vw;
    min-height: 100vh;
    background-image: url("../assets/dashboard-bg-3.jpg");
    /* -webkit-background-size: cover;
    -moz-background-size: cover;
    -o-background-size: cover; */
    background-size: 100% 100%;
    background-position: center;
    background-attachment: fixed;
    background-size: cover;
    background-repeat: no-repeat;
  }

  .controls {
    max-height: 10vh;
  }
</style>