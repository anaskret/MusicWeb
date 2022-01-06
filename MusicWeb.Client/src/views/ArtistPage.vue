<template>
  <div>
    <Header
      :parent="artist"
      :show_observe_button="show_observe_button"
      :vote_title="vote_title"
      :module_name="module_name"
      @getRating="getArtistRating"
    />
    <InfoSection
      :parent="artist"
      :module_name="module_name"
      :description_title="description_title"
    />
    <ItemCarousel
      :items="artist.albums"
      :component_title="component_title"
      :component_link_title="component_link_title"
    />
    <ItemList
      :items="songs"
      :list_title="list_title"
      :list_link_title="list_link_title"
    />
    <CommentsList
      :comments="comments"
      :refreshComments="getComments"
      :artistId="Number(id)"
      v-on="$listeners"
    />
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
import ItemCarousel from "@/components/ItemCarousel.vue";
import ItemList from "@/components/ItemList.vue";
import CommentsList from "@/components/CommentsList.vue";
import InfoSection from "@/components/InfoSection.vue";
import useArtists from "@/modules/artists";
import useComments from "@/modules/comments";
import useSongs from "@/modules/songs";
import {mapMutations} from 'vuex';

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
      list_title: "Utwory",
      list_link_title: "Wyświetl wszystkie utwory",
      show_observe_button: true,
      vote_title: "Oceń artystę:",
      module_name: "Artist",
      description_title: "Biografia",
    };
  },
    watch: {
    artist() {
      this.setArtist(this.artist);
    }
  },
  methods: {
    ...mapMutations([
      'setArtist'
    ]),
  },
  created() {
    this.getArtist();
    this.getSongs();
    this.getComments();
  },

  setup() {
    const { getArtistById, getArtistRatingAverage } = useArtists();
    const { getCommentById } = useComments();
    const { getSongsByArtistId } = useSongs();

    const getArtist = function () {
      getArtistById(this.id).then((response) => {
        this.artist = response;
        this.getArtistRating();
      });
    };
    const getComments = function () {
      getCommentById(this.id).then((response) => {
        this.comments = [];
        response.forEach((comment) => this.comments.push(comment));
      });
    };
    const getSongs = function () {
      getSongsByArtistId(this.id).then((response) => {
        this.songs = [];
        response.forEach((song) => this.songs.push(song));
      });
    };
        const getArtistRating = function () {
      getArtistRatingAverage(this.id).then((response) => {
        console.log(response);
          this.$set(this.artist, 'rating', response.rating);
          this.$set(this.artist, 'ratingsCount', response.ratingsCount);
          this.$set(this.artist, 'favoriteCount', response.favoriteCount);
     })
    }

    return {
      getArtist,
      getComments,
      getSongs,
      getArtistRating,
    };
  },
};
</script>
