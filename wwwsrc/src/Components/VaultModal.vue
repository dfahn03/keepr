<template>
  <div class="vault-modal">

    <!-- <div>
      <button class="v-create" type="button" data-toggle="modal" data-target="#createVaultModal" title="Create Vault">
        <img src="../assets/Add-Icont-BBW-25.png" alt="Add Vault" title="Create a Vault" class="mt-1">
        <h3 class="float-right text-white">Vault</h3>
      </button>
    </div> -->

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
                <input type="text" v-model="name" class="form-control text-center" id="vaultInputName"
                  placeholder="Enter Vault Name">
              </div>
              <div class="form-group">
                <label for="vaultInputDescription" class="col-form-label">Description:</label>
                <input type="text" v-model="description" class="form-control text-center" id="vaultInputDescription"
                  placeholder="Enter Vault Description"></input>
              </div>
              <div class="modal-footer justify-content-center">
                <button type="submit" class="btn btn-success">Create Vault</button>
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
    name: "VaultModal",
    props: [],
    data() {
      return {
        name: "",
        description: ""
        // userId: this.user.id || ""
      }
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      createVault() {
        let newVault = {
          name = this.name,
          description = this.description
          // userId = this.user.id
        }
        this.$store.dispatch('createVault', newVault)
        setTimeout(() => {
          this.name = ""
          this.description = ""
        }, 1000);
        $("#createVaultModal").modal("hide");
        $(".modal-backdrop").remove();
      },
    },
    components: {}
  }
</script>

<style scoped>
</style>