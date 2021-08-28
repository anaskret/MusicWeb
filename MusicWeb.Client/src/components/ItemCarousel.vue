<template>
  <v-container>
    <v-row justify="center">
      <v-col class="mt-3" lg="9" sm="9">
        <v-card>
          <v-row>
            <v-col lg="2" sm="2">
              <h1 class="display-1 font-weight-bold text-left">Dyskografia</h1>
            </v-col>
            <v-col lg="10" sm="10">
              <p class="py-3">
                Wyświetl pełną dyskografię
                <font-awesome-icon
                  class="icon"
                  icon="chevron-right"
                  size="1x"
                  color="gray"
                />
              </p>
            </v-col>
          </v-row>
          <v-sheet class="mx-auto" elevation="0">
            <v-slide-group
              v-model="show"
              class="pa-4"
              show-arrows
              center-active
            >
              <v-slide-item
                v-for="(album, index) in albumsView"
                :key="index"
                v-slot="{ active, toggle }"
              >
                <v-card>
                  <v-card
                    :img="require(`@/assets/${album.img}.svg`)"
                    class="ma-4"
                    height="250"
                    width="260"
                    @click="toggle"
                  >
                    <v-row class="fill-height" align="center" justify="center">
                      <v-scale-transition>
                        <font-awesome-icon
                          v-if="active"
                          class="icon"
                          icon="chevron-down"
                          size="4x"
                          color="white"
                        />
                      </v-scale-transition>
                    </v-row>
                  </v-card>
                  <h4 class="text-center">{{ album.title }}</h4>
                  <p class="text-center">{{ album.year }}</p>
                </v-card>
              </v-slide-item>
            </v-slide-group>

            <v-expand-transition>
              <v-sheet v-if="show != null" height="200" tile>
                <v-row class="fill-height" align="center" justify="center">
                  <h3 class="text-h6">Selected {{ show }}</h3>
                </v-row>
              </v-sheet>
            </v-expand-transition>
          </v-sheet>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "ItemCarousel",
  props: {
    albums: Array,
  },
  data() {
    return {
      show: null,
      albumsView: this.albums,
    };
  },
};
</script>
<style scoped>
p {
  color: gray;
  margin: 0;
}
</style>
