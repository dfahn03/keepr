<template>
    <div class="row login d-flex justify-content-center align-content-center">
        <div class="card login-card text-center" style="width: 30rem;">
            <div class="card-body">
                <h1 class="card-title">Welcome to Keepr!</h1>
                <h3 class="card-text">The greatest site to upload, save and see the best Keeps on the web!</h3>
                <button type="button" class="btn btn-dark btn-sm mt-3 regBtn" data-toggle="modal"
                    data-target="#registerModal" title="Register">Register</button>
                <button type="button" class="btn btn-dark btn-sm ml-1 mt-3 logBtn" data-toggle="modal"
                    data-target="#loginModal" title="Login">Login</button>
                <button type="button" class="btn btn-secondary btn-sm ml-1 mt-3 guestBtn" @click=""
                    title="Preview Site">Guest</button>
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
                            <div class="modal-footer justify-content-center">
                                <button type="submit" class="btn btn-success">Create Account</button>
                            </div>
                        </form>
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
        name: "Login",
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
                this.$router.push({ name: "Home" })
            }
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
                $("#registerModal").modal("hide");
                $(".modal-backdrop").remove();
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
                $("#loginModal").modal("hide");
                $(".modal-backdrop").remove();
            }
        }
    };
</script>

<style scoped>
    .login {
        height: 100vh;
        width: 100vw;
        margin: 0px 0px;
        background-image: url("../assets/bg-4.jpg");
        background-repeat: no-repeat;
        background-position: center;
        background-size: cover;
    }

    .card {
        background: transparent;
        font-weight: 900;
        color: rgb(0, 0, 0);
        border: none;
    }

    .card-body {
        font-family: 'Acme', sans-serif;
        font-style: italic;
    }

    .card-title {
        font-family: 'Lobster', cursive;
    }

    .logBtn {
        background-color: rgb(25, 212, 0);
    }

    .regBtn {
        background-color: rgb(0, 174, 255);
    }

    .guestBtn {
        background-color: rgb(255, 153, 0);
    }
</style>

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