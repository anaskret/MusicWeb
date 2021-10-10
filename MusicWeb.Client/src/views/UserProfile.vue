<template>
  <v-container fluid class="py-16 d-flex justify-center">
    <v-row justify="center">
      <v-col md="2" sm="6">
        <v-img :src="require('@/assets/BandPhoto.svg')" contain />
      </v-col>
      <v-col md="5" sm="9">
        <v-row class="d-flex align-items-center">
          <v-col md="12" class="title-text">
            <h1 class="text-uppercase display-2">Użytkownik</h1>
            <v-btn
              outlined
              color="grey"
              height="30px"
              class="text-uppercase align-self-center"
              >Ustawienia
            </v-btn>
          </v-col>
          <v-col md="12" class="favorites">
            <p>
              Ulubiony artysta:
              <span> Anathema </span>
            </p>
            <p>
              Ulubiony album:
              <span> Weather Systems </span>
            </p>
            <p>
              Ulubiony utwór:
              <span> Untouchable pt. I </span>
            </p>
          </v-col>
        </v-row>
      </v-col>
      <v-col md="12">
        <ReviewList :reviews="reviews" />
      </v-col>
      <v-col md="12">
        <item-carousel :items="artists" :componentTitle="artistsTitle" :componentLinkTitle="artistsLinkTitle"/>  
      </v-col>
      <v-col md="12">
        <item-carousel :items="genres" :componentTitle="genresTitle" :componentLinkTitle="genresLinkTitle"/>  
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import ReviewList from "@/components/ReviewList";
import ItemCarousel from '../components/ItemCarousel.vue';
export default {
  name: "UserProfile",
  components: {
    ReviewList,
    ItemCarousel,
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
      reviews: [],
      artists: [],
      genres: [],
      artistsTitle: "Ulubieni artyści",
      genresTitle: "Ulubione gatunki",
      artistsLinkTitle: "Zobacz wszystko",
      genresLinkTitle: "Zobacz wszystko"
    };
  },
  created() {
    this.getReviews();
    this.getArtists();
    this.getGenres();
  },
  methods: {
    getReviews() {
      this.reviews = [
        {
          img: "weather",
          album: "Weather Systems",
          band: "Anathema",
          title: "Dzieło sztuki!",
          text: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec fringilla magna fringilla nisi tristique, vel tempus risus malesuada. Fusce venenatis, orci eget blandit mollis, diam nisl interdum nulla, a convallis purus augue ut odio. Cras urna sapien, faucibus tincidunt placerat non, laoreet nec nunc.",
        },
        {
          img: "werehere",
          album: "We're Here Because We're Here",
          band: "Anathema",
          title: "Dzieło sztuki!",
          text: "2Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec fringilla magna fringilla nisi tristique, vel tempus risus malesuada. Fusce venenatis, orci eget blandit mollis, diam nisl interdum nulla, a convallis purus augue ut odio. Cras urna sapien, faucibus tincidunt placerat non, laoreet nec nunc. Praesent felis nibh, laoreet et sapien in, tincidunt eleifend tellus. Morbi ante urna, mollis quis eros sed, pulvinar venenatis lacus. Quisque interdum urna molestie porta auctor. Aliquam erat volutpat. Integer in aliquam sem. Quisque varius purus eu eros elementum varius. ",
        },
        {
          img: "naturaldisaster",
          album: "A Natural Disaster",
          band: "Anathema",
          title: "Dzieło sztuki!",
          text: "3Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec fringilla magna fringilla nisi tristique, vel tempus risus malesuada. Fusce venenatis, orci eget blandit mollis, diam nisl interdum nulla, a convallis purus augue ut odio. Cras urna sapien, faucibus tincidunt placerat non, laoreet nec nunc. Praesent felis nibh, laoreet et sapien in, tincidunt eleifend tellus. Morbi ante urna, mollis quis eros sed, pulvinar venenatis lacus. Quisque interdum urna molestie porta auctor. Aliquam erat volutpat. Integer in aliquam sem. Quisque varius purus eu eros elementum varius. ",
        },
      ];
    },
    getArtists() {
      this.artists = [
        { img: "BandPhoto", title: "Anathema"  },
        {
          img: "BandPhoto",
          title: "Anathema"
          
        },
        {
          img: "BandPhoto",
          title: "Anathema"
          
        },
        { img: "BandPhoto", title: "Anathema" },
      ];
    },
    getGenres() {
      this.genres = [
        { img: "BandPhoto", title: "Rock/Metal"  },
        {
          img: "BandPhoto",
          title: "Klasyczna"
          
        },
        {
          img: "BandPhoto",
          title: "Jazz"
          
        },
        { img: "BandPhoto", title: "Pop" },
      ];
    },
  },
};
</script>

<style scoped>
p {
  color: gray;
}
p > span {
  color: #ebebf2;
  padding-bottom: 1px;
  font-weight: bold;
}
.title-text {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
.user {
  border-bottom: solid gray 1px;
  margin-right: 18%;
}
.favorites {
  padding: 7%;
}
</style>
