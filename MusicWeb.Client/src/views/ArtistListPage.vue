<template>
  <v-container fluid grid-list-lg class="py-16">
      <v-layout column wrap>
        <v-flex v-for="(artist, index) in artists" :key="index">
          <v-card flat hover class="white pb-2 mb-1 pl-2">
            <v-layout>
              <v-flex xs10>
                <div class="py-2" style="color: black; width:100%">{{ artist.id }} - {{ artist.name }}</div>
              </v-flex>
            </v-layout>
          </v-card>
        </v-flex>
      </v-layout>
      <div v-intersect="getPagedArtistList"></div>
  </v-container>
</template>

<script>
import useArtists from "@/modules/artists";

export default {
  name: "ArtistListPage",
  components: {},
  data() {
    return {
      artists: [],
      page: 0,
    };
  },
  created() {
    this.fetchData();
  },
  methods: {
    async fetchData() {
      await this.getPagedArtistList();
    },
  },

  setup() {
    const { getPaged } = useArtists();

    const getPagedArtistList = function () {
        this.page++; //TODO reduce iteration to max(element)
      getPaged(this.page, 2, 0, '1989-01-01T00:00:00', '2022-01-01T00:00:00').then((response) => { //TODO change static data to chosen by user
        response.forEach((item) => this.artists.push(item));
      })
        .catch((err) => {
        console.log(err);
        });
      console.log(this.page);
    };

    return {
      getPagedArtistList,
    };
  },
};
</script>

<style scoped>
.theme--light.v-card {
  background-color: #f5f5f5;
}
</style>
