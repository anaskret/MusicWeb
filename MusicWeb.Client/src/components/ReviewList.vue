<template>
  <v-container fluid>
    <v-row justify="center">
      <v-col md="10" sm="10">
        <v-row class="title underline">
          <v-col md="3" sm="2">
            <h1 class="display-1 font-weight-bold text-left">
              Ostatnie recenzje
            </h1>
          </v-col>
          <v-col md="2" sm="10" class="show-all">
            <v-btn
              plain
              color="grey"
              height="20px"
              class="text-uppercase align-self-center"
              >Zobacz wszystko
            </v-btn>
          </v-col>
        </v-row>
        <v-row
          v-for="(review, index) in reviews"
          :key="index"
          class="underline"
        >
          <v-col md="3">
            <v-card>
              <v-img
                max-width="75%"
                :src="require(`@/assets/${review.img}.svg`)"
              ></v-img>

              <v-card-title> {{ review.album }} </v-card-title>

              <v-card-subtitle> {{ review.band }} </v-card-subtitle>
            </v-card>
          </v-col>
          <v-col md="9">
            <v-card>
              <v-card-title class="headline font-italic">
                {{ review.title }}
              </v-card-title>

              <v-spacer></v-spacer>

              <v-card-subtitle class="review-text">
                {{ review.text }}
              </v-card-subtitle>
              <v-card-actions class="flex-column">
                <v-spacer></v-spacer>

                <v-btn
                  icon
                  @click="review_text_truncate = !review_text_truncate"
                >
                  <!-- TODO only one at the time expanding -->
                  <v-icon>{{
                    review_text_truncate ? "mdi-chevron-up" : "mdi-chevron-down"
                  }}</v-icon>
                </v-btn>
              </v-card-actions>

              <v-expand-transition>
                <div v-show="review_text_truncate">
                  <v-card-text>
                    I'm a thing. But, like most politicians, he promised more
                    than he could deliver. You won't have time for sleeping,
                    soldier, not with all the bed making you'll be doing. Then
                    we'll go with that data file! Hey, you add a one and two
                    zeros to that or we walk! You're going to do his laundry?
                    I've got to find a way to escape.
                  </v-card-text>
                </div>
              </v-expand-transition>
            </v-card>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "ReviewList",
  props: {
    reviews: Array,
  },
  data() {
    return {
      review_text_truncate: false,
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
</style>
