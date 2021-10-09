<template>
  <v-container fluid class="mb-lg-16">
    <v-row justify="center" class="pb-lg-3">
      <v-col lg="8">
        <!-- TO DO : wyśrodkować w pionie -->
        <div class="d-flex flex-row" style="align-items: center">
          <h1 class="display-1 font-weight-bold text-left">Dyskografia</h1>
          <p class="pl-lg-16">
            Wyświetl pełną dyskografię
            <font-awesome-icon
              class="icon"
              icon="chevron-right"
              size="1x"
              color="gray"
            />
          </p>
        </div>
      </v-col>
    </v-row>
    <v-row justify="center">
      <v-col lg="9">
        <v-sheet class="mx-auto" elevation="0">
          <v-slide-group v-model="show" class="px-4" show-arrows center-active>
            <v-slide-item
              v-for="(album, index) in albumsView"
              :key="index"
              v-slot="{ active, toggle }"
            >
              <v-card>
                <v-card
                  :img="require(`@/assets/${album.img}.svg`)"
                  class="mx-6"
                  height="200"
                  width="200"
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
                <h4 class="text-center">
                  {{ album.title }}
                </h4>
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
        <!-- </div> -->
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
