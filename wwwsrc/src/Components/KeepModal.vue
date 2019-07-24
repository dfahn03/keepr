<template>
  <div class="keep-modal">
    <div>
      <button class="v-keep ml-5" type="button" data-toggle="modal" data-target="#createKeepModal" title="Create Keep">
        <img src="../assets/Add-Icont-BBW-25.png" alt="Add Vault" title="Create a Vault" class="mt-1">
        <h3 class="float-right text-white">Keep</h3>
      </button>
    </div>
    <div class="modal fade" id="createKeepModal" tabindex="-1" role="dialog" aria-labelledby="registerModalLabel"
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
                  placeholder="Enter Email"></input>
              </div>
              <div class="form-group">
                <label for="registerInputPassword" class="col-form-label">Password:</label>
                <input type="password" v-model="newUser.password" class="form-control text-center"
                  id="registerInputPassword" placeholder="Enter Password"></input>
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
    name: "KeepModal",
    props: [],
    data() {
      return {}
    },
    computed: {},
    methods: {},
    components: {}
  }
</script>

<style scoped>
</style>