<template>
  <div class="row home">
    <navigation />

    <!-- TODO Make a new component with the keeps and use boostrad card-columns to make it 'Masonary' style -->
    <div class="col mt-5">
      <div class="row justify-content-center">
        <div class="card m-3" v-if="keep.isPrivate == false" v-for="keep in keeps" :key="keep.id">
          <img :src="keep.img" class="card-img-top" alt="">
          <div class="card-body">
            <h5 class="card-title">{{keep.name}}</h5>
            <p class="card-text">{{keep.description}}</p>
            <div class="row d-flex justify-content-around">
              <div class="col-4 p-0 m-0">
                <p class="card-text">Views: {{keep.views}}</p>
              </div>
              <div class="col-4 p-0 m-0">
                <p class="card-text">Shares: {{keep.shares}}</p>
              </div>
              <div class="col-4 p-0 m-0">
                <p class="card-text">Keeps: {{keep.keeps}}</p>
              </div>
            </div>
            <div class="row justify-content-center">
              <div class="col-2 dropdown mr-1">
                <img src="../assets/Add-Icon-Green-30.png" alt="" title="Add to Vault" class="btn dropdown-toggle"
                  id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                  <button class="dropdown-item" type="button" v-if="vault.userId == user.id" v-for="vault in vaults"
                    :key="vault.id" @click="addKeepToVault(kId, vId)">{{vault.name}}</button>
                </div>
              </div>
              <div class="col-2">
                <img src="../assets/Share-Icon-30.png" alt="" title="Share Keep" class="shareKBtn ml-2" @click="">
              </div>
              <div class="col-2">
                <img v-if="user.id == keep.userId && keep.isPrivate == true" src="../assets/Trash-Icon-26.png" alt=""
                  title="Delete Keep" class="delKBtn ml-2" @click="deleteKeep(keep.id)">
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>


    <!-- <div class="row mt-5">
      <div class="row justify-content-center">
        <div class="card m-3" style="width: 15rem; height: max-content;"
          v-if="keep.userId == user.id && keep.isPrivate == true" v-for="keep in keeps" :key="keep.id">
          <img :src="keep.img" class="card-img-top" alt="">
          <div class="card-body">
            <h5 class="card-title">{{keep.name}}</h5>
            <p class="card-text">{{keep.description}}</p>
            <div class="row justify-content-center">
              <div class="col-2 dropdown mr-1">
                <img src="../assets/Add-Icon-Green-30.png" alt="" title="Add to Vault" class="btn dropdown-toggle"
                  id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                  <button class="dropdown-item" type="button" v-if="vault.userId == user.id" v-for="vault in vaults"
                    :key="vault.id" @click="addKeepToVault(kId, vId)">{{vault.name}}</button>
                </div>
              </div>
              <div class="col-2">
                <img src="../assets/Share-Icon-30.png" alt="" title="Share Keep" class="shareKBtn ml-2" @click="">
              </div>
              <div class="col-2">
                <img v-if="user.id == keep.userId && keep.isPrivate == true" src="../assets/Trash-Icon-26.png" alt=""
                  title="Delete Keep" class="delKBtn ml-2" @click="deleteKeep(keep.id)">
              </div>
            </div>
          </div>
        </div>
      </div>
    </div> -->

  </div>
</template>

<script>
  import Navigation from "@/Components/Navigation.vue";

  export default {
    name: "Home",
    mounted() {
      this.$store.dispatch('getPublicKeeps');
      // this.$store.dispatch('getUserKeeps');
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      keeps() {
        return this.$store.state.keeps;
      },
      vaults() {
        return this.$store.state.vaults;
      }
    },
    methods: {
      deleteKeep(keepId) {
        this.$store.dispatch('deleteKeep', keepId);
      },
      addKeepToVault(kId, vId) {
        let data = {
          keepId: kId,
          vaultId: vId,
          userId: this.user.id,
        }
        this.$store.dispatch('addKeepToVault', data)
      }
    },
    components: {
      Navigation
    }
  };
</script>

<style scoped>
  .home {
    /* height: 100%;
    width: 100%; */
    min-width: 90vw;
    min-height: 100vh;
    margin: 0px 0px;
    padding: 0px 0px;
    background-image: url("../assets/home-bg-8.jpg");
    -webkit-background-size: contain;
    -moz-background-size: contain;
    -o-background-size: contain;
    background-size: 100% 100%;
    background-position: center;
    /* background: center; */
  }

  .card {
    width: 15rem;
    height: max-content;
    border-color: #000;
  }

  .delKBtn {
    margin-top: 6px;
    cursor: pointer;
  }

  .shareKBtn {
    margin-top: 5px;
    cursor: pointer;
  }

  .dropdown {
    cursor: pointer;
  }
</style>