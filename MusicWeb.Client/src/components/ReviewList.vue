<template>
  <v-container fluid>
    <v-row justify="center" class="pb-lg-2">
      <v-col lg="8" class="d-flex flex-row justify-space-between">
        <div class="d-flex flex-row" style="align-items: center">
          <h1 class="display-1 font-weight-bold text-left">Recenzje</h1>
          <p class="pl-lg-16">
            Wyświetl wszystkie recenzje
            <font-awesome-icon
              class="icon"
              icon="chevron-right"
              size="1x"
              color="gray"
            />
          </p>
        </div>

        <!--  -->
        <div class="text-center">
          <v-dialog v-model="dialog" width="70vw" height="90vh">
            <template v-slot:activator="{ on, attrs }">
              <v-btn
                outlined
                color="grey"
                height="30px"
                class="text-uppercase align-self-center"
                v-bind="attrs"
                v-on="on"
              >
                Napisz recenzję
              </v-btn>
            </template>

            <form id="reviewForm" @submit.prevent="addReviewDialog">
              <v-card style="background-color: #1e1e1e" class="px-16" height="90vh">
                <v-card-title class="px-0 pt-8 pb-4">Add review</v-card-title>
                <div>
                  <v-text-field label="Title" class="pb-1" v-model="albumReview.title" color="white" />
                  <v-textarea outlined label="Review" rows="13" v-model="albumReview.content" color="white" />
                </div>
                <v-card-actions>
                  <!-- <v-spacer></v-spacer> -->
                  <v-btn color="grey"
                height="30px"
                class="text-uppercase align-self-center pa-3" type="submit" outlined>Add</v-btn>
                </v-card-actions>
              </v-card>
            </form>
          </v-dialog>
        </div>
        <!--  -->
      </v-col>
    </v-row>
    <v-row justify="center">
      <v-col lg="8" sm="10">
        <v-row
          v-for="(review, index) in reviews"
          :key="index"
          class="underline pb-5"
        >
          <v-col lg="2">
            <div class="review-left">
              <!-- TODO Delete class, items center by class   -->
              <!-- <v-img
                max-width="75%"
                :src="require(`@/assets/${review.img}.svg`)"
              ></v-img> -->
              <v-img :src="require('@/assets/BandPhoto.svg')" max-width="60%" />
              <v-card-subtitle color="white">UserName</v-card-subtitle>
              <p>{{ moment(review.postDate).format("L") }}</p>

              <!-- <v-card-title class="text-center"> UserName </v-card-title> -->
            </div>
          </v-col>
          <v-col md="10">
            <v-card>
              <v-card-title class="headline review-title px-0 pt-2 pb-5">
                {{ review.title }}
              </v-card-title>
              <v-card-subtitle class="px-0">
                {{ album }} - {{ artist }}
              </v-card-subtitle>

              <v-spacer></v-spacer>

              <p class="review-text">
                {{ review.content | truncate(reviewTextLength, "...") }}
              </p>
              <v-btn
                outlined
                color="grey"
                height="25px"
                class="text-uppercase align-self-center mt-5"
                >Czytaj dalej
              </v-btn>
              <!-- <v-expansion-panels
                v-if="review.content.length >= reviewTextLength"
              >
                <v-expansion-panel>
                  <v-expansion-panel-header>
                    Czytaj więcej
                  </v-expansion-panel-header>
                  <v-expansion-panel-content>
                    {{ review.content | truncateRest(reviewTextLength) }}
                  </v-expansion-panel-content>
                </v-expansion-panel>
              </v-expansion-panels> -->
            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import AlbumReview from "@/models/AlbumReview";
import useAlbumReviews from "@/modules/albumReviews";
import moment from "moment";
export default {
  name: "ReviewList",
  props: {
    reviews: Array,
    refreshComments: Function,
    album: String,
    artist: String,
  },
  data() {
    return {
      showMore: false,
      reviewTextLength: 305,
      albumReview: new AlbumReview(),
      error: {},
      dialog: false,
      user_id: localStorage.getItem("user-id"),
    };
  },
  methods: {
    addReviewDialog() {
      this.dialog = false;
      this.addNewReview();
    },   
  },
  setup() {
    
    const { addReview } = useAlbumReviews();

    const addNewReview = function () {
      // this.albumReview.userId = this.user_id;
      this.albumReview.userId = this.$store.state.auth.userId;
      this.albumReview.albumId = this.$route.params.id;
      this.albumReview.postDate = moment.utc().format();
      delete this.albumReview.album;
      delete this.albumReview.user;
      if (this.albumReview.title == null || this.albumReview.title == "" || this.albumReview.content == null || this.albumReview.content == "")
      {
        this.$emit("show-alert", "Title or review cannot be empty.", "error");
        this.dialog = true;
      }
     else 
     {
      addReview(this.albumReview).then(
        (response) => {
          if (response.status == 200) {
            this.refreshComments();
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
    };
    return {
      addNewReview,
    };
  }, 

};
</script>
<style scoped>
.underline {
  border-bottom: solid gray 1px;
}
.title {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
.show-all {
  display: flex;
  align-items: flex-end;
  justify-content: center;
}
.review-text {
  text-align: justify;
}
.review-left {
  display: flex;
  flex-direction: column;
  align-items: center;
}
p {
  color: gray;
  margin: 0;
}
</style>
