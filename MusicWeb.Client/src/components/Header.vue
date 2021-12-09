<template>
  <v-container fluid class="py-16">
    <v-row justify="center">
      <v-col lg="3" sm="6" class="pr-lg-12">
        <div>
          <v-img :src="require('@/assets/BandPhoto.svg')" contain />
        </div>
      </v-col>
      <v-col lg="5" sm="12" class="d-flex flex-column">
        <v-row align-content="end" class="pb-lg-2">
          <v-col lg="12" sm="7">
            <div class="d-flex">
              <div>
                <h1 class="text-uppercase font-weight-bold artist-title">
                  {{ parent.name }}
                </h1>
              </div>
              <v-btn
                outlined
                color="grey"
                height="30px"
                v-if="show_observe_button"
                class="text-uppercase align-self-center ml-md-16"
                >Obserwuj
              </v-btn>
            </div>
          </v-col>
        </v-row>
        <v-row>
          <v-col md="12" class="d-flex flex-row pr-lg-5">
            <div>
              <p>Dodaj do ulubionych</p>
              <div class="d-flex flex-row">
                <div align-content="center" class="mr-lg-3">
                  <font-awesome-icon
                    class="icon"
                    icon="heart"
                    size="2x"
                    color="#865e61"
                  ></font-awesome-icon>
                </div>
                <div align-items="center" class="align-center">
                  <span class="feature-text pr-1">199 osób </span> dodało do
                  ulubionych
                </div>
              </div>
            </div>
            <div class="ml-lg-16">
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
        <RankSection />
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
    }
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
      albumRating: new AlbumRating(),
      songRating: new SongRating()
    };
  },
  setup() {
    
    const { addAlbumRating } = useAlbumRatings();
    const { addSongRating } = useSongRatings();

      const addNewAlbumRating = function (ratingId) {
      this.albumRating.userId = this.$store.state.auth.userId;
      this.albumRating.albumId = this.$route.params.id;
      this.albumRating.rating = ratingId;
      
        addAlbumRating(this.albumRating).then(
          (response) => {
            if (response.status == 200) {
            
              this.$emit("show-alert", "Review added.", "success");
            } else {
              this.$emit(
                "show-alert",
                `Nie udało się dodać recenzji. Błąd ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Nie udało się dodać recenzji. ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      }

      const addNewSongRating = function (ratingId) {
      this.songRating.userId = this.$store.state.auth.userId;
      this.songRating.songId = this.$route.params.id;
      this.songRating.rating = ratingId;
      
        addSongRating(this.songRating).then(
          (response) => {
            if (response.status == 200) {
            
              this.$emit("show-alert", "Review added.", "success");
            } else {
              this.$emit(
                "show-alert",
                `Nie udało się dodać recenzji. Błąd ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Nie udało się dodać recenzji. ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      }
    

    return {
      addNewAlbumRating,
      addNewSongRating
    };
  },
  methods: {
    vote: function(event)
    {
      if (this.module_name == "Album")
      {
        this.addNewAlbumRating(event.currentTarget.getAttribute("value"));
      }
      else if (this.module_name == "Song")
      {
        this.addNewSongRating(event.currentTarget.getAttribute("value"));
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
      let value = event.currentTarget.getAttribute("value");
      let rating = document.querySelector("#rating");
      rating.innerText = value + ".0";
      this.colorStars(value);
    },

    getDefaultStars: function()
    {
      console.log("get default");
    }

  },
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;700&display=swap");
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
.star {
  cursor: pointer;
}

.activeStar {
  color: #868263;
}

</style>
