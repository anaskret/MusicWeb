<template>
  <v-container>
    <v-row justify="center">
      <v-col class="mt-3" lg="9" sm="9">
        <v-card>
          <v-row>
            <v-col lg="2" sm="2">
              <h1 class="display-1 font-weight-bold text-left">Utwory</h1>
            </v-col>
            <v-col lg="10" sm="10">
              <p class="py-3">
                Wyświetl wszystkie utwory
                <font-awesome-icon
                  class="icon"
                  icon="chevron-right"
                  size="1x"
                  color="gray"
                />
              </p>
            </v-col>
          </v-row>
          <v-card class="mx-auto">
            <v-list>
              <v-list-item-group v-model="show">
                <v-list-item v-for="(song, index) in songsView" :key="index">
                  <v-list-item-content
                    :style="
                      index != songsView.length - 1
                        ? {
                            borderBottom: '1px solid #cbcbf233',
                          }
                        : ''
                    "
                  >
                    <v-row>
                      <v-col
                        class="d-flex justify-center align-center"
                        lg="1"
                        sm="1"
                      >
                        {{ index + 1 }}
                      </v-col>
                      <v-col
                        class="d-flex justify-center align-center"
                        lg="2"
                        sm="2"
                      >
                        <img
                          :src="require(`@/assets/${song.img}.svg`)"
                          :alt="song.title"
                          width="50%"
                        />
                      </v-col>
                      <v-col
                        class="d-flex justify-start align-center"
                        lg="3"
                        sm="3"
                      >
                        {{ song.title }}
                      </v-col>
                      <v-col
                        class="d-flex justify-start align-center"
                        lg="3"
                        sm="3"
                      >
                        <p>{{ song.album }}</p>
                      </v-col>
                      <v-col
                        class="d-flex justify-center align-center"
                        lg="3"
                        sm="3"
                      >
                        <font-awesome-icon
                          class="icon mr-2"
                          icon="star"
                          size="1x"
                          color="#868263"
                        />
                        {{ song.rating }}
                      </v-col>
                    </v-row>
                  </v-list-item-content>
                </v-list-item>
              </v-list-item-group>
            </v-list>
          </v-card>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "ItemList",
  props: {
    songs: Array,
  },
  data() {
    return {
      model: null,
      show: null,
      songsView: this.songs,
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
