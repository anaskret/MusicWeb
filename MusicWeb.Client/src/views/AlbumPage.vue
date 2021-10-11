<template>
  <div fluid>
    <Header
      :show_observe_button="show_observe_button"
      :vote_title="vote_title"
    />

    <InfoSection :info_content="info_content" />
    <ItemList :songs="songs" />
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
import ItemList from "@/components/ItemList.vue";
import InfoSection from "@/components/InfoSection.vue";

export default {
  name: "AlbumPage",
  components: {
    Header,
    ItemList,
    InfoSection,
  },
  data() {
    return {
      id: this.$route.params.id,
      artist: {},
      songs: {},
      reviews: {},
      show_observe_button: false,
      info_content: [
        { info: "Zespół: Anathema" },
        { info: "Data wydania: 15. 04. 2012" },
        { info: "Czas trwania: 55 minut" },
        { info: "Gatunek muzyczny: rock progresywny, art rock, doom metal" },
      ],
      vote_title: "Oceń album:",
    };
  },
  created() {
    this.getSongs();
  },
  methods: {
    getSongs() {
      this.songs = [
        {
          img: "weather",
          title: "Untochable, pt I",
          album: "Weather Systems",
          rating: "5.0",
        },
        {
          img: "weather",
          title: "Untouchable, pt II",
          album: "Weather Systems",
          rating: 4.9,
        },
        {
          img: "weather",
          title: "The Gathering Of The Cloud",
          album: "Weather Systems",
          rating: 4.9,
        },
      ];
    },
  },
};
</script>
