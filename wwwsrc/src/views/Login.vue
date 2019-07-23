<template>
    <div class="row login d-flex justify-content-center">
        <!-- <form v-if="loginForm" @submit.prevent="loginUser">
            <input type="email" v-model="creds.email" placeholder="email">
            <input type="password" v-model="creds.password" placeholder="password">
            <button type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register">
            <input type="text" v-model="newUser.username" placeholder="name">
            <input type="email" v-model="newUser.email" placeholder="email">
            <input type="password" v-model="newUser.password" placeholder="password">
            <button type="submit">Create Account</button>
        </form>
        <div @click="loginForm = !loginForm">
            <p v-if="loginForm">No account Click to Register</p>
            <p v-else>Already have an account click to Login</p>
        </div> -->

        <div class="card text-center" style="width: 30rem;">
            <div class="card-body">
                <h5 class="card-title">Welcome to Keepr!</h5>
                <p class="card-text">The greatest site to upload, save and see the best Keeps on the web!</p>
                <button type="button" class="btn btn-primary btn-sm" data-toggle="modal"
                    data-target="#registerModal">Register</button>
                <button type="button" class="btn btn-success btn-sm ml-1" data-toggle="modal"
                    data-target="#loginModal">Login</button>
                <button type="button" class="btn btn-warning btn-sm ml-1" @click="">Guest</button>
            </div>
        </div>



        <div class="modal fade" id="registerModal" tabindex="-1" role="dialog" aria-labelledby="registerModalLabel"
            aria-hidden="true">
            <div class="modal-dialog" role="document">
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
                                <input type="text" v-modle="newUser.username" class="form-control text-center"
                                    id="registerInputUsername" placeholder="Enter Username">
                            </div>
                            <div class="form-group">
                                <label for="registerInputEmail" class="col-form-label">Email:</label>
                                <input type="email" v-model="newUser.email" class="form-control text-center"
                                    id="registerInputEmail" placeholder="Enter Email"></input>
                            </div>
                            <div class="form-group">
                                <label for="registerInputPassword" class="col-form-label">Password:</label>
                                <input type="password" v-model="newUser.password" class="form-control text-center"
                                    id="registerInputPassword" placeholder="Enter Password"></input>
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer justify-content-center">
                        <button type="button" class="btn btn-success">Create Account</button>
                    </div>
                </div>
            </div>
        </div>


        <div class="modal fade" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="loginModalLabel"
            aria-hidden="true">
            <div class="modal-dialog" role="document">
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
                                <input type="email" v-model="creds.email" class="form-control text-center"
                                    id="loginInputEmail" placeholder="Enter Email"></input>
                            </div>
                            <div class="form-group">
                                <label for="loginInputPassword" class="col-form-label">Password:</label>
                                <input type="password" v-model="creds.password" class="form-control text-center"
                                    id="loginInputPassword" placeholder="Enter Password"></input>
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer justify-content-center">
                        <button type="button" class="btn btn-success">Login</button>
                    </div>
                </div>
            </div>
        </div>

    </div>
</template>

<script>
    export default {
        name: "login",
        data() {
            return {
                // loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        beforeCreate() {
            if (this.$store.state.user.id) {
                this.$router.push({ name: "home" })
            }
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        }
    };
</script>

<style scoped>

</style>