<template>
  <div class="keeps-detail-modal">

    <div class="modal fade" id="KeepsDetailModal" tabindex="-1" role="dialog" aria-labelledby="KeepsDetailModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="KeepsDetailModalLabel">Keep Details</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="updateKeep(keep)">
              <div class="form-group">
                <img :src="keep.img" style="max-height: 400px; max-width: 350px;" class="keepImg" alt="Keep Image">
              </div>
              <div class="form-group">
                <h2 v-model="keep.name" class="text-center">{{keep.name}}</h2>
              </div>
              <div class="form-group">
                <h6 v-model="keep.description" class="text-center">{{keep.description}}</h6>
              </div>
              <div class="form-check" v-if="user.id && user.id == keep.userId">
                <input class="form-check-input" type="radio" v-model="keep.isPrivate" name="privateRadios"
                  id="privateRadios1" v-bind:value="true" checked>
                <label class="form-check-label" for="privateRadios1">
                  Private <small class="text-muted">(Only you can see this)</small>
                </label>
              </div>
              <div class="form-check mb-3" v-if="user.id && user.id == keep.userId">
                <input class="form-check-input" type="radio" v-model="keep.isPrivate" name="publicRadios"
                  id="publicRadios2" v-bind:value="false">
                <label class="form-check-label" for="publicRadios2">
                  Public <small class="text-muted">(Everyone can see this)</small>
                </label>
              </div>
              <div class="row" v-if="user.id != keep.userId && keep.isPrivate == false">
                <div class="col mt-1 mb-1">
                  <p>Public</p>
                </div>
              </div>
              <div class="row justify-content-center align-items-center mb-4">
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
              <div class="dropdown mr-1 mt-2 mb-3" v-if="user.id">
                <button class="btn dropdown btn-sm ml-1 btn-primary" id="dropdownMenu2" data-toggle="dropdown"
                  aria-haspopup="true" aria-expanded="false"><img src="../assets/Pin-Icon-12.png" class="mb-1">
                  Save</button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                  <button class="dropdown-item" type="button" v-if="vault.userId == user.id" v-for="vault in vaults"
                    :key="vault.id" @click="addKeepToVault(keep, vault)">{{vault.name}}</button>
                  <a data-dismiss="modal" data-toggle="modal" href="#createVaultModal" style="text-decoration: none">
                    <button class="dropdown-item" type="button">Create Vault</button>
                  </a>
                </div>
                <a data-dismiss="modal" data-toggle="modal" href="#shareModal">
                  <button class="btn btn-sm ml-1 btn-primary" @click='keepShares(keep)'><img
                      src="../assets/Share-Icon-12.png" class="mb-1">Share</button>
                </a>
                <button class="btn btn-sm ml-1 btn-danger" v-if="user.id == keep.userId && keep.isPrivate == true"
                  @click="deleteKeep(keep.id)"><img src="../assets/Delete-Icon-12.png"> Delete</button>
              </div>
              <div class="modal-footer justify-content-center" v-if="user.id && user.id == keep.userId">
                <button type="submit" class="btn btn-success">Update Keep</button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>

    <share-modal />

  </div>
</template>

<script>
  import ShareModal from '@/Components/ShareModal.vue';
  export default {
    name: "KeepsDetailModal",
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
      keep() {
        return this.$store.state.keep
      }
    },
    methods: {
      // updateKeep(keep) {
      //   this.$store.dispatch('updateKeep', keep)
      //   $("#KeepsDetailModal").modal("hide");
      //   $(".modal-backdrop").remove();
      // TODO create way to edit vaults & keeps
      // },
      keepShares(keep) {
        keep.shares++
        this.$store.dispatch('updateKeepCounts', keep)
      },
      addKeepToVault(keep, vault) {
        keep.keeps++
        this.$store.dispatch('updateKeepCounts', keep)
        let data = {
          keepId: keep.id,
          vaultId: vault.id,
          userId: this.user.id,
        }
        this.$store.dispatch('addKeepToVault', data)
        $("#KeepsDetailModal").modal("hide");
        $(".modal-backdrop").remove();
      },
      deleteKeep(keepId) {
        this.$store.dispatch('deleteKeep', keepId);
      },
    },
    components: {
      ShareModal
    }
  }
</script>

<style scoped>
  .dropdown-item:hover {
    background-color: #ddd;
  }
</style>