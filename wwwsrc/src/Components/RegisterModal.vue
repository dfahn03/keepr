<template>
  <div class="register-modal">
    <div class="modal fade" id="registerModal" tabindex="-1" role="dialog" aria-labelledby="registerModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="registerModalLabel">Register</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="register">
              <div class="form-group">
                <label for="registerInputUsername" class="col-form-label">Username:</label>
                <input type="text" v-model="newUser.username" class="form-control text-center"
                  id="registerInputUsername" placeholder="Enter Username">
              </div>
              <div class="form-group">
                <label for="registerInputEmail" class="col-form-label">Email:</label>
                <input type="email" v-model="newUser.email" class="form-control text-center" id="registerInputEmail"
                  placeholder="Enter Email">
              </div>
              <div class="form-group">
                <label for="registerInputPassword" class="col-form-label">Password:</label>
                <input type="password" v-model="newUser.password" class="form-control text-center"
                  id="registerInputPassword" placeholder="Enter Password">
              </div>
              <div class="modal-footer justify-content-center">
                <button type="submit" class="btn btn-success">Create Account</button>
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
    name: "RegisterModal",
    props: [],
    data() {
      return {
        newUser: {
          email: "",
          password: "",
          username: ""
        }
      }
    },
    computed: {

    },
    methods: {
      register() {
        this.$store.dispatch("register", this.newUser);
        $("#registerModal").modal("hide");
        $(".modal-backdrop").remove();
      },
    },
    components: {}
  }
</script>