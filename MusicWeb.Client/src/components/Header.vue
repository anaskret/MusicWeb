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
                  {{ artist.name }}
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
              <div class="d-flex flex-row">
                <font-awesome-icon
                  class="icon pr-2"
                  v-for="(star, index) in stars"
                  :key="index"
                  icon="star"
                  size="2x"
                  :color="star.color"
                ></font-awesome-icon>
                <div class="align-center">
                  <span class="feature-text">4.0</span>
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

export default {
  name: "Header",
  components: {
    RankSection,
  },
  props: {
    artist: {
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
  },
  data() {
    return {
      stars: [
        { color: "#868263" },
        { color: "#868263" },
        { color: "#868263" },
        { color: "#868263" },
        { color: "gray" },
      ],
    };
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
</style>
