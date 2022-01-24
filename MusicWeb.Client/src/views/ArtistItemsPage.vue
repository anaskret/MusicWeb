<template>
  <v-container fluid class="py-16">
    {{artist}}
  <!-- <v-data-table
    :headers="headers"
    :items="desserts"
    :items-per-page="5"
    class="elevation-1"
  ></v-data-table> -->
  </v-container>
</template>
<script>

import useArtists from "@/modules/artists";
// import Album from "@/models/Album";
// import Song from "@/models/Song";

export default {
  name: "ArtistItemsPage",
  components: {
  },
  data() {
    return {
      artist: {},
    };
  },
  created() {
    this.getArtist();
    console.log(this.artist);
  },
  methods: {
 

  },
  setup() {
    const { getArtistById } = useArtists();
    
    const getArtist = function () {
      getArtistById(3).then((response) => {
        this.artist = response;
        // console.log(response);
        // this.getArtistRating();
    });
    }
    // const { addSong} = useSongs();
    // const { getAll } = useGenres();

    //  const addNewAlbum = function () {
    //    console.log(this.album.name);
    //   this.album.artistId = 3;
    //   this.album.isConfirmed = false;
    //     console.log(this.album);
    //   if (
    //     this.album.name == null ||
    //     this.album.name == "" ||
    //     this.album.releaseDate == null ||
    //     this.album.releaseDate == "" ||
    //     this.album.albumGenreId == null ||
    //     this.album.albumGenreId == "" ||
    //     this.album.duration == null ||
    //     this.album.duration == "" ||
    //     this.album.description == null ||
    //     this.album.description == ""
    //   ) {
    //     this.$emit("show-alert", "Album data cannot be empty.", "error");
    //     this.dialog = true;
    //   } else {
    //     addAlbum(this.album).then(
    //       (response) => {
    //         if (response.status == 200) {
    //           this.$emit("show-alert", "Album added.", "success");
    //         } else {
    //           this.$emit(
    //             "show-alert",
    //             `Album cannot be added. Error ${response.status}. Please try again later.`,
    //             "error"
    //           );
    //         }
    //       },
    //       (error) => {
    //         this.$emit(
    //           "show-alert",
    //           `Album cannot be added. Error  ${error.response.status} ${error.response.data}.  Please try again later.`,
    //           "error"
    //         );
    //       }
    //     );
    //   }
    // };
    //  const addNewSong = function () {
    //    delete this.song.id;
    //   this.song.composerId = 3;
    //   this.song.albumId = 4;
    //     console.log(this.song);
    //   if (
    //     this.song.name == null ||
    //     this.song.name == "" ||
    //     this.song.releaseDate == null ||
    //     this.song.releaseDate == "" ||
    //     this.song.length == null ||
    //     this.song.length == "" ||
    //     this.song.positionOnAlbum == null ||
    //     this.song.positionOnAlbum == "" ||
    //     this.song.text == null ||
    //     this.song.text == ""
    //   ) {
    //     this.$emit("show-alert", "Song data cannot be empty.", "error");
    //     this.dialog = true;
    //   } else {
    //     addSong(this.song).then(
    //       (response) => {
    //         if (response.status == 200) {
    //           this.$emit("show-alert", "Song added.", "success");
    //         } else {
    //           this.$emit(
    //             "show-alert",
    //             `Song cannot be added. Error ${response.status}. Please try again later.`,
    //             "error"
    //           );
    //         }
    //       },
    //       (error) => {
    //         this.$emit(
    //           "show-alert",
    //           `Song cannot be added. Error  ${error.response.status} ${error.response.data}.  Please try again later.`,
    //           "error"
    //         );
    //       }
    //     );
    //   }
    // };

    // const getAlbumGenres = function () {
    //   getAll().then((response) => {
    //     // this.genres = [];
    //     // response.forEach((item) => this.genres.push(item));
    //     this.genres = response;
       
    //   });
    // };
    return {
      getArtist,
    };

  },
};
</script>