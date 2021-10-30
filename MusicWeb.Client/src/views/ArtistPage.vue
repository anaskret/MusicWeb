<template>
  <div>
    <Header
      :parent="artist"
      :show_observe_button="show_observe_button"
      :vote_title="vote_title"
    />
    <InfoSection :parent="artist" :module_name="module_name" />
    <item-carousel
      :items="artist.albums"
      :componentTitle="component_title"
      :componentLinkTitle="component_link_title"
    />
    <item-list :songs="songs" />
    <comments-list :comments="comments" />
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
import ItemCarousel from "@/components/ItemCarousel.vue";
import ItemList from "@/components/ItemList.vue";
import CommentsList from "@/components/CommentsList.vue";
import InfoSection from "@/components/InfoSection.vue";
import useArtists from "@/modules/artists";

export default {
  name: "ArtistPage",
  components: {
    Header,
    ItemCarousel,
    ItemList,
    CommentsList,
    InfoSection,
  },
  data() {
    return {
      id: this.$route.params.id,
      artist: {},
      songs: [],
      comments: [],
      component_title: "Dyskografia",
      component_link_title: "Wyświetl pełną dyskografię",
      show_observe_button: true,
      vote_title: "Oceń artystę:",
      module_name: "Artist",
    };
  },
  created() {
    this.getArtist();
    this.getSongs();
    this.getComments();
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
          img: "naturaldisaster",
          title: "Flying",
          album: "A Natural Disaster",
          rating: "5.0",
        },
        {
          img: "judgement",
          title: "Pitiless",
          album: "Judgement",
          rating: "5.0",
        },
      ];
    },
    getComments() {
      this.comments = [
        {
          img: "",
          userName: "AnathemaLover",
          date: "11:12 23.04.2020",
          text: "Jakiś tam przykładowy komentarz użytkownika, który kocha Anathemę, bo przecież każdy człowiek na świecie powinien kochać Anathemę. Anathema plz come back.",
        },
        {
          img: "",
          userName: "AnathemaLover",
          date: "11:12 23.04.2020",
          text: "Jakiś tam przykładowy komentarz użytkownika, który kocha Anathemę, bo przecież każdy człowiek na świecie powinien kochać Anathemę. Anathema plz come back.",
        },
        {
          img: "",
          userName: "AnathemaLover",
          date: "11:12 23.04.2020",
          text: "Jakiś tam przykładowy komentarz użytkownika, który kocha Anathemę, bo przecież każdy człowiek na świecie powinien kochać Anathemę. Anathema plz come back.",
        },
      ];
    },
  },

  setup() {
    const { getById } = useArtists();

    const getArtist = function () {
      getById(this.id).then((response) => {
        this.artist = response;
      });
    };

    return {
      getArtist,
    };
  },
};
</script>
