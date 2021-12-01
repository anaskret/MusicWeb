<template>
  <div>
    {{reviews_desc }}
    <Header
      :parent="song"
      :show_observe_button="show_observe_button"
      :vote_title="vote_title"
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
  methods: {
    prepareReviews() {
      this.reviews_desc = this.song.songReviews.reverse().slice(0, 3);
    },
  },
  created() {
    this.getSongData();
  },
  setup() {
    const { getSongFullData } = useSongs();
    const getSongData = function () {
      getSongFullData(this.id).then((response) => {
        this.song = response;
        this.prepareReviews();
      });
    };
    return {
      getSongData,
    };
  },
};
</script>
