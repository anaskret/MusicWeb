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
          Anathema (gr. klątwa) to angielska grupa muzyczna. Powstała 1990 roku
          w Liverpoolu. Początkowo wykonująca drugofalowy death metal/doom
          metal, będąc wraz z grupami Katatonia, Tiamat, Winter, My Dying Bride
          i Paradise Lost prekursorem gatunku. Obecnie grupa zaliczana jest do
          nurtu art rocka oraz rocka atmosferycznego. Anathema została stworzona
          w 1990 roku pod nazwą Pagan Angel. W listopadzie tego roku zespół
          nagrał pierwsze demo "An Iliad of Woes". Zmiana nazwy nastąpiła na
          początku 1991 roku. Pierwsze demo przyciągnęło uwagę zespołów z
          brytyjskiej sceny metalowej i pozwoliło Anathemie zagrać koncerty u
          boku takich kapel jak Bolt Thrower czy Paradise Lost.
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
}
.feature-text {
  font-size: 1rem;
}
/* .rank-caption {
  font-weight: 300;
  margin-bottom: 0px;
}
.rank-number {
  font-weight: 700;
  font-size: 1.2rem;
  margin-bottom: 0px;
} */
</style>
