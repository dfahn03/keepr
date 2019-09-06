<template>
  <div class="create-vault-modal">

    <div class="modal fade" id="createVaultModal" tabindex="-1" role="dialog" aria-labelledby="createVaultModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="createVaultModalLabel">Create Vault</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createVault">
              <div class="form-group">
                <label for="vaultInputName" class="col-form-label">Name:</label>
                <input type="text" v-model="newVault.name" class="form-control text-center" id="vaultInputName"
                  placeholder="Enter Vault Name" required>
              </div>
              <div class="form-group mb-4">
                <label for="vaultInputDescription" class="col-form-label">Description:</label>
                <input type="text" v-model="newVault.description" class="form-control text-center"
                  id="vaultInputDescription" placeholder="Enter Vault Description">
              </div>
              <button type="submit" class="btn btn-success">Create Vault</button>
            </form>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: "CreateVaultModal",
    data() {
      return {
        newVault: {
          name: "",
          description: ""
        },
      }
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      keep() {
        return this.$store.state.keep
      },
      vault() {
        return this.$store.state.vault
      }
    },
    methods: {
      createVault() {
        this.$store.dispatch('createVault', this.newVault)
        $("#createVaultModal").modal("hide");
        $(".modal-backdrop").remove();
        setTimeout(() => {
          this.newVault.name = ""
          this.newVault.description = ""
        }, 1000);
        setTimeout(() => {
          this.addKeepToVault();
        }, 1000);
      },
      addKeepToVault() {
        this.keep.keeps++
        this.$store.dispatch('updateKeepCounts', this.keep)
        let data = {
          keepId: this.keep.id,
          vaultId: this.vault.id,
          userId: this.user.id,
        }
        this.$store.dispatch('addKeepToVault', data)
        $("#KeepsDetailModal").modal("hide");
        $(".modal-backdrop").remove();
      },
    },
  }
</script>