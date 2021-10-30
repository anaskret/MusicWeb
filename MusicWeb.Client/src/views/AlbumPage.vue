<template>
  <div fluid>
    <Header
      :parent="album"
      :show_observe_button="show_observe_button"
      :vote_title="vote_title"
    />

    <InfoSection :parent="album" :module_name="module_name" />
    <ItemList :songs="songs" />
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
import ItemList from "@/components/ItemList.vue";
import InfoSection from "@/components/InfoSection.vue";
import useAlbums from "@/modules/albums";
export default {
  name: "Album Page",
  components: {
    Header,
    ItemList,
    InfoSection,
  },
  data() {
    return {
      id: this.$route.params.id,
      album: {},
      songs: [],
    };
  },

  setup() {
    const { getAlbumFullData } = useAlbums();
    const getAlbumData = function () {
      getAlbumFullData(this.id).then((response) => {
        return (this.album = response);
      });
      console.log(this.album);
    };
    return {
      getAlbumData,
    };
  },
};
</script>
