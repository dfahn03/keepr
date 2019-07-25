<template>
  <div class="keep-modal">

    <div class="modal fade" id="createKeepModal" tabindex="-1" role="dialog" aria-labelledby="createKeepModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="createKeepModalLabel">Create Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createKeep">
              <div class="form-group">
                <label for="keepInputName" class="col-form-label">Name:</label>
                <input type="text" v-model="newKeep.name" class="form-control text-center" id="keepInputName"
                  placeholder="Enter Keep Name" required>
              </div>
              <div class="form-group">
                <label for="keepInputDescription" class="col-form-label">Description:</label>
                <input type="text" v-model="newKeep.description" class="form-control text-center"
                  id="keepInputDescription" placeholder="Enter Keep Description" required>
              </div>
              <div class="form-group">
                <label for="keepInputImg" class="col-form-label">Image:</label>
                <input type="url" v-model="newKeep.img" class="form-control text-center" id="keepInputImg"
                  placeholder="Enter Keep Image Url">
                <small>
                  <p>Optional but encouraged!</p>
                </small>
              </div>
              <div class="form-check">
                <input class="form-check-input" type="radio" v-model="newKeep.isPrivate" name="privateRadios"
                  id="privateRadios1" v-bind:value="true" checked>
                <label class="form-check-label" for="privateRadios1">
                  Private <small class="text-muted">(Only you can see this)</small>
                </label>
              </div>
              <div class="form-check">
                <input class="form-check-input" type="radio" v-model="newKeep.isPrivate" name="publicRadios"
                  id="publicRadios2" v-bind:value="false">
                <label class="form-check-label" for="publicRadios2">
                  Public <small class="text-muted">(Everyone can see this)</small>
                </label>
              </div>
              <div class="modal-footer justify-content-center">
                <button type="submit" class="btn btn-success">Create Keep</button>
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
    name: "KeepModal",
    props: [],
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          img: "",
          isPrivate: ""
        },
        // picked: this.picked
      }
    },
    computed: {},
    methods: {
      createKeep() {
        this.$store.dispatch('createKeep', this.newKeep)
        setTimeout(() => {
          this.newKeep.name = ""
          this.newKeep.description = ""
          this.newKeep.img = ""
          this.newKeep.isPrivate = ""
        }, 2000);
        $("#createKeepModal").modal("hide");
        $(".modal-backdrop").remove();
      },
    },
    components: {}
  }
</script>

<style scoped>

</style>