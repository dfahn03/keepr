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
      <div class="card m-0 p-0" style="width: 18rem;" v-for="keep in vaultKeeps" :key="keep.id">
        <img :src="keep.img" class="card-img" alt="Keep Image">
        <div class="card-body">
          <h5 class="card-title" @click="">{{keep.name}}</h5>
          <!-- TODO Have this open a modal with all the details of the keep -->
          <div class="row justify-content-center align-items-center">
            <div class="col-3 p-0 justify-content-center align-items-center">
              <img src="../assets/eye-25.png" alt="Views" class="float-left ml-2 mt-1" title="Views">
              <p class="card-text mb-0 mt-1">{{keep.views}}</p>
            </div>
            <div class="col-3 p-0">
              <img src="../assets/share-25.png" alt="Views" class="float-left ml-2 mt-1" title="Shares">
              <p class="card-text mb-0 mt-1">{{keep.shares}}</p>
            </div>
            <div class="col-3 p-0">
              <img src="../assets/Pin-Icon-22.png" alt="Views" class="float-left ml-2 mt-1" title="Keeps">
              <p class="card-text mb-0 mt-1">{{keep.keeps}}</p>
            </div>
          </div>
          <div class="row justify-content-center mt-2">
            <button class="btn btn-sm ml-1 btn-success"><img src="../assets/Share-Icon-12.png" class="mb-1">
              Share</button>
            <button class="btn btn-sm ml-1 btn-secondary" title="Remove From Vault">Remove</button>
            <button class="btn btn-sm ml-1 btn-danger" v-if="user.id == keep.userId && keep.isPrivate == true"
              @click="deleteKeep(keep.id)" title="Permanently Delete"><img src="../assets/Delete-Icon-12.png">
              Delete</button>
          </div>
        </div>
      </div>

      <!-- <div class="card m-0" style="width: 18rem;" v-for="keep in vaultKeeps" :key="keep.id">
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
          </div>
          <div class="row mt-3">
            <div class="col-5 d-flex justify-content-end align-items-center"><img src="../assets/share-black-30.png"
                alt="" title="Share Keep" class="shareKBtn" @click=""></div>
            <div class="col-2"><img v-if="user.id == keep.userId && keep.isPrivate == true"
                src="../assets/remove-30.png" alt="Trash Can" title="Remove Keep From Vault" class="delKBtn"
                @click="deleteKeepFromVault(keep.id)"></div>
            <div class="col-5 d-flex justify-content-start align-items-center">
              <img v-if="user.id == keep.userId && keep.isPrivate == true" src="../assets/Trash-Icon-26.png" alt=""
                title="Delete Keep" class="delKBtn ml-2" @click="deleteKeep(keep.id)">
            </div>


            TODO Set this button up
          </div>
        </div>
      </div> -->

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
        //TODO Set this up
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
    columns: 5;
    column-gap: 0;
  }

  .card {
    display: inline-block;
    max-width: max-content;
    border: none;
  }

  .card-img {
    opacity: 1;
    width: 100%;
    height: auto;
    transition: .5s ease;
    backface-visibility: hidden;
  }

  .card-body {
    transition: .5s ease;
    opacity: 0;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    -ms-transform: translate(-50%, -50%);
    text-align: center;
    background-color: rgba(253, 253, 253, 0.418);
    color: rgb(0, 0, 0);
    font-size: 20px;
    background-size: contain;
    min-width: 17rem;
  }

  .card:hover .card-img {
    opacity: 0.5;
  }

  .card:hover .card-body {
    opacity: 1;
  }
</style>