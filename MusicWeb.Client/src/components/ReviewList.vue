<template>
  <v-container fluid>
    <v-row justify="center" class="pb-lg-2">
      <v-col sm="12" lg="8" class="d-flex flex-row justify-space-between">
        <div class="d-flex flex-column flex-sm-row">
          <h1 class="display-1 font-weight-bold text-left">Reviews</h1>
          <a v-if="reviews.length != 0 && type_name != 'profile'" class="pl-sm-16 ml-sm-10 pt-sm-3"
          @click="redirectToList(item_id)">
            Show all reviews
            <font-awesome-icon
              class="icon"
              icon="chevron-right"
              size="1x"
              color="gray"
            />
          </a>
          <div v-else class="pl-lg-16">
              <p>Show all album reviews</p>
          </div>
        </div>

        <div class="text-center mt-1">
          <v-dialog v-model="dialog" width="70vw" height="90vh">
            <template v-slot:activator="{ on, attrs }">
              <v-btn
                v-if="type_name != 'profile'"
                outlined
                color="grey"
                height="30px"
                class="text-uppercase align-self-center"
                v-bind="attrs"
                v-on="on"
              >
                Write Review
              </v-btn>
            </template>

            <form id="reviewForm" @submit.prevent="addReviewDialog">
              <v-card
                style="background-color: #1e1e1e"
                class="px-16"
                height="90vh"
              >
                <v-card-title class="px-0 pt-8 pb-4">Add review</v-card-title>
                <div v-if="module_name == 'Album'">
                  <v-text-field
                    label="Title"
                    class="pb-1"
                    v-model="albumReview.title"
                    color="white"
                  />
                  <v-textarea
                    outlined
                    label="Review"
                    rows="13"
                    v-model="albumReview.content"
                    color="white"
                  />
                </div>
                <div v-else>
                  <v-text-field
                    label="Title"
                    class="pb-1"
                    v-model="songReview.title"
                    color="white"
                  />
                  <v-textarea
                    outlined
                    label="Review"
                    rows="13"
                    v-model="songReview.content"
                    color="white"
                  />
                </div>
                <v-card-actions>
                  <v-btn
                    color="grey"
                    height="30px"
                    class="text-uppercase align-self-center pa-3"
                    type="submit"
                    outlined
                    >Add</v-btn
                  >
                </v-card-actions>
              </v-card>
            </form>
          </v-dialog>
        </div>
      </v-col>
    </v-row>
    <v-row justify="center">
      <v-col lg="8" sm="12">
        <v-row
          v-for="(review, index) in reviews"
          :key="index"
          class="underline pb-5"
        >
          <v-col lg="2">
            <div class="review-left">
              <v-img :src="require('@/assets/BandPhoto.svg')" max-width="60%" />
              <v-card-subtitle color="white">{{
                review.userName
              }}</v-card-subtitle>
              <p>{{ moment(review.postDate).format("L") }}</p>
            </div>
          </v-col>
          <v-col lg="10">
            <div>
              <v-card-title class="headline review-title px-0 pt-2 pb-5">
                {{ review.title }} 
              </v-card-title>
              <v-card-subtitle v-if="type_name != 'profile'" class="px-0">
                {{ album }} - {{ artist }}
              </v-card-subtitle>

              <v-spacer></v-spacer>
              <p class="review-text">
                {{ review.content | truncate(reviewTextLength, "...") }}
              </p>
              <v-btn
                v-if="type_name == 'profile'"
                outlined
                color="grey"
                height="25px"
                class="text-uppercase align-self-center mt-5"
                @click="redirectToItemFromProfile(review.id, review.type)"
                >Read More
              </v-btn>
              <v-btn
                v-else
                outlined
                color="grey"
                height="25px"
                class="text-uppercase align-self-center mt-5"
                @click="redirectToItem(review.id)"
                >Read More
              </v-btn>
            </div>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import AlbumReview from "@/models/AlbumReview";
import useAlbumReviews from "@/modules/albumReviews";
import SongReview from "@/models/SongReview";
import useSongReviews from "@/modules/songReviews";
import moment from "moment";
import { mapGetters } from "vuex";
export default {
  name: "ReviewList",
  props: {
    reviews: Array,
    refreshComments: Function,
    album: String,
    artist: String,
    module_name: String,
    redirect_module_name: String,
    redirect_to_list: String,
    item_id: String,
    type_name: String,
  },
  data() {
    return {
      showMore: false,
      reviewTextLength: 305,
      albumReview: new AlbumReview(),
      songReview: new SongReview(),
      error: {},
      dialog: false,
      user_id: localStorage.getItem("user-id"),
    };
  },
  computed: {
      ...mapGetters({
         account: "current_user",
      }),
  },
  methods: {
    addReviewDialog() {
      this.dialog = false;
      if (this.module_name == "Album") {
        this.addNewAlbumReview();
      } else {
        this.addNewSongReview();
      }
    },
    redirectToItem(itemId) {
      this.$router.push({
        name: `${this.redirect_module_name}`,
        params: { id: itemId, module_name: this.module_name },
      });
    },
    redirectToList(item_id) {
      this.$router.push({ name: this.redirect_to_list, params: { id: item_id } });
    },
    redirectToItemFromProfile(id, type) {
      if (type === "album")
      {
        this.$router.push({name: "AlbumReviewPage", params: {id: id}});
      }
      else if (type === "song") {
         this.$router.push({name: "SongReviewPage", params: {id: id}});
      }
    }
  },
  setup() {
    const { addSongReview } = useSongReviews();
    const { addAlbumReview } = useAlbumReviews();

    const addNewSongReview = function () {
      this.songReview.userId = this.account.id;
      this.songReview.songId = this.$route.params.id;
      this.songReview.postDate = moment.utc().format();
      delete this.songReview.id;
      if (
        this.songReview.title == null ||
        this.songReview.title == "" ||
        this.songReview.content == null ||
        this.songReview.content == ""
      ) {
        this.$emit("show-alert", "Title or review cannot be empty.", "error");
        this.dialog = true;
      } else {
        addSongReview(this.songReview).then(
          (response) => {
            if (response.status == 200) {
              this.refreshComments();
              this.songReview.title = null;
              this.songReview.content = null;
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
    };
    const addNewAlbumReview = function () {
      this.albumReview.userId = this.account.id;
      this.albumReview.albumId = this.$route.params.id;
      this.albumReview.postDate = moment().format();
      delete this.albumReview.album;
      delete this.albumReview.user;
      delete this.albumReview.id;
      if (
        this.albumReview.title == null ||
        this.albumReview.title == "" ||
        this.albumReview.content == null ||
        this.albumReview.content == ""
      ) {
        this.$emit("show-alert", "Title or review cannot be empty.", "error");
        this.dialog = true;
      } else {
        addAlbumReview(this.albumReview).then(
          (response) => {
            if (response.status == 200) {
              this.refreshComments();
              this.albumReview.title = null;
              this.albumReview.content = null;
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
    };
    return {
      addNewSongReview,
      addNewAlbumReview,
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
