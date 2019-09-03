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
              <div class="form-check" v-if="user.id == keep.userId">
                <input class="form-check-input" type="radio" v-model="keep.isPrivate" name="privateRadios"
                  id="privateRadios1" v-bind:value="true" checked>
                <label class="form-check-label" for="privateRadios1">
                  Private <small class="text-muted">(Only you can see this)</small>
                </label>
              </div>
              <div class="row" v-if="user.id != keep.userId && keep.isPrivate == true">
                <div class="col mt-3 mb-3">
                  <p>Private</p>
                </div>
              </div>
              <div class="form-check mb-3" v-if="user.id == keep.userId">
                <input class="form-check-input" type="radio" v-model="keep.isPrivate" name="publicRadios"
                  id="publicRadios2" v-bind:value="false">
                <label class="form-check-label" for="publicRadios2">
                  Public <small class="text-muted">(Everyone can see this)</small>
                </label>
              </div>
              <div class="row" v-if="user.id != keep.userId && keep.isPrivate == false">
                <div class="col mt-3 mb-3">
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
              <div class="dropdown mr-1 mt-2 mb-3">
                <button class="btn dropdown btn-sm ml-1 btn-primary" id="dropdownMenu2" data-toggle="dropdown"
                  aria-haspopup="true" aria-expanded="false"><img src="../assets/Pin-Icon-12.png" class="mb-1">
                  Save</button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                  <button class="dropdown-item" type="button" v-if="vault.userId == user.id" v-for="vault in vaults"
                    :key="vault.id" @click="addKeepToVault(keep.id, vault.id)">{{vault.name}}</button>
                </div>
                <button class="btn btn-sm ml-1 btn-primary"><img src="../assets/Share-Icon-12.png" class="mb-1">
                  Share</button>
                <button class="btn btn-sm ml-1 btn-danger" v-if="user.id == keep.userId && keep.isPrivate == true"
                  @click="deleteKeep(keep.id)"><img src="../assets/Delete-Icon-12.png"> Delete</button>
              </div>
              <div class="modal-footer justify-content-center">
                <button type="submit" class="btn btn-success">Update Keep</button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
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
      updateKeep(keep) {
        this.$store.dispatch('updateKeep', keep)
        $("#KeepsDetailModal").modal("hide");
        $(".modal-backdrop").remove();
      }
    },
    components: {}
  }
</script>

<style scoped>

</style>