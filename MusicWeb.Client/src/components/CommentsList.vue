<template>
  <v-container fluid class="mb-lg-16">
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
              <v-list-item
                v-for="(comment, index) in commentsView"
                :key="index"
              >
                <v-list-item-content
                  :style="
                    index != commentsView.length - 1
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
                        :src="
                          comment.img == ''
                            ? require(`@/assets/unknownUser.svg`)
                            : require(`@/assets/${comment.img}.svg`)
                        "
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
                            {{ comment.date }}
                          </p>
                        </v-col>
                        <v-col
                          class="d-flex justify-left align-center text-justify"
                          lg="12"
                          sm="12"
                        >
                          {{ comment.text }}
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
            v-model="commentPlaceHolder"
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
            @click="loader = 'loading'"
            >Dodaj
            <template v-slot:loader>
              <span class="custom-loader">
                <v-icon>mdi-cached</v-icon>
              </span>
            </template>
          </v-btn>
          <v-spacer></v-spacer>
          <v-btn text @click="$refs.form.reset()"> Wyczyść </v-btn>
        </v-card-actions>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "CommentsList",
  props: {
    comments: Array,
  },
  data() {
    return {
      model: null,
      show: null,
      commentsView: this.comments,
      commentPlaceHolder: this.comments[0].text,
      form: false,
      loader: null,
      loading: false,
    };
  },
  watch: {
    loader() {
      const l = this.loader;
      this[l] = !this[l];

      setTimeout(() => (this[l] = false), 3000);

      this.loader = null;
    },
  },
};
</script>
<style scoped>
p {
  color: gray;
  margin: 0;
}
.custom-loader {
  animation: loader 1s infinite;
  display: flex;
}
@-moz-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@-webkit-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@-o-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
</style>
