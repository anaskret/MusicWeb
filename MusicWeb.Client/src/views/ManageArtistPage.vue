<template>
  <v-container fluid class="py-16">
    <CreateItem
    v-if="type == 'album' && id == null"
    :item="album"
    :dataArray="genres"
    :createAlbum="createAlbum"
    :submitForm="submitAlbumForm"
    :type="type"
    :title="create_album_title"/>
    <CreateItem
    v-if="type == 'album' && id != null"
    :item="album"
    :dataArray="genres"
    :createAlbum="createAlbum"
    :submitForm="submitUpdateAlbumForm"
    :type="type"
    :title="update_album_title"/>
    <CreateItem
    v-else-if="type == 'song' && id == null"
    :item="song"
    :submitForm="submitSongForm"
    :type="type"
    :title="create_song_title"
    :dataArray="albums"/>
    <CreateItem
    v-else-if="type == 'song' && id != null"
    :item="song"
    :submitForm="submitUpdateSongForm"
    :type="type"
    :title="update_song_title"
    :dataArray="albums"/>
  </v-container>
</template>
<script>

import useAlbums from "@/modules/albums";
import useSongs from "@/modules/songs";
import useGenres from "@/modules/genres";
import Album from "@/models/Album";
import Song from "@/models/Song";
import CreateItem from "@/components/CreateItem";
import moment from "moment";

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
      albums: [],
      albumName: '',
      releaseDate: '',
      albumDuration: '',
      description: '',
      image: '',
      songName: '', 
      length: '', 
      positionOnAlbum: '',
      text: '',
      type: this.$route.params.type,
      id: this.$route.params.id,
      create_album_title: "Create Album",
      create_song_title: "Create Song",
      update_album_title: "Update album",
      update_song_title: "Update song",
    };
  },
  created() {
    if (this.type == "song")
    {
      this.getAllAlbums();
      if (this.id != null)
      {
        this.getSongData(this.id);
      }

    }
    else if (this.type == "album")
    {
      this.getAlbumGenres();
      if (this.id != null)
      {
        this.getAlbumData(this.id);
      }
    }
  },
  methods: {
    submitAlbumForm: function() {
      this.addNewAlbum();
    },
    submitSongForm: function() {
      this.addNewSong();
    },  
    submitUpdateSongForm: function() {
      this.updateSongData();
    },
    submitUpdateAlbumForm: function() {
      this.updateAlbumData();
    },
     redirectTo() {
        this.$router.push({name: 'ArtistItemsPage'});
 }
  },
  setup() {
    const { addAlbum, getAllForArtist, getAlbumFullData, updateAlbum} = useAlbums();
    const { addSong, updateSong,  getSongFullData } = useSongs();
    const { getAllGenres } = useGenres();
    
    const getAllAlbums = function () {
      getAllForArtist(1).then((response) => {
        this.albums = response;
    });
    }

     const addNewAlbum = function () {
      this.album.artistId = 1;
      this.album.isConfirmed = false;
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
              this.redirectTo();
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

     const updateAlbumData = function () {
      this.album.artistId = 1;
      this.album.isConfirmed = false;
      this.album.id = this.id;
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
        updateAlbum(this.album).then(
          (response) => {
            if (response.status == 200) {
              this.redirectTo();
              this.$emit("show-alert", "Album updated.", "success");
            } else {
              this.$emit(
                "show-alert",
                `Album cannot be updated. Error ${response.status}. Please try again later.`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Album cannot be updated. Error  ${error.response.status} ${error.response.data}.  Please try again later.`,
              "error"
            );
          }
        );
      }
    };
     const addNewSong = function () {
       delete this.song.id;
      this.song.composerId = 1;
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
              this.redirectTo();
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

     const updateSongData = function () {
      this.song.composerId = 1;
      this.song.id = this.id;
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
        updateSong(this.song).then(
          (response) => {
            if (response.status == 200) {
              this.redirectTo();
              this.$emit("show-alert", "Song updated", "success");
            } else {
              this.$emit(
                "show-alert",
                `Song cannot be updated. Error ${response.status}. Please try again later.`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Song cannot be updated. Error  ${error.response.status} ${error.response.data}.  Please try again later.`,
              "error"
            );
          }
        );
      }
    };

    const getAlbumGenres = function () {
      getAllGenres().then((response) => {
        this.genres = response;
       
      });
    };

    const getSongData = function () {
      getSongFullData(this.id).then((response) => {
        this.song = response;
      });
    };

     const getAlbumData = function () {
      getAlbumFullData(this.id).then((response) => {
        this.album = response;
        this.album.releaseDate = moment(this.album.releaseDate).format("YYYY-MM-DD");
      });
    };

 

    return {
      addNewAlbum,
      addNewSong,
      getAlbumGenres,
      getAllAlbums,
      getSongData,
      updateSongData,
      getAlbumData,
      updateAlbumData,
    };

  },
};
</script>