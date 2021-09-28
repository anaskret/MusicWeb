<template>
  <v-container fluid>
    <v-row justify="center">
      <v-col lg="10">
        <div class="d-flex">
          <h3>Recenzje</h3>
          <p>Wyświetl wszystkie recenzje</p>
          <v-btn outlined>Napisz recenzję</v-btn>
        </div>
      </v-col>
    </v-row>
    <v-row justify="center">
      <v-col lg="2">
        <div class="d-flex flex-column justify-center">
          <v-avatar size="60">
            <v-img :src="require('@/assets/band_logo.jpg')"></v-img>
          </v-avatar>
        </div>
        <p>AnathemaLover</p>
      </v-col>
      <v-col lg="8">
        <h3>Anathema to najlepszy zespół!</h3>
        <p>25.09.2021</p>
        <p>
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Similique
          laudantium sed temporibus culpa ullam dolore molestiae aut tenetur
          delectus? Error ullam rem accusantium impedit corrupti nostrum neque
          esse nam quaerat! Lorem ipsum dolor sit amet, consectetur adipisicing
          elit. Sunt necessitatibus, quas eligendi qui quis exercitationem ipsum
          porro laudantium, reprehenderit quae dolorum libero veniam saepe non
          perspiciatis rerum officiis sequi voluptates?
        </p>
      </v-col>
    </v-row>
    <v-row justify="center">
      <v-col lg="2">
        <div class="d-flex flex-column justify-center">
          <v-avatar size="60">
            <v-img :src="require('@/assets/band_logo.jpg')"></v-img>
          </v-avatar>
        </div>
        <p>AnathemaLover</p>
      </v-col>
      <v-col lg="8">
        <h3>Anathema to najlepszy zespół!</h3>
        <p>25.09.2021</p>
        <p>
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Similique
          laudantium sed temporibus culpa ullam dolore molestiae aut tenetur
          delectus? Error ullam rem accusantium impedit corrupti nostrum neque
          esse nam quaerat! Lorem ipsum dolor sit amet, consectetur adipisicing
          elit. Sunt necessitatibus, quas eligendi qui quis exercitationem ipsum
          porro laudantium, reprehenderit quae dolorum libero veniam saepe non
          perspiciatis rerum officiis sequi voluptates?
        </p>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "ReviewSection",
};
</script>
