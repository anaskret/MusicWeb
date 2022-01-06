<template>
  <v-container fluid>
    <v-row justify="center" class="pt-10">
      <v-col lg="2">
        <div class="d-flex justify-content-center">
          <v-img :src="require('@/assets/BandPhoto.svg')" contain width="50%" />
        </div>
      </v-col>
      <v-col lg="6">
        <div>
          <h1 class="display-1 font-weight-bold text-left">
            {{ review.title }}
          </h1>
          <p>{{ review.userName }} at {{ review.postDate }}</p>
        </div>
        <div>
          <!-- <p>{{ review.album.name }} - {{ review.artist }}</p> -->
        </div>
        <div class="pt-10">
          <p>
            {{ review.content }}
          </p>
        </div>
      </v-col>
      <!-- <v-col lg="2">
        <div class="d-flex justify-content-center">
            <v-img
              :src="require('@/assets/BandPhoto.svg')"
              contain
              width="50%"
            />
          </div>
      </v-col>
      <v-col lg="6">
        <div class="d-flex justify-content-center flex-column align-items-center">
       
        <p class="font-thin font-italic" style="color: white">
          Posted 20 hours ago
        </p>
        </div>
      </v-col>
    </v-row>
    <v-row justify="center" class="pb-lg-2">
      <v-col lg="2">
      </v-col>
      <v-col lg="6">
        <p>{{ review.content }}</p>
      </v-col> -->
      <!-- <v-col lg="3">
        <v-card style="border: 1px solid #2c2f33">
          <div>
            <v-img
              :src="require('@/assets/BandPhoto.svg')"
              contain
              width="50%"
            />
          </div>
          <div class="d-flex flex-column">
            <p>Weather Systems by Anathema</p> -->
      <!-- <p>{{review.album.name}} POBRAĆ ARTYSTĘ</p>  -->
      <!-- </div>
        </v-card>
        <v-card style="background-color: #10151d" class="mt-10">
          <div>
            <v-img
              :src="require('@/assets/BandPhoto.svg')"
              contain
              width="50%"
            />
          </div>
          <div class="d-flex flex-column">
            <p>Review by {{ review.user.userName }}</p> -->

      <!-- <p>{{review.album.name}} POBRAĆ ARTYSTĘ</p>  -->
      <!-- </div>
        </v-card>
      </v-col> -->
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
    // const { getAlbumFullData } = useAlbums();
    // const getAlbumData = function () {
    //   getAlbumFullData(this.id).then((response) => {
    //     this.album = response;
    //     this.prepareReviews();
    //   });
    // };
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
