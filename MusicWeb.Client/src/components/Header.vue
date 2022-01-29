<template>
  <v-container fluid class="py-16">
    <v-row justify="center">
      <v-col lg="3" md="4">
        <div class="mediaJustify">
            <v-img
                v-if="parent.imagePath == null || parent.imagePath == ''"
                :src="require(`@/assets/unknownUser.svg`)"
                :alt="`${parent.name}`"
                class="header-image"
                max-width="70vw"
                contain
            />
          <v-img
                v-else-if="parent.imagePath.slice(0, 4) == 'http'"
                :src="`${parent.imagePath}`"
                :alt="`${parent.name}`"
                class="header-image"
                max-width="70vw"
                contain
            />
          <v-img
                v-else
                :src="`${server_url}/${parent.imagePath}`"
                :alt="`${parent.name}`"
                class="header-image"
                max-width="70vw"
                contain
            />
        </div>
      </v-col>
      <v-col lg="5" md="8" class="d-flex flex-column">
        <v-row align-content="end" class="pb-md-2">
          <v-col>
            <div class="d-flex flex-column flex-md-row">
              <div class="d-flex mediaJustify">
                <h1 class="text-uppercase font-weight-bold artist-title mediaHeader">
                  {{ parent.name }}
                </h1>
              </div>
              <v-btn
                outlined
                color="grey"
                height="30px"
                v-if="show_observe_button"
                class="text-uppercase align-self-sm-center ml-md-16"
                @click="addToObserved"
                >{{observe_btn}}
              </v-btn>
            </div>
          </v-col>
        </v-row>
        <v-row>
          <v-col md="12" class="d-flex flex-column flex-md-row pr-lg-5 mediaJustify">
            <div class="mb-5 mb-md-0" >
              <p>Add to favorites:</p>
              <div class="d-flex flex-row">
                <div align-content="center" class="mr-3">
                  <font-awesome-icon
                    class="heart icon"
                    icon="heart"
                    size="2x"
                    :color="heart.color"
                    @click="updateUserFavorite"
                  ></font-awesome-icon>
                </div>
                <div align-items="center" >
                  <span class="feature-text pr-1">{{parent.favoriteCount }} people </span> added to favorites
                </div>
              </div>
            </div>
            <div class="ml-sm-16">
              <p>{{ vote_title }}</p>
              <div class="d-flex flex-row starConteiner" @mouseleave="getDefaultStars">
                <font-awesome-icon
                  class="star icon pr-2"
                  v-for="(star, index) in stars"
                  :key="index"
                  icon="star"
                  size="2x"
                  :color="star.color"
                  @click="vote"
                  @mouseover="countStars"
                  
                  :id="'star_' + index" :value="star.value"
              
                ></font-awesome-icon>
                <div class="align-center">
                  <span class="feature-text" id="rating">0.0</span>
                </div>
              </div>
            </div>
          </v-col>
        </v-row>
        <RankSection :module_name="module_name"/>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import RankSection from "@/components/RankSection.vue";
import useAlbumRatings from "@/modules/albumRatings.js";
import AlbumRating from "@/models/AlbumRating.js";
import useSongRatings from "@/modules/songRatings.js";
import SongRating from "@/models/AlbumRating.js";
import { mapGetters } from "vuex";
import useUserFavoriteAlbums from "@/modules/userFavoriteAlbums.js";
import UserFavoriteAlbum from "@/models/UserFavoriteAlbum.js";
import useUserFavoriteSongs from "@/modules/userFavoriteSongs.js";
import UserFavoriteSong from "@/models/UserFavoriteSong.js";
import useArtistRatings from "@/modules/artistRatings.js";
import ArtistRating from "@/models/ArtistRating.js";
import useUserFavoriteArtists from "@/modules/userFavoriteArtists";
import UserFavoriteArtist from "@/models/UserFavoriteArtist.js";
import useUserObservedArtists from "@/modules/userObservedArtists";
import UserObservedArtist from "@/models/UserObservedArtist.js";
import moment from "moment";

