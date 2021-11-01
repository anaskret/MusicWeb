<template>
  <div fluid>
    <Header
      :parent="album"
      :show_observe_button="show_observe_button"
      :vote_title="vote_title"
    />

    <InfoSection :parent="album" :module_name="module_name" />
    <ItemList :songs="album.songs" :album="album.name" />
    <ReviewList :reviews="album.albumReviews" :album="album.name" />
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
    };
  },
  created() {
    this.getAlbumData();
  },
  setup() {
    const { getAlbumFullData } = useAlbums();
    const getAlbumData = function () {
      getAlbumFullData(this.id).then((response) => {
        this.album = response;
      });
    };
    return {
      getAlbumData,
    };
  },
};
</script>
