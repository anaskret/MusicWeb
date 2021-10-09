<template>
  <v-container>
    <v-row justify="center">
      <v-col>
        <div class="d-flex flex-row justify-space-center">
          <v-card outlined width="30%" class="py-3 mr-5" height="20%">
            <p class="d-flex justify-center rank-number">5.0</p>
            <p class="justify-center d-flex rank-caption">Średnia ocen</p>
          </v-card>
          <v-card outlined width="30%" class="py-3 mr-5">
            <p class="d-flex justify-center rank-number">4564</p>
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
export default {
  name: "RankSection",
};
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
