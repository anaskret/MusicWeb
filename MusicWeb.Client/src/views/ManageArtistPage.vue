<template>
  <v-container fluid class="py-16">
    <!-- <CreateItem
    :album="album"
    :genres="genres"
    :createAlbum="createAlbum"
    :nameRules="nameRules"
    :submitForm="submitForm"/> -->
    <CreateItem
    :item="song"
    :genres="genres"
    :nameRules="nameRules"
    :submitForm="submitForm"
    item_type="song"/>
  </v-container>
</template>
<script>

import useAlbums from "@/modules/albums";
import useSongs from "@/modules/songs";
import useGenres from "@/modules/genres";
import Album from "@/models/Album";
import Song from "@/models/Song";
import CreateItem from "@/components/CreateItem";

export default {
  name: "ManageArtistPage",
  components: {
    CreateItem,
  },
  data() {
    return {
      createAlbum: false,
      album: new Album(),
      song: new Song(),
      genres: [],
      albumName: '',
      releaseDate: '',
      albumDuration: '',
      description: '',
      image: '',
      nameRules: [
      v => !!v || 'Name is required',
    ],
      songName: '', 
      length: '', 
      positionOnAlbum: '',
      text: '',
    };
  },
  created() {
    this.getAlbumGenres();
    console.log(this.genres);
  },
  methods: {
    submitForm: function() {
      // this.addNewAlbum();
      this.addNewSong();
    }

  },
  setup() {
    const { addAlbum } = useAlbums();
    const { addSong} = useSongs();
    const { getAll } = useGenres();

     const addNewAlbum = function () {
       console.log(this.album.name);
      this.album.artistId = 3;
      this.album.isConfirmed = false;
        console.log(this.album);
      if (
        this.album.name == null ||
        this.album.name == "" ||
        this.album.releaseDate == null ||
        this.album.releaseDate == "" ||
        this.album.albumGenreId == null ||
        this.album.albumGenreId == "" ||
        this.album.duration == null ||
        this.album.duration == "" ||
        this.album.description == null ||
        this.album.description == ""
      ) {
        this.$emit("show-alert", "Album data cannot be empty.", "error");
        this.dialog = true;
      } else {
        addAlbum(this.album).then(
          (response) => {
            if (response.status == 200) {
              this.$emit("show-alert", "Album added.", "success");
            } else {
              this.$emit(
                "show-alert",
                `Album cannot be added. Error ${response.status}. Please try again later.`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Album cannot be added. Error  ${error.response.status} ${error.response.data}.  Please try again later.`,
              "error"
            );
          }
        );
      }
    };
     const addNewSong = function () {
      //  this.song.name="test";
      //  this.song.length = 5;
      //  this.song.positionOnAlbum = 2;
      //  this.song.releaseDate = "2022-01-24T12:39:31.311Z";
      //  this.song.text = "vdv";
      //  this.song.length = 2;
       delete this.song.id;
      this.song.composerId = 3;
      this.song.albumId = 4;
      // delete this.song.album;
      // delete this.song.albumName;
      // delete this.song.artistName;
      // delete this.song.composer;
      // delete this.song.description;
      // delete this.song.duration;
      // delete this.song.favoriteCount;
      // delete this.song.ratingsCount;
      // delete this.song.reviewsCount;
      // delete this.song.rating;
      // delete this.song.songReviews;
        console.log(this.song);
      if (
        this.song.name == null ||
        this.song.name == "" ||
        this.song.releaseDate == null ||
        this.song.releaseDate == "" ||
        this.song.length == null ||
        this.song.length == "" ||
        this.song.positionOnAlbum == null ||
        this.song.positionOnAlbum == "" ||
        this.song.text == null ||
        this.song.text == ""
      ) {
        this.$emit("show-alert", "Song data cannot be empty.", "error");
        this.dialog = true;
      } else {
        addSong(this.song).then(
          (response) => {
            if (response.status == 200) {
              this.$emit("show-alert", "Song added.", "success");
            } else {
              this.$emit(
                "show-alert",
                `Song cannot be added. Error ${response.status}. Please try again later.`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Song cannot be added. Error  ${error.response.status} ${error.response.data}.  Please try again later.`,
              "error"
            );
          }
        );
      }
    };

    const getAlbumGenres = function () {
      getAll().then((response) => {
        // this.genres = [];
        // response.forEach((item) => this.genres.push(item));
        this.genres = response;
       
      });
    };
    return {
      addNewAlbum,
      addNewSong,
      getAlbumGenres,
    };

  },
};
</script>