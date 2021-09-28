<template>
  <v-container fluid>
    <Header />
    <!-- <v-row justify="center">
      <v-col class="mt-6" lg="3" sm="6">
        <div>
          <v-img
            :src="require('@/assets/band_logo.jpg')"
            width="300"
            height="300"
          ></v-img>
        </div>
      </v-col>
      <v-col class="my-9" lg="7" sm="7">
        <v-row>
          <v-col sm="12">
            <h1>Anathema</h1>
          </v-col>
          <v-col lg="6" md="10">
            <div>
              <p class="mb-8 text-left">Dodaj do ulubionych:</p>
              <p class="mb-8 text-left">
                <font-awesome-icon
                  class="icon"
                  icon="heart"
                  size="2x"
                  color="#865e61"
                />
                <span>199 osób</span> dodało do ulubionych
              </p>
            </div>
          </v-col>
          <v-col lg="6" md="10">
            <div>
              <p class="mb-8">Oceń artystę:</p>
              <p class="mb-8">
                <font-awesome-icon
                  class="icon"
                  v-for="(star, index) in stars"
                  :key="index"
                  icon="star"
                  size="2x"
                  :color="star.color"
                />
                <span> 4.0</span>
              </p>
            </div>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
    <v-row justify="center">
      <v-col lg="3" sm="6">
        <div class="text-left">
          <h3>Informacje</h3>
          <p>Rok założenia: <span>1990</span></p>
          <p>Czas trwania: <span>55 minut</span></p>
          <p>Gatunek: <span>Rock progresywny, art rock, doom metal</span></p>
        </div>
      </v-col>
      <v-col lg="7">
        <div>
          <h1>Opis albumu</h1>
          <p>
            Anathema (gr. klątwa) to angielska grupa muzyczna. Powstała 1990
            roku w Liverpoolu. Początkowo wykonująca drugofalowy death
            metal/doom metal, będąc wraz z grupami Katatonia, Tiamat, Winter, My
            Dying Bride i Paradise Lost prekursorem gatunku. Obecnie grupa
            zaliczana jest do nurtu art rocka oraz rocka atmosferycznego.
          </p>
        </div>
      </v-col>
    </v-row>
    <v-row justify="center">
      <v-col lg="10">
        <div class="d-flex">
          <h3>Utowry</h3>
          <p class="pl-5">Wyświetl wszystkie utwory</p>
        </div>
      </v-col> -->
    <ItemList :songs="songs" />
    <!-- </v-row> -->
    <ReviewSection />
  </v-container>
</template>

<script>
import ReviewSection from "@/components/ReviewSection.vue";
import Header from "@/components/Header.vue";
import ItemList from "@/components/ItemList.vue";

export default {
  name: "AlbumPage",
  components: {
    ReviewSection,
    Header,
    ItemList,
  },
  data() {
    return {
      id: this.$route.params.id,
      artist: {},
      songs: {},
      reviews: {},
    };
  },
  created() {
    this.getSongs();
  },
  methods: {
    getSongs() {
      this.songs = [
        {
          img: "weather",
          title: "Untochable, pt I",
          album: "Weather Systems",
          rating: "5.0",
        },
        {
          img: "weather",
          title: "Untouchable, pt II",
          album: "Weather Systems",
          rating: 4.9,
        },
        {
          img: "weather",
          title: "The Gathering Of The Cloud",
          album: "Weather Systems",
          rating: 4.9,
        },
      ];
    },
  },
};
</script>
