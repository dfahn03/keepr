<template>
    <div class="row login d-flex justify-content-center align-content-center">
        <div class="card login-card text-center" style="width: 30rem; height: max-content;">
            <div class="card-body">
                <h1 class="card-title">Welcome to KeepSake!</h1>
                <h3 class="card-text">The greatest site to upload, save and see Keeps on the web!</h3>
                <button type="button" class="btn btn-dark btn-sm mt-3 regBtn" data-toggle="modal"
                    data-target="#registerModal" title="Register">Register</button>
                <button type="button" class="btn btn-dark btn-sm ml-1 mt-3 logBtn" data-toggle="modal"
                    data-target="#loginModal" title="Login">Login</button>
                <button type="button" class="btn btn-dark btn-sm ml-1 mt-3 guestBtn" @click="guestPreview"
                    title="Preview Site">Guest</button>
                <!-- TODO Link to guest home view so they can view public keeps or just use one home and set restrictions if logged in or not -->
            </div>
        </div>
        <register-modal />
        <login-modal />
    </div>
</template>

<script>
    import RegisterModal from "@/Components/RegisterModal.vue"
    import LoginModal from "@/Components/LoginModal.vue"


    export default {
        name: "Login",
        data() {
            return {}
        },
        beforeCreate() {
            if (this.$store.state.user.id) {
                this.$router.push({ name: "Home" })
            }
        },
        methods: {
            guestPreview() {
                this.$router.push({ name: "Home" });
            }
        },
        components: {
            RegisterModal,
            LoginModal
        }
    };
</script>

<style scoped>
    .login {
        height: 100vh;
        width: 100vw;
        margin: 0px 0px;
        background-image: url("../assets/bg-6.jpg");
        background-repeat: no-repeat;
        background-position: center;
        background-size: cover;
    }

    .card {
        background: rgba(255, 255, 255, 0.349);
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