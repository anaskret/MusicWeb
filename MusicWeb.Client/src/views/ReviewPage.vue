<template>
  <v-container fluid>
    <v-row justify="center" class="pt-10">
      <v-col sm="4" lg="2">
        <div class="d-flex justify-content-center">
          <v-img :src="require('@/assets/BandPhoto.svg')" contain width="50%" />
        </div>
      </v-col>
      <v-col sm="8" lg="6">
        <div>
          <h1 class="display-1 font-weight-bold text-left">
            {{ review.title }}
          </h1>
          <p>{{ review.userName }} at {{ review.postDate }}</p>
        </div>
        <div>
        </div>
        <div class="pt-10">
          <p>
            {{ review.content }}
          </p>
        </div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import useAlbumReviews from "@/modules/albumReviews";
import useSongReviews from "@/modules/songReviews";
export default {
  name: "ReviewPage",
  components: {},
  data() {
    return {
      id: this.$route.params.id,
      review: {},
      module_name: this.$route.name,
    };
  },
  methods: {},
  created() {
    if (this.module_name == "AlbumReviewPage") {
      this.getAlbumReview();
    } else if (this.module_name == "SongReviewPage") {
      this.getSongReview();
    }
  },
  setup() {
    const { getAlbumReviewFullData } = useAlbumReviews();
    const { getSongReviewFullData } = useSongReviews();

    const getAlbumReview = function () {
      getAlbumReviewFullData(this.id).then((response) => {
        this.review = response;
      });
    };

    const getSongReview = function () {
      getSongReviewFullData(this.id).then((response) => {
        this.review = response;
      });
    };
    return {
      getAlbumReview,
      getSongReview,
    };
  },
};
</script>

<style scoped>
.review_data {
  justify-content: center;
}
</style>
