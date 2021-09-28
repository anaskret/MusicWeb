<template>
  <v-container fluid>
    <v-row justify="center">
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
            <h1>UNTOUCHABLE PT. I</h1>
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
          <p>Średnia ocen: <span>5.0</span></p>
          <p>Ilość ocen: <span>342</span></p>
          <p>Miejsce w rankingu: <span>3213</span></p>
        </div>
      </v-col>
      <v-col lg="7">
        <v-row>
          <v-col lg="12">
            <h1>Informacje</h1>
          </v-col>
          <v-col lg="6">
            <div>
              <p>Artysta: <span>Anathem</span></p>
              <p>Album: <span>Weather Systems</span></p>
              <p>Nr na albumie: <span>1</span></p>
              <p>Czas trwania: <span>6:40</span></p>
            </div>
          </v-col>
          <v-col lg="6">
            <div>
              <p>Rok wydania: <span>2012</span></p>
              <p>Gatunek muzyczny: <span>Rock progresywny</span></p>
              <p>Kompozytor: <span>Daniel Cavanagh</span></p>
            </div>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
    <v-row justify="center">
      <v-col lg="10">
        <h1>Komentarze</h1>
      </v-col>
    </v-row>
    <v-row justify="center">
      <v-col lg="2">
        <v-avatar size="70">
          <v-img :src="require('@/assets/band_logo.jpg')"></v-img>
        </v-avatar>
      </v-col>
      <v-col lg="8">
        <div>
          <h3>AnathemaLover</h3>
          <p>25.09.2021</p>
        </div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "SongPage",
};
</script>
