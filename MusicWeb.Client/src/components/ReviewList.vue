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

              <v-card-subtitle>
                {{ review.band }}
              </v-card-subtitle>
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
              <v-expansion-panels>
                <v-expansion-panel>
                  <v-expansion-panel-header>
                    Czytaj więcej
                  </v-expansion-panel-header>
                  <v-expansion-panel-content>
                    {{ review.text }}
                  </v-expansion-panel-content>
                </v-expansion-panel>
              </v-expansion-panels>
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
      showMore: false,
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
