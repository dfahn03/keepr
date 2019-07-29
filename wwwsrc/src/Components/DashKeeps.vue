<template>
  <div class="dash-keeps container-fluid">
    <div class="card-columns">

      <div class="card" v-if="keep.userId == user.id" v-for="keep in keeps" :key="keep.id">
        <img :src="keep.img" class="card-img-top" alt="Keep Image">
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text">{{keep.description}}</p>
          <div class="row">
            <div class="col-4 p-0">
              <p class="card-text">Views: {{keep.views}}</p>
            </div>
            <div class="col-4 p-0">
              <p class="card-text">Shares: {{keep.shares}}</p>
            </div>
            <div class="col-4 p-0">
              <p class="card-text">Keeps: {{keep.keeps}}</p>
            </div>
            <!-- TODO Beautify these counts -->
          </div>
          <div class="dropdown mr-1">
            <img src="../assets/Add-Icon-Green-30.png" alt="" title="Add to Vault" class="btn dropdown-toggle"
              id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
              <button class="dropdown-item" type="button" v-if="vault.userId == user.id" v-for="vault in vaults"
                :key="vault.id" @click="addKeepToVault(kId, vId)">{{vault.name}}</button>
            </div>
            <img src="../assets/Share-Icon-30.png" alt="" title="Share Keep" class="shareKBtn" @click="">
            <img v-if="user.id == keep.userId && keep.isPrivate == true" src="../assets/Trash-Icon-26.png" alt=""
              title="Delete Keep" class="delKBtn ml-2" @click="deleteKeep(keep.id)">
          </div>
        </div>
      </div>

    </div>


  </div>
</template>

<script>
  export default {
    name: "DashKeeps",
    mounted() {
      this.$store.dispatch('getUserKeeps');
    },
    props: [],
    data() {
      return {}
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      vaults() {
        return this.$store.state.vaults
      },
      keeps() {
        return this.$store.state.keeps
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
    components: {}
  }
</script>

<style scoped>
  .card-columns {
    @include media-breakpoint-only(sm) {
      column-count: 1;
    }

    @include media-breakpoint-only(md) {
      column-count: 3;
    }

    @include media-breakpoint-only(lg) {
      column-count: 4;
    }

    @include media-breakpoint-only(xl) {
      column-count: 5;
    }
  }

  .card-columns {
    /* column-width: 325px; */
    columns: 5;
    column-gap: 0;
  }

  .card {
    display: inline-block;
    max-width: max-content;
    min-height: 380px;
    border-color: #000;
  }

  .card-body {
    background-color: #fff;
  }

  .card-img-top {
    width: 100%;
    max-width: 300px;
    max-height: 100%;
  }

  .menuBtn {
    cursor: pointer;
  }

  .delVBtn {
    cursor: pointer;
  }

  .delKBtn {
    cursor: pointer;
  }

  .shareKBtn {
    cursor: pointer;
  }
</style>