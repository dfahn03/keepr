<template>
  <div class="login-modal">
    <div class="modal fade" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="loginModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="loginModalLabel">Login</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="loginUser">
              <div class="form-group">
                <label for="loginInputEmail" class="col-form-label">Email:</label>
                <input type="email" v-model="creds.email" class="form-control text-center" id="loginInputEmail"
                  placeholder="Enter Email">
              </div>
              <div class="form-group">
                <label for="loginInputPassword" class="col-form-label">Password:</label>
                <input type="password" v-model="creds.password" class="form-control text-center" id="loginInputPassword"
                  placeholder="Enter Password">
              </div>
              <div class="modal-footer justify-content-center">
                <button type="submit" class="btn btn-success">Login</button>
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
    name: "LoginModal",
    data() {
      return {
        creds: {
          email: "",
          password: ""
        }
      }
    },
    methods: {
      loginUser() {
        this.$store.dispatch("login", this.creds);
        $("#loginModal").modal("hide");
        $(".modal-backdrop").remove();
      },
    },
  }
</script>