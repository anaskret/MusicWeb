<template>
  <div>
    {{ song }}
    <Header
      :parent="song"
      :show_observe_button="show_observe_button"
      :vote_title="vote_title"
    />
    <InfoSection
      :parent="song"
      :module_name="module_name"
      :descriptionTitle="descriptionTitle"
    />
    <ReviewList
      :reviews="song.songReviews"
      :artist="song.composer.name"
      :album="song.album.name"
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
      descriptionTitle: "Tekst utworu",
    };
  },
  created() {
    this.getSongData();
  },
  setup() {
    const { getSongFullData } = useSongs();
    const getSongData = function () {
      getSongFullData(this.id).then((response) => {
        this.song = response;
      });
    };
    return {
      getSongData,
    };
  },
};
</script>
