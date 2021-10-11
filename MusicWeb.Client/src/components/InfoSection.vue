<template>
  <v-container fluid>
    <v-row justify="center">
      <v-col md="3" sm="6" class="py-lg-9 pr-lg-10">
        <span class="border-right border-dark"></span>
        <h1 class="title font-weight-bold pb-lg-5">Informacje</h1>
        <p v-for="(info, index) in info_content" :key="index">
          {{ info.info }}
        </p>
      </v-col>
      <v-col lg="5">
        <h1 class="pb-lg-5">Biografia</h1>
        <p class="text-justify">
            {{ artist.bio }}
        </p>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "Header",
  props: {
    info_content: {
      type: Array,
      default: () => ({}),
    },
    artist: {
      type: Object,
      default: () => ({}),
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