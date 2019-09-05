<template>
  <div class="share-modal">

    <div class="modal fade" id="shareModal" tabindex="-1" role="dialog" aria-labelledby="shareModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="shareModalLabel">Share Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <!-- <div class="fb-share-button" data-href="https://developers.facebook.com/docs/plugins/"
              data-layout="button_count" data-size="small"><a target="_blank" href="keep"
                class="fb-xfbml-parse-ignore">Facebook</a></div> -->
            <!-- <vue-goodshare></vue-goodshare> -->
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  // import VueGoodshare from "vue-goodshare";
  export default {
    name: "ShareModal",
    data() {
      return {}
    },
    computed: {
      keep() {
        return this.$store.state.keep
      }
    },
    methods: {},
    components: {
      // VueGoodshare
    }
  }
</script>

<style scoped>

</style>