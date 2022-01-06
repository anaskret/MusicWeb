<template>
  <v-container class="px-0">
    <v-row justify="center">
      <v-col>
        <div class="d-flex flex-row justify-space-center">
          <v-card outlined width="30%" class="py-3 mr-5" height="20%">
            <p class="d-flex justify-center rank-number" v-if="module_name == 'Album'">{{ album.rating }}</p>
            <p class="d-flex justify-center rank-number" v-if="module_name == 'Song'">{{ song.rating }}</p>
            <p class="d-flex justify-center rank-number" v-if="module_name == 'Artist'">{{ artist.rating }}</p>
            <p class="justify-center d-flex rank-caption">Średnia ocen</p>
          </v-card>
          <v-card outlined width="30%" class="py-3 mr-5">
            <p class="d-flex justify-center rank-number" v-if="module_name == 'Album'">{{ album.ratingsCount }}</p>
            <p class="d-flex justify-center rank-number" v-if="module_name == 'Song'">{{ song.ratingsCount }}</p>
            <p class="d-flex justify-center rank-number" v-if="module_name == 'Artist'">{{ artist.ratingsCount }}</p>
            <p class="d-flex justify-center rank-caption">Ilość ocen</p>
          </v-card>
          <v-card outlined width="30%" class="py-3">
            <p class="d-flex justify-center rank-number">100</p>
            <p class="d-flex justify-center rank-caption">Ranking</p>
          </v-card>
        </div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex';
export default {
  name: "RankSection",
  computed:{
    ...mapGetters([
      'album',
      'song',
      'artist'
    ]),
  }, 
  props: {
    module_name: {
      type: String
    },
  }
}
</script>

<style scoped>
.rank-caption {
  font-weight: 300;
  margin-bottom: 0px;
}
.rank-number {
  font-weight: 700;
  font-size: 1.2rem;
  margin-bottom: 0px;
}
</style>
