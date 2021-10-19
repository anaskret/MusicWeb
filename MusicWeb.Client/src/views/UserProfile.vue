<template>
  <v-container fluid class="py-16 d-flex justify-center">
    <v-row justify="center">
      <v-col md="2" sm="6">
        <v-img :src="require('@/assets/BandPhoto.svg')" contain />
      </v-col>
      <v-col md="4" sm="9">
        <div class="profile-header">
          <p>Profil</p>
          <h1 class="profile-title">
            <span class="text-uppercase display-2">
              {{ account.firstname }} {{ account.lastname }}
            </span>
            <v-btn text>
              <font-awesome-icon
                transform="{ rotate: 42 }"
                class="icon"
                icon="pen"
                color="#white"
              />
            </v-btn>
          </h1>
        </div>
      </v-col>
      <v-col md="9">
        <ReviewList :reviews="reviews" />
      </v-col>
      <v-col md="10">
        <item-carousel
          :items="artists"
          :componentTitle="artistsTitle"
          :componentLinkTitle="artistsLinkTitle"
        />
      </v-col>
      <v-col md="10">
        <item-carousel
          :items="genres"
          :componentTitle="genresTitle"
          :componentLinkTitle="genresLinkTitle"
        />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import ReviewList from "@/components/ReviewList";
import ItemCarousel from "../components/ItemCarousel.vue";
import useAccounts from "@/modules/accounts";
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
      genresLinkTitle: "Zobacz wszystko",
      account: {},
    };
  },
  created() {
    this.getReviews();
    this.getArtists();
    this.getGenres();
    this.getAccount();
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
        { img: "BandPhoto", name: "Anathema" },
        {
          img: "BandPhoto",
          name: "Anathema",
        },
        {
          img: "BandPhoto",
          name: "Anathema",
        },
        { img: "BandPhoto", name: "Anathema" },
      ];
    },
    getGenres() {
      this.genres = [
        { img: "BandPhoto", name: "Rock/Metal" },
        {
          img: "BandPhoto",
          name: "Klasyczna",
        },
        {
          img: "BandPhoto",
          name: "Jazz",
        },
        { img: "BandPhoto", name: "Pop" },
      ];
    },
  },
  setup() {
    const { getById } = useAccounts();

    const getAccount = function () {
      getById(localStorage.getItem("user-id")).then((response) => {
        this.account = response;
      });
    };

    return {
      getAccount,
    };
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
.profile-header {
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
}
.profile-title {
  display: flex;
  align-items: center;
}
.favorites {
  padding: 7%;
}
</style>
