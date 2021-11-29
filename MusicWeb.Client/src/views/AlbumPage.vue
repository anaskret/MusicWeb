<template>
  <div fluid>
    <Header
      :parent="album"
      :show_observe_button="show_observe_button"
      :vote_title="vote_title"
    />

    <InfoSection :parent="album" :module_name="module_name" />
    <ItemList
      :items="album.songs"
      :album="album.name"
      :list_title="list_title"
      :list_link_title="list_link_title"
    />
    <ReviewList
      :reviews="reviews_desc"
      :refreshComments="getAlbumData"
      :album="album.name"
      :artist="album.artist.name"
      v-on="$listeners"
    />
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
import ItemList from "@/components/ItemList.vue";
import InfoSection from "@/components/InfoSection.vue";
import ReviewList from "@/components/ReviewList.vue";
import useAlbums from "@/modules/albums";
export default {
  name: "AlbumPage",
  components: {
    Header,
    ItemList,
    InfoSection,
    ReviewList,
  },
  data() {
    return {
      id: this.$route.params.id,
      album: {},
      show_observe_button: false,
      vote_title: "Oceń album",
      module_name: "Album",
      reviews_desc: {},
      list_title: "Utwory",
      list_link_title: "Wyświetl wszystkie utwory",
    };
  },
  methods: {
    prepareReviews() {
      this.reviews_desc = this.album.albumReviews.reverse().slice(0, 3);
    },
  },
  created() {
    this.getAlbumData();
  },
  setup() {
    const { getAlbumFullData } = useAlbums();
    const getAlbumData = function () {
      getAlbumFullData(this.id).then((response) => {
        this.album = response;
        this.prepareReviews();
      });
    };
    return {
      getAlbumData,
    };
  },
};
</script>
