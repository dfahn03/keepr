<template>
  <div class="edit-keep-modal">

    <div class="modal fade" id="editKeepModal" tabindex="-1" role="dialog" aria-labelledby="editKeepModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="editKeepModalLabel">Create Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="editKeep">
              <div class="form-group">
                <label for="keepInputName" class="col-form-label">Name:</label>
                <input type="text" v-model="keep.name" class="form-control text-center" id="keepInputName"
                  placeholder="Enter Keep Name" required>
              </div>
              <div class="form-group">
                <label for="keepInputDescription" class="col-form-label">Description:</label>
                <input type="text" v-model="keep.description" class="form-control text-center" id="keepInputDescription"
                  placeholder="Enter Keep Description" required>
              </div>
              <div class="form-group">
                <label for="keepInputImg" class="col-form-label">Image:</label>
                <input type="url" v-model="keep.img" class="form-control text-center" id="keepInputImg"
                  placeholder="Enter Keep Image Url">
                <small class="text-muted">
                  <p>Optional but encouraged!</p>
                </small>
              </div>
              <div class="form-check">
                <input class="form-check-input" type="radio" v-model="keep.isPrivate" name="privateRadios"
                  id="privateRadios1" v-bind:value="true" checked>
                <label class="form-check-label" for="privateRadios1">
                  Private <small class="text-muted">(Only you can see this)</small>
                </label>
              </div>
              <div class="form-check mb-3">
                <input class="form-check-input" type="radio" v-model="keep.isPrivate" name="publicRadios"
                  id="publicRadios2" v-bind:value="false">
                <label class="form-check-label" for="publicRadios2">
                  Public <small class="text-muted">(Everyone can see this)</small>
                </label>
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
    name: "EditKeepModal",
    data() {
      return {}
    },
    computed: {
      keep() {
        return this.$store.state.keep
      }
    },
    methods: {
      editKeep() {
        this.$store.dispatch('updateKeep', this.keep)
        $("#editKeepModal").modal("hide");
        $(".modal-backdrop").remove();
      }
    },
  }
</script>

<style scoped>
</style>