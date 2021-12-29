<template>
  <div>
    <Header
      :parent="song"
      :show_observe_button="show_observe_button"
      :vote_title="vote_title"
      :module_name="module_name"
      @getRating="getSongRating"
      
    />
    <InfoSection
      :parent="song"
      :module_name="module_name"
      :description_title="description_title"
    />
    <ReviewList
      :reviews="reviews_desc"
      :refreshComments="getSongData"
      :artist="song.composer.name"
      :album="song.album.name"
      v-on="$listeners"
      :redirect_module_name="redirect_module_name"
    />
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
import useSongs from "@/modules/songs";
import ReviewList from "../components/ReviewList.vue";
import InfoSection from "../components/InfoSection.vue";
import {mapMutations} from 'vuex';
export default {
  name: "SongPage",
  components: {
    Header,
    InfoSection,
    ReviewList,
  },
  data() {
    return {
      id: this.$route.params.id,
      song: {},
      show_observe_button: false,
      vote_title: "Oceń piosenkę",
      module_name: "Song",
      redirect_module_name: "SongReviewPage",
      description_title: "Tekst utworu",
      reviews_desc: {},
    };
  },
   watch: {
    song() {
      this.setSong(this.song);
    }
  },
  methods: {
        ...mapMutations([
      'setSong'
    ]),
    prepareReviews() {
      this.reviews_desc = this.song.songReviews.reverse().slice(0, 3);
    },
  },
  created() {
    this.getSongData();
  },
  setup() {
    const { getSongFullData, getSongRatingAverage } = useSongs();
    const getSongData = function () {
      getSongFullData(this.id).then((response) => {
        console.log(response);
        this.song = response;
        this.prepareReviews();
        this.getSongRating();
      });
    };
    const getSongRating = function () {
      getSongRatingAverage(this.id).then((response) => {
          this.$set(this.song, 'rating', response.rating);
          this.$set(this.song, 'ratingsCount', response.ratingsCount);
          this.$set(this.song, 'favoriteCount', response.favoriteCount);
      })
    }
    return {
      getSongData,
      getSongRating
    };
  },
};
</script>
