<template>
  <div class="edit-vault-modal">

    <div class="modal fade" id="editVaultModal" tabindex="-1" role="dialog" aria-labelledby="editVaultModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="editVaultModalLabel">Create Vault</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="editVault">
              <div class="form-group">
                <label for="vaultInputName" class="col-form-label">Name:</label>
                <input type="text" v-model="vault.name" class="form-control text-center" id="vaultInputName"
                  placeholder="Enter Vault Name" required>
              </div>
              <div class="form-group mb-4">
                <label for="vaultInputDescription" class="col-form-label">Description:</label>
                <input type="text" v-model="vault.description" class="form-control text-center"
                  id="vaultInputDescription" placeholder="Enter Vault Description">
              </div>
              <button type="submit" class="btn btn-success">Update Vault</button>
            </form>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: "EditVaultModal",
    data() {
      return {}
    },
    computed: {
      vault() {
        return this.$store.state.vault
      }
    },
    methods: {
      editVault() {
        this.$store.dispatch('updateVault', this.vault)
        $("#editVaultModal").modal("hide");
        $(".modal-backdrop").remove();
      },
    },
  }
</script>