<template>
  <v-container fluid class="py-16">
    <v-row justify="center">
      <v-col md="3" sm="6" class="pa-lg-5">
        <div>
          <v-img :src="require('@/assets/BandPhoto.svg')" contain />
        </div>
      </v-col>
      <v-col md="7" sm="12" class="d-flex flex-column">
        <v-row align-content="end" class="pb-lg-3">
          <v-col lg="12" sm="7" class="pl-lg-15">
            <div class="d-flex">
              <div>
                <h1 class="text-uppercase display-3 font-weight-bold">
                  ANATHEMA
                </h1>
              </div>
              <v-btn
                outlined
                color="grey"
                height="30px"
                class="text-uppercase align-self-center ml-md-16"
                >Obserwuj
              </v-btn>
            </div>
          </v-col>
        </v-row>
        <v-row>
          <v-col md="12" class="pl-lg-15 d-flex flex-row pr-lg-5">
            <div>
              <p>Dodaj do ulubionych</p>
              <div class="d-flex flex-row">
                <div align-content="center" class="mr-lg-3">
                  <font-awesome-icon
                    class="icon"
                    icon="heart"
                    size="2x"
                    color="#865e61"
                  ></font-awesome-icon>
                </div>
                <div align-items="center" class="align-center">
                  <span>199 osób</span> dodało do ulubionych
                </div>
              </div>
            </div>
            <div class="ml-lg-16">
              <p>Oceń artystę</p>
              <div class="d-flex flex-row">
                <font-awesome-icon
                  class="icon pr-2"
                  v-for="(star, index) in stars"
                  :key="index"
                  icon="star"
                  size="2x"
                  :colot="star.color"
                ></font-awesome-icon>
                <div class="align-center">
                  <span>4.0</span>
                </div>
              </div>
            </div>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
    <v-row justify="center">
      <v-col md="3" sm="6" class="pa-lg-5">
        <span class="border-right border-dark"></span>
        <h1 class="title font-weight-bold pb-lg-5">Informacje</h1>
        <p>Rok założenia: <span>1990</span></p>
        <p>Pochodzenie: <span>Liverpool, Anglia</span></p>
        <p>
          Gatunek muzyczny: <span>rock progresywny, art rock, doom metal</span>
        </p>
        <p>
          Członkowie:
          <span
            >Vincent Cavanagh, Daniel Cavanagh, Jaime Cavanagh, Lee Douglas,
            John Douglas</span
          >
        </p>
      </v-col>
      <v-col lg="7" class="pl-lg-16">
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
    artist: {
      type: Object,
      default: () => ({}),
    },
    address: {
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
  mounted() {
    console.log(this.address);
  },
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;700&display=swap");
/* .rating {
  display: flex;
  justify-content: space-between;
} */
.align-center {
  display: flex;
  align-items: center;
}
template {
  font-family: "Montserrat";
}
</style>
