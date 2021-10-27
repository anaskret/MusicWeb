<template>
  <v-container fluid grid-list-lg class="py-16">
    <v-layout column wrap>
      <v-flex v-for="(artist, index) in artists" :key="index">
        <v-card flat hover class="white pb-2 mb-1 pl-2">
          <v-layout>
            <v-flex xs10>
              <div class="py-2" style="color: black; width: 100%">
                {{ artist.establishmentDate }} - {{ artist.name }}
              </div>
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
      getPaged(this.page, 5, 0, "1989-01-01T00:00:00", "2022-01-01T00:00:00")
        .then((response) => {
            response.forEach((item) => {
                return this.artists.push(item)
            });
        })
        .catch((err) => {
          console.log(err);
        });
      console.log(this.page);
      this.page++; //TODO reduce iteration to max(element)
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
