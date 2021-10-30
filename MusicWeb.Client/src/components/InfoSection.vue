<template>
  <v-container fluid>
    <v-row justify="center">
      <v-col md="3" sm="6" class="py-lg-9 pr-lg-10">
        <span class="border-right border-dark"></span>
        <h1 class="title font-weight-bold pb-lg-5">Informacje</h1>
        <div v-if="module_name == 'Artist'">
          <p>
            Rok założenia:
            <span>{{ moment(parent.establishmentDate).format("L") }}</span>
          </p>
          <p>
            Pochodzenie:
            <span
              >{{ parent.city }} {{ parent.state }},
              {{ parent.country }}
            </span>
          </p>
          <p>
            Gatunek muzyczny:
            <span>rock progresywny, art rock, doom metal</span>
          </p>
          <p v-if="parent.isBand && !parent.isIndividual">
            Członkowie:parent
            <span v-for="(member, index) in parent.members" :key="index">
              {{ member
              }}<span v-if="index != parent.members.length - 1">,</span></span
            >
          </p>
        </div>
        <div v-else-if="module_name == 'Album'">
          <p>
            Artysta:
            <span>{{ parent.artist.name }}</span>
          </p>
          <p>
            Data wydania:
            <span>{{ moment(parent.releaseDate).format("L") }} </span>
          </p>
          <p>
            Czas trwania:
            <span>{{ parent.duration }} min</span>
          </p>
          <p>
            Gatunek muzyczny:
            <span>{{ parent.albumGenre.name }}</span>
          </p>
        </div>
      </v-col>
      <v-col lg="5">
        <h1 class="pb-lg-5">Biografia</h1>
        <p class="text-justify">
          {{ parent.description }}
        </p>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "Header",
  props: {
    parent: {
      type: Object,
      default: () => ({}),
    },
    module_name: {
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
  color: gray;
}
p > span {
  color: #ebebf2;
  padding-bottom: 1px;
}
.feature-text {
  font-size: 1rem;
}
</style>
