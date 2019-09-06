<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <navigation />
    </div>

    <div class="row controls d-flex justify-content-center align-items-center">
      <button class="btn v-keep" type="button" data-toggle="modal" data-target="#createKeepModal" title="Create Keep">
        <img src="../assets/Add-Icont-BBW-25.png" alt="Add Vault" title="Create a Vault" class="mt-1">
        <h3 class="float-right text-white">Keep</h3>
      </button>
      <button class="btn v-create ml-5" type="button" data-toggle="modal" data-target="#createVaultModal"
        title="Create Vault">
        <img src="../assets/Add-Icont-BBW-25.png" alt="Add Vault" title="Create a Vault" class="mt-1">
        <h3 class="float-right text-white">Vault</h3>
      </button>
      <create-keep-modal />
      <create-vault-modal />
    </div>

    <div class="row justify-content-center align-items-center mb-5">
      <div class="card v-card ml-3 mt-3" style="width: 15rem;" v-if="vault.userId == user.id" v-for="vault in vaults"
        :key="vault.id">
        <div class="card-body">
          <h5 class="card-title" @click="openVault(vault)">{{vault.name}}</h5>
          <p class="card-text" @click="openVault(vault)">{{vault.description}}</p>
          <button class="btn btn-sm ml-1 btn-secondary" v-if="user.id == vault.userId" data-toggle="modal"
            data-target="#editVaultModal" @click="setActiveVault(vault)"><img src="../assets/Edit-Icon-12.png"
              class="mr-1 editBtn">Edit</button>
          <button class="btn btn-sm btn-secondary ml-1" @click="deleteVault(vault.id)"><img
              v-if="vault.userId == user.id" src="../assets/Delete-Icon-X-12.png" class="delVBtn mr-1">Delete</button>
        </div>
      </div>
    </div>

    <edit-vault-modal />

    <div class="row">
      <dash-keeps />
    </div>

  </div>
</template>

<script>
  import Navigation from "@/Components/Navigation.vue";
  import CreateKeepModal from "@/Components/CreateKeepModal.vue";
  import CreateVaultModal from "@/Components/CreateVaultModal.vue";
  import EditVaultModal from "@/Components/EditVaultModal.vue";
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
      vault() {
        return this.$store.state.vault
      }
    },
    methods: {
      deleteVault(vaultId) {
        this.$store.dispatch('deleteVault', vaultId);
      },
      openVault(vault) {
        this.$store.dispatch('setActiveVault', vault)
        let vaultId = vault.id
        this.$router.push({ name: 'VaultKeep', params: { vaultId } })
      },
      setActiveVault(vault) {
        this.$store.dispatch('setActiveVault', vault)
      }
    },
    components: {
      Navigation,
      CreateKeepModal,
      CreateVaultModal,
      EditVaultModal,
      DashKeeps
    }
  }
</script>

<style scoped>
  .dashboard {
    max-width: 100vw;
    min-height: 100vh;
    background-image: url("../assets/dashboard-bg-3.jpg");
    background-size: 100% 100%;
    background-position: center;
    background-attachment: fixed;
    background-size: cover;
    background-repeat: no-repeat;
    padding-bottom: 2%;
  }

  .controls {
    margin-top: 5%;
    max-height: 10vh;
  }

  .card-title:hover,
  .card-text:hover {
    color: blue;
    cursor: pointer;
  }

  .editBtn {
    margin-bottom: 2px;
  }
</style>