<template>
  <v-container fluid class="py-16">
    <ItemsTable
    :columns_list="album_columns_list"
    :items="albums" 
    :type="album_type"/>
    <ItemsTable
    :columns_list="song_columns_list"
    :items="songs"
    :type="song_type" />
  </v-container>
</template>
<script>

import useArtists from "@/modules/artists";
import ItemsTable from "@/components/ItemsTable";
// import Album from "@/models/Album";
// import Song from "@/models/Song";

export default {
  name: "ArtistItemsPage",
  components: {
    ItemsTable,
  },
  data() {
    return {
      artist: {},
      album_columns_list: [' ', 'Album name', 'Release date', 'Duration', 'Edit', 'Delete'],
      song_columns_list: [' ', 'Song name', 'Release date', 'Duration', 'Edit', 'Delete'],
      albums: [], 
      songs: [],
      song_type: "song",
      album_type: "album",
    };
  },
  created() {
    this.getArtist();
    console.log(this.artist);
  },
  methods: {
 redirectToItem() {

        this.$router.push({
          name: 'AlbumPage',
          params: 1,
        });
 }

  },
  setup() {
    const { getArtistById } = useArtists();
    
    const getArtist = function () {
      getArtistById(1).then((response) => {
        this.albums = response.albums;
        this.songs = response.songs;
    });
    }
    
    return {
      getArtist,
    };

  },
};
</script>