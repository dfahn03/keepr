<template>
  <div class="vault-keep container-fluid">
    <div class="row">
      <navigation />
    </div>
    <div class="row">
      <div class="col">
        <h1 class="v-nd mt-2">{{vault.name}}</h1>
        <h5 class="v-nd mt-2">{{vault.description}}</h5>
      </div>
    </div>
    <div class="card-columns mt-5">
      <div class="card" style="width: 18rem;" v-for="keep in vaultKeeps" :key="keep.id">
        <img :src="keep.img" class="card-img-top" alt="Keep Image">
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text">{{keep.description}}</p>
          <div class="row justify-content-center align-items-center">
            <div class="col-4 p-0 justify-content-center align-items-center">
              <img src="../assets/eye-25.png" alt="Views" class="float-left ml-4 mt-1" title="Views">
              <p class="card-text mb-0 mt-1">{{keep.shares}}</p>
            </div>
            <div class="col-4 p-0">
              <img src="../assets/share-25.png" alt="Views" class="float-left ml-4 mt-1" title="Shares">
              <p class="card-text mb-0 mt-1">{{keep.shares}}</p>
            </div>
            <div class="col-4 p-0">
              <img src="../assets/save-25.png" alt="Views" class="float-left ml-4 mt-1" title="Keeps">
              <p class="card-text mb-0 mt-1">{{keep.keeps}}</p>
            </div>
            <!-- TODO Beautify these counts -->
          </div>
          <div class="row justify-content-center mt-3">
            <img v-if="user.id == keep.userId && keep.isPrivate == true" src="../assets/Trash-Icon-26.png"
              alt="Trash Can" title="Remove Keep From Vault" class="delKBtn" @click="deleteKeepFromVault(keep.id)">
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import Navigation from "@/Components/Navigation.vue";

  export default {
    name: "VaultKeep",
    props: [],
    mounted() {
      this.$store.dispatch('getVaultKeeps', this.vault)
      this.$store.dispatch('getVaults', this.vault.id)
    },
    data() {
      return {}
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      vault() {
        return this.$store.state.vault
      },
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    methods: {
      deleteKeepFromVault() {
      },
    },
    components: {
      Navigation
    }
  }
</script>

<style scoped>
  .vault-keep {
    max-width: 100vw;
    min-height: 100vh;
    background-image: url("../assets/vk-bg.jpg");
    background-size: 100% 100%;
    background-position: center;
    background-attachment: fixed;
    background-size: cover;
    background-repeat: no-repeat;
    padding-top: 6%;
    padding-bottom: 10%;
  }

  .v-nd {
    /* font-family: 'Lobster', cursive; */
    font-family: 'Acme', sans-serif;
    text-shadow:
      -1px -1px 0 white,
      1px -1px 0 white,
      -1px 1px 0 white,
      1px 1px 0 white;
  }

  .card-columns {
    @include media-breakpoint-only(sm) {
      column-count: 1;
    }

    @include media-breakpoint-only(md) {
      column-count: 3;
    }

    @include media-breakpoint-only(lg) {
      column-count: 4;
    }

    @include media-breakpoint-only(xl) {
      column-count: 5;
    }
  }

  .card-columns {
    /* column-width: 325px; */
    columns: 5;
    column-gap: 0;
  }

  .card {
    display: inline-block;
    max-width: max-content;
    min-height: 380px;
    border-color: #000;
  }

  .card-body {
    background-color: #fff;
  }

  .card-img-top {
    width: 100%;
    max-width: 300px;
    max-height: 100%;
  }

  .delKBtn {
    cursor: pointer;
  }
</style>