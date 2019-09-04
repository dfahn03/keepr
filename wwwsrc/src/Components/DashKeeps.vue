<template>
  <div class="dash-keeps container-fluid">
    <div class="card-columns">

      <div class="card m-0 p-0" v-if="keep.userId == user.id" v-for="keep in keeps" :key="keep.id">
        <img :src="keep.img" class="card-img" alt="Keep Image">
        <div class="card-body">
          <h5 class="card-title" data-toggle="modal" data-target="#KeepsDetailModal" @click="setActiveKeep(keep)">
            {{keep.name}}</h5>
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
          <div class="dropdown mr-1 mt-2">
            <button class="btn dropdown btn-sm ml-1 btn-primary" id="dropdownMenu2" data-toggle="dropdown"
              aria-haspopup="true" aria-expanded="false"><img src="../assets/Pin-Icon-12.png" class="mb-1">
              Save</button>
            <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
              <button class="dropdown-item" type="button" v-if="vault.userId == user.id" v-for="vault in vaults"
                :key="vault.id" @click="addKeepToVault(keep.id, vault.id)">{{vault.name}}</button>
            </div>
            <button class="btn btn-sm ml-1 btn-success"><img src="../assets/Share-Icon-12.png" class="mb-1">
              Share</button>
            <button class="btn btn-sm ml-1 btn-danger" v-if="user.id == keep.userId && keep.isPrivate == true"
              @click="deleteKeep(keep.id)"><img src="../assets/Delete-Icon-12.png"> Delete</button>
          </div>
        </div>
      </div>
      <keeps-detail-modal />

    </div>
  </div>
</template>

<script>
  import KeepsDetailModal from "@/Components/KeepsDetailModal.vue";


  export default {
    name: "DashKeeps",
    mounted() {
      this.$store.dispatch('getUserKeeps');
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
      deleteKeep(keepId) {
        this.$store.dispatch('deleteKeep', keepId);
      },
      addKeepToVault(kId, vId) {
        let data = {
          keepId: kId,
          vaultId: vId,
          userId: this.user.id,
        }
        this.$store.dispatch('addKeepToVault', data)
      },
      setActiveKeep(keep) {
        keep.views++
        this.$store.dispatch('updateKeep', keep)
      }
    },
    components: {
      KeepsDetailModal
    }
  }
</script>

<style scoped>
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

  .card-title:hover {
    color: blue;
    cursor: pointer;
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