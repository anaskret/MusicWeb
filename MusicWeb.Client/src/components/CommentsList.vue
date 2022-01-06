<template>
  <!-- TODO Scroll to page bottom -->
  <v-container id="container" fluid class="mb-lg-16">
    <v-row justify="center" class="pb-lg-2">
      <v-col lg="8">
        <h1 class="display-1 font-weight-bold text-left">Komentarze</h1>
      </v-col>
    </v-row>
    <v-row justify="center">
      <v-col lg="8">
        <div class="mx-auto">
          <v-list>
            <v-list-item-group v-model="show">
              <v-list-item v-for="(comment, index) in comments" :key="index">
                <v-list-item-content
                  :style="
                    index != comments.length - 1
                      ? {
                          borderBottom: '1px solid #cbcbf233',
                        }
                      : ''
                  "
                  class="pb-lg-10"
                >
                  <v-row>
                    <v-col
                      class="d-flex justify-center align-center"
                      lg="1"
                      sm="1"
                    >
                      <img
                        :src="require(`@/assets/unknownUser.svg`)"
                        :alt="comment.userName"
                        width="100%"
                      />
                    </v-col>
                    <v-col
                      class="d-flex justify-center align-center"
                      lg="11"
                      sm="11"
                    >
                      <v-row>
                        <v-col
                          class="d-flex justify-start align-center"
                          lg="6"
                          sm="6"
                        >
                          <h1 class="title">
                            {{ comment.userName }}
                          </h1>
                        </v-col>
                        <v-col
                          class="d-flex justify-end align-center"
                          lg="6"
                          sm="6"
                        >
                          <p>
                            {{ comment.postDate }}
                          </p>
                        </v-col>
                        <v-col
                          class="d-flex justify-left align-center text-justify"
                          lg="12"
                          sm="12"
                        >
                          {{ comment.content }}
                        </v-col>
                      </v-row>
                    </v-col>
                  </v-row>
                </v-list-item-content>
              </v-list-item>
            </v-list-item-group>
          </v-list>
        </div>
        <v-form ref="form" v-model="form" class="pt-lg-10">
          <v-textarea
            v-model="comment.content"
            auto-grow
            filled
            color="inherit"
            label="Dodaj komentarz..."
            rows="5"
          ></v-textarea>
        </v-form>
        <v-divider></v-divider>
        <v-card-actions>
          <v-btn
            :disabled="!form"
            outlined
            color="grey"
            height="30px"
            width="25%"
            class="text-uppercase"
            :loading="loading"
            @click="addComment"
            >Dodaj
          </v-btn>
          <v-spacer></v-spacer>
          <v-btn text @click="$refs.form.reset()"> Wyczyść </v-btn>
        </v-card-actions>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import Comment from "@/models/Comment";
import useComments from "@/modules/comments";
import moment from "moment";
export default {
  name: "CommentsList",
  props: {
    comments: Array,
    artistId: Number,
    refreshComments: Function,
  },
  data() {
    return {
      model: null,
      show: null,
      form: false,
      loading: false,
      comment: new Comment(),
    };
  },
  methods: {
    scrollToEnd() {
      var container = document.querySelector("#container");
      container.scrollTop = container.scrollHeight; //TODO Scroll to page bottom
    },
  },
  watch: {
    loader() {
      const l = this.loader;
      this[l] = !this[l];

      setTimeout(() => (this[l] = false), 3000);

      this.loader = null;
    },
  },
  setup() {
    const { postNewComment } = useComments();

    const addComment = function () {
      this.loading = true;
      this.comment.postDate = moment().format();
      this.comment.artistId = this.artistId;
      this.comment.userId = this.$store.state.auth.userId;
      if (this.comment.content == null || this.comment.content == "") {
        this.$emit("show-alert", "Komentarz nie może być pusty.", "error");
        this.loading = false;
      } else {
        postNewComment(this.comment)
          .then((response) => {
            if (response.status === 200) {
              this.$emit(
                "show-alert",
                "Komentarz został zamieszczony.",
                "success"
              );
              this.refreshComments();
              this.comment = new Comment();
              // this.scrollToEnd(); //TODO Scroll to page bottom
            } else {
              this.$emit("show-alert", "Błąd dodawania komentarza.", "error");
            }
          })
          .catch((err) => {
            this.$emit("show-alert", err, "error");
          });
        this.loading = false;
      }
    };

    return {
      addComment,
    };
  },
};
</script>
