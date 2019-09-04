<template>
  <div class="dash-keeps container-fluid">
    <div class="card-columns">

      <div class="card m-0 p-0" v-if="keep.userId == user.id" v-for="keep in keeps" :key="keep.id">
        <img :src="keep.img" class="card-img" alt="Keep Image">
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <div class="row justify-content-center align-items-center">
            <div class="col-3 p-0 justify-content-center align-items-center">
              <img src="../assets/eye-25.png" alt="Views" class="float-left ml-2 mt-1" title="Views">
              <p class="card-text mb-0 mt-1">{{keep.views}}</p>
            </div>
            <div class="col-3 p-0">
              <img src="../assets/share-25.png" alt="Views" class="float-left ml-2 mt-1" title="Shares">
              <p class="card-text mb-0 mt-1">{{keep.shares}}</p>
            </div>
            <div class="col-3 p-0">
              <img src="../assets/Pin-Icon-22.png" alt="Views" class="float-left ml-2 mt-1" title="Keeps">
              <p class="card-text mb-0 mt-1">{{keep.keeps}}</p>
            </div>
          </div>
          <div class="row">
            <div class="col mt-2">
              <button class="btn btn-sm btn-secondary" data-toggle="modal" data-target="#KeepsDetailModal"
                @click="keepDetails(keep)">Details</button>
            </div>
          </div>
        </div>
      </div>
      <keeps-detail-modal />

    </div>
  </div>
</template>

<script>
  import KeepsDetailModal from "@/Components/KeepsDetailModal.vue";


  export default {
    name: "DashKeeps",
    mounted() {
      this.$store.dispatch('getUserKeeps');
    },
    data() {
      return {}
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      keeps() {
        return this.$store.state.keeps
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      keepDetails(keep) {
        keep.views++
        this.$store.dispatch('updateKeepCounts', keep)
      }
    },
    components: {
      KeepsDetailModal
    }
  }
</script>

<style scoped>
  .card-columns {
    columns: 4;
    column-gap: 0;

    @include media-breakpoint-only(sm) {
      column-count: 1;
    }

    @include media-breakpoint-only(md) {
      column-count: 2;
    }

    @include media-breakpoint-only(lg) {
      column-count: 3;
    }

    @include media-breakpoint-only(xl) {
      column-count: 4;
    }
  }

  .card {
    display: inline-block;
    /* max-width: max-content; */
    border: none;
  }

  .card-img {
    opacity: 1;
    width: 100%;
    height: auto;
    transition: .5s ease;
    backface-visibility: hidden;
  }

  .card-body {
    transition: .5s ease;
    opacity: 0;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    -ms-transform: translate(-50%, -50%);
    text-align: center;
    background-color: rgba(253, 253, 253, 0.418);
    color: rgb(0, 0, 0);
    font-size: 20px;
    background-size: contain;
    min-width: 17rem;
  }

  .card:hover .card-img {
    opacity: 0.5;
  }

  .card:hover .card-body {
    opacity: 1;
  }
</style>