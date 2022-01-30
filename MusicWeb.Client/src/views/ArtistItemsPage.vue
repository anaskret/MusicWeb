<template>
  <v-container fluid class="py-16">
    <ItemsTable
    :columns_list="album_columns_list"
    :items="albums" 
    :type="album_type"
    :getArtist="getAllAlbums"
    v-on="$listeners"/>
    <ItemsTable
    :columns_list="song_columns_list"
    :items="songs"
    :type="song_type"
    :getArtist="getAllSongs" 
    v-on="$listeners"/>
  </v-container>
</template>
<script>

import useAlbums from "@/modules/albums";
import useSongs from "@/modules/songs";
import ItemsTable from "@/components/ItemsTable";
import { mapGetters } from "vuex";

export default {
  name: "ArtistItemsPage",
  components: {
    ItemsTable,
  },
  data() {
    return {
      album_columns_list: [' ', 'Album name', 'Release date', 'Duration', 'Action'],
      song_columns_list: [' ', 'Song name', 'Release date', 'Duration', 'Action'],
      albums: [], 
      songs: [],
      song_type: "song",
      album_type: "album",
    };
  },
  created() {
    this.getAllAlbums();
    this.getAllSongs();
  },
     computed: {
    ...mapGetters({
      account: "current_user",
    }),
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
    const { getAllForArtist} = useAlbums();
    const { getAllSongsForArtist } = useSongs();
    
    const getAllAlbums = function () {
      getAllForArtist(this.account.artistId).then((response) => {
        this.albums = response;
    });
    }
    
    const getAllSongs = function () {
      getAllSongsForArtist(this.account.artistId).then((response) => {
        this.songs = response;
    });
    }
    
    return {
      getAllAlbums,
      getAllSongs,
    };

  },
};
</script>