export default {
  name: "Header",
  components: {
    RankSection,
  },
  props: {
    parent: {
      type: Object,
      default: () => ({}),
    },
    show_observe_button: {
      type: Boolean,
      default: false,
    },
    vote_title: {
      type: String,
    },
    module_name: {
      type: String,
    }, 
  },
  data() {
    return {
      stars: [
        { color: "gray", value:1 },
        { color: "gray", value:2 },
        { color: "gray", value:3 },
        { color: "gray", value:4 },
        { color: "gray", value:5 },
      ],
      heart: {color: "gray"},
      albumRating: new AlbumRating(),
      songRating: new SongRating(),
      artistRating: new ArtistRating(),
      id: this.$route.params.id, 
      user_id: localStorage.getItem("user-id"), 
      userFavoriteAlbum: new UserFavoriteAlbum(),
      userFavoriteSong: new UserFavoriteSong(),
      userFavoriteArtist: new UserFavoriteArtist(),
      userObservedArtist: new UserObservedArtist(),
      observe_btn: "Observe",
    };
  },
  setup() {
    
    const { addAlbumRating, getUserRating, updateUserRating } = useAlbumRatings();
    const { addSongRating, getSongUserRating, updateSongUserRating } = useSongRatings();
    const { addArtistRating, getUserArtistRating, updateUserArtistRating } = useArtistRatings();
    const { getUserFavoriteAlbum, deleteUserFavoriteAlbum, addUserFavoriteAlbum } = useUserFavoriteAlbums();   
    const { getUserFavoriteSong, deleteUserFavoriteSong, addUserFavoriteSong } = useUserFavoriteSongs();   
    const { getUserFavoriteArtist, deleteUserFavoriteArtist, addUserFavoriteArtist } = useUserFavoriteArtists();   
    const { getUserObservedArtist, addUserObservedArtist, deleteUserObservedArtist} = useUserObservedArtists();   
    

      const addNewAlbumRating = function (ratingId) {
      this.albumRating.userId = this.account.id;
      this.albumRating.albumId = this.$route.params.id;
      this.albumRating.rating = ratingId;
      
        addAlbumRating(this.albumRating).then(
          (response) => {
            if (response.status == 200) {
              this.$emit("getRating");
              this.getAlbumRating();
              this.$emit("show-alert", "Review added.", "success");
            } else {
              this.$emit(
                "show-alert",
                `Error while adding review. Error ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Error while adding review. ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      }

      const updateAlbumUserRating = function (ratingId) {
      this.albumRating.rating = ratingId;
        updateUserRating(this.albumRating).then(
          (response) => {
            if (response.status == 200) {
              this.$emit("getRating");
              this.$emit("show-alert", "Review added.", "success");
              
            } else {
              this.$emit(
                "show-alert",
                `Error while adding review. Error ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Error while adding review. ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      }
const addNewArtistRating = function (ratingId) {
      this.artistRating.userId = this.account.id;
      this.artistRating.artistId = this.$route.params.id;
      this.artistRating.rating = ratingId;
      
        addArtistRating(this.artistRating).then(
          (response) => {
            if (response.status == 200) {
              this.$emit("getRating");
              this.getArtistRating();
              this.$emit("show-alert", "Review added.", "success");
            } else {
              this.$emit(
                "show-alert",
                `Error while adding review. Error ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Error while adding review. ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      }

      const updateArtistRating = function (ratingId) {
      this.artistRating.rating = ratingId;
        updateUserArtistRating(this.artistRating).then(
          (response) => {
            if (response.status == 200) {
              this.$emit("getRating");
              this.$emit("show-alert", "Review added.", "success");
              
            } else {
              this.$emit(
                "show-alert",
                `Error while adding review. Error ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Error while adding review. ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      }  

    const updateSongRating = function (ratingId) {
      this.songRating.rating = ratingId;
        updateSongUserRating(this.songRating).then(
          (response) => {
            if (response.status == 200) {
              this.$emit("getRating");
              this.$emit("show-alert", "Review added.", "success");
              
            } else {
              this.$emit(
                "show-alert",
                `Error while adding review. Error ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Error while adding review. ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      }

      const addNewSongRating = function (ratingId) {
      this.songRating.userId = this.account.id;
      this.songRating.songId = this.$route.params.id;
      this.songRating.rating = ratingId;
      
        addSongRating(this.songRating).then(
          (response) => {
            if (response.status == 200) {
              this.$emit("getRating");
              this.getSongRating();
              this.$emit("show-alert", "Review added.", "success");
            } else {
              this.$emit(
                "show-alert",
                `Error while adding review. Error ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Error while adding review.  ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      }

      const getAlbumRating = function () {
        getUserRating(this.id, this.user_id).then((response) => {
          this.albumRating = response;
          this.getDefaultStars(this.albumRating.rating);
          
      });
    };      
    const getSongRating = function () {
        getSongUserRating(this.id, this.user_id).then((response) => {
          this.songRating = response;
          this.getDefaultStars(this.songRating.rating);
          
      });
    };    
    const getArtistRating = function () {
        getUserArtistRating(this.id, this.user_id).then((response) => {
          this.artistRating = response;
          this.getDefaultStars(this.artistRating.rating);
          
      });
    };

    const getUserAlbum = function () {
      getUserFavoriteAlbum(this.user_id, this.$route.params.id).then((response) => {
        this.userFavoriteAlbum = response;
         this.colorHeart();
          
      });
    };  
    
        const deleteFavoriteAlbum = function (id) {
        deleteUserFavoriteAlbum(id).then(() => {
          this.$emit("getRating");
         this.userFavoriteAlbum = {};
         this.colorHeart();
          
      });
    };

    
      const addFavoriteAlbum = function () {
      this.userFavoriteAlbum.userId = this.account.id;
      this.userFavoriteAlbum.favoriteId = this.$route.params.id;
      delete this.userFavoriteAlbum.id;
      delete this.userFavoriteAlbum.user;
      delete this.userFavoriteAlbum.album;
      
      
        addUserFavoriteAlbum(this.userFavoriteAlbum).then(
          (response) => {
            if (response.status == 200) {
              this.$emit("getRating");
              this.$emit("show-alert", "Review added.", "success");
              this.getUserAlbum();
            } else {
              this.$emit(
                "show-alert",
                `Error while adding review. Error ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Error while adding review.  ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      }
      const getUserSong = function () {
      getUserFavoriteSong(this.user_id, this.$route.params.id).then((response) => {
        this.userFavoriteSong = response;
         this.colorHeart();
          
      });
    };  
    
        const deleteFavoriteSong = function (id) {
        deleteUserFavoriteSong(id).then(() => {
          this.$emit("getRating");
         this.userFavoriteSong = {};
         this.colorHeart();
          
      });
    };

    
      const addFavoriteSong = function () {
      this.userFavoriteSong.userId = this.account.id;
      this.userFavoriteSong.favoriteId = this.$route.params.id;
      delete this.userFavoriteSong.id;
      delete this.userFavoriteSong.user;
      delete this.userFavoriteSong.song;
      
      
        addUserFavoriteSong(this.userFavoriteSong).then(
          (response) => {
            if (response.status == 200) {
              this.$emit("getRating");
              this.$emit("show-alert", "Review added.", "success");
              this.getUserSong();
            } else {
              this.$emit(
                "show-alert",
                `Error while adding review. Error ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Error while adding review.  ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      }

      const getUserArtist = function () {
      getUserFavoriteArtist(this.user_id, this.$route.params.id).then((response) => {
        this.userFavoriteArtist = response;
         this.colorHeart();
          
      });
    };  
    
        const deleteFavoriteArtist = function (id) {
        deleteUserFavoriteArtist(id).then(() => {
          this.$emit("getRating");
         this.userFavoriteArtist = {};
         this.colorHeart();
          
      });
    };

      const addFavoriteArtist = function () {
      this.userFavoriteArtist.userId = this.account.id;
      this.userFavoriteArtist.favoriteId = this.$route.params.id;
      delete this.userFavoriteArtist.id;
      delete this.userFavoriteArtist.user;
      delete this.userFavoriteArtist.artist;      
      
        addUserFavoriteArtist(this.userFavoriteArtist).then(
          (response) => {
            if (response.status == 200) {
              this.$emit("getRating");
              this.$emit("show-alert", "Review added.", "success");
              this.getUserArtist();
            } else {
              this.$emit(
                "show-alert",
                `Error while adding review. Error ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Error while adding review.  ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      }

    
      const addObservedArtist = function () {
      this.userObservedArtist.userId = this.account.id;
      this.userObservedArtist.favoriteId = this.$route.params.id;
      this.userObservedArtist.favoriteDate = moment().format();
      delete this.userFavoriteArtist.id;
      delete this.userFavoriteArtist.user;
      delete this.userFavoriteArtist.artist;
      
      
        addUserObservedArtist(this.userObservedArtist).then(
          (response) => {
            if (response.status == 200) {
              this.getObservedArtist();
              this.$emit("show-alert", "Review added.", "success");
            } else {
              this.$emit(
                "show-alert",
                `Error while adding review. Error ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Error while adding review.  ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      }

      const getObservedArtist = function () {
      getUserObservedArtist(this.user_id, this.$route.params.id).then((response) => {
        this.userObservedArtist = response;
        if (this.userObservedArtist.id != null)
        {
          this.observe_btn = "Observed";
        }       
      });
    };  

    const deleteObservedArtist = function (id) {
        deleteUserObservedArtist(id).then(() => {
         this.userObservedArtist = {};
         this.observe_btn = "Observe";
          
      });
    };

    return {
      addNewAlbumRating,
      addNewSongRating, 
      getAlbumRating,
      updateAlbumUserRating,
      getSongRating,
      updateSongRating, 
      getUserAlbum,
      deleteFavoriteAlbum,
      addFavoriteAlbum,      
      getUserSong,
      deleteFavoriteSong,
      addFavoriteSong,
      addNewArtistRating,
      updateArtistRating,
      getArtistRating,
      addFavoriteArtist, 
      deleteFavoriteArtist,
      getUserArtist,
      getObservedArtist,
      addObservedArtist,
      deleteObservedArtist,
    };
  },
  computed: {
      ...mapGetters({
         account: "current_user",
         server_url: "server_url",
      }),
  },
  methods: {
    vote: function(event)
    {
      let ratingId = event.currentTarget.getAttribute("value");
      
      if (this.module_name == "Album")
      {
        if (this.albumRating.id > 0)
        {
          this.updateAlbumUserRating(ratingId);
        }
        else 
        {
          this.addNewAlbumRating(ratingId);
        }
      }
      else if (this.module_name == "Song")
      {
        if (this.songRating.id > 0)
        {
          this.updateSongRating(ratingId);
        }
        else 
        {
          this.addNewSongRating(ratingId);
        }
      } 
      else if (this.module_name == "Artist")
      {
        if (this.artistRating.id > 0)
        {
          this.updateArtistRating(ratingId);
        }
        else 
        {
          this.addNewArtistRating(ratingId);
        }
      }
    },

    colorStars: function(value)
    {
      let stars = document.querySelectorAll(".star");
      stars.forEach(star => {
        if (star.getAttribute("value") <= value)
        {
          star.classList.add("activeStar");
        }
        else
        {
          star.classList.remove("activeStar");
        }
      });
    },

    countStars: function(event)
    { 
      let value;
      if (event) {
        value = event.currentTarget.getAttribute("value");
      }
      else if (this.module_name == "Album"){
        value = this.albumRating.rating;
      }
      else if (this.module_name == "Song")
      {
        value = this.songRating.rating;
      }
      else if (this.module_name == "Artist")
      {
        value = this.artistRating.rating;
      }
      if (value == "")
      {
        value = "0";
      }
      let rating = document.querySelector("#rating");
      rating.innerText = value + ".0";
      this.colorStars(value);
    },

    getDefaultStars: function(rating)
    {
      this.colorStars(rating);
      this.countStars();
    },

    colorHeart: function() 
    {
      let heart = document.querySelector(".heart");
      let parentId;
      if (this.module_name == "Album")
      {
        parentId = this.userFavoriteAlbum.albumId;
      }
      else if (this.module_name == "Song")
      {
        parentId = this.userFavoriteSong.songId;
      }
      else if (this.module_name == "Artist")
      {
        parentId = this.userFavoriteArtist.artistId;
      }

      if (parentId == this.$route.params.id)
      {
        heart.classList.add("activeHeart");
      }
      else
      {
        heart.classList.remove("activeHeart");
      }
    },
    updateUserFavorite: function()
    {
       if (this.module_name == "Album")
      {
        if (this.userFavoriteAlbum.albumId != null)
        {
          this.deleteFavoriteAlbum(this.userFavoriteAlbum.id);
          

        }
        else {
          this.addFavoriteAlbum();
        }
      }
      else if (this.module_name == "Song")
      {
        if (this.userFavoriteSong.songId != null)
        {
          this.deleteFavoriteSong(this.userFavoriteSong.id);
        }
        else {
          this.addFavoriteSong();
        }
      }
      else if (this.module_name == "Artist")
      {
        if (this.userFavoriteArtist.artistId != null)
        {
          this.deleteFavoriteArtist(this.userFavoriteArtist.id);
        }
        else {
          this.addFavoriteArtist();
        }
      }
    }, 
    addToObserved: function() {
      if (this.userObservedArtist.id == null)
      {
        this.addObservedArtist();
      }
      else
      {

        this.deleteObservedArtist(this.userObservedArtist.id);
      }

    }

  },
  created() {
    if (this.module_name == "Album")
    {
      this.getAlbumRating();
      this.getUserAlbum();
    }
    else if (this.module_name == "Song")
    {
      this.getSongRating();
      this.getUserSong();
    }
    else if (this.module_name == "Artist")
    {
      this.getArtistRating();
      this.getUserArtist();
      this.getObservedArtist();
    }
  }
};
</script>

<style scoped>
.artist-title {
  letter-spacing: 5px;
  font-size: 3.2rem;
}
.align-center {
  display: flex;
  align-items: center;
}
template {
  font-family: "Montserrat";
}
p {
  font-size: 1rem;
}
.feature-text {
  font-size: 1rem;
}
.star, .heart {
  cursor: pointer;
}

.activeStar {
  color: #868263;
}
.activeHeart {
  color: #865e61;
}
.header-image{
    border-radius: 50%;
}
@media (max-width: 900px) {
  .mediaJustify {
     display: flex;
     justify-content: center; }
}
@media (max-width: 600px) {
  .mediaHeader {
     font-size: 2rem!important; }
}
</style>
