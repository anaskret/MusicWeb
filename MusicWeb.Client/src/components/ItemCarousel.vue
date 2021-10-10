<template>
  <v-container fluid>
    <v-row justify="center">
      <v-col class="mt-3" lg="9" sm="9">
        <div>
          <v-row class="title underline">
            <v-col lg="5" sm="5">
              <h1 class="display-1 font-weight-bold text-left">{{componentTitle}}</h1>
            </v-col>
            <v-col lg="3" sm="3">
              <p class="py-3">
                {{componentLinkTitle}}
                <font-awesome-icon
                  class="icon"
                  icon="chevron-right"
                  size="1x"
                  color="gray"
                />
              </p>
            </v-col>
          </v-row>
          <v-sheet class="mx-auto" >
            <v-slide-group class="pa-4" show-arrows center-active>
              <v-slide-item v-for="(item, index) in itemsView" :key="index">
                <v-hover v-slot="{ hover }">
                  <v-card>
                    <v-card
                      :img="require(`@/assets/${item.img}.svg`)"
                      class="ma-4"
                      height="250"
                      width="260"
                      :elevation="hover ? 12 : 2"
                      :class="{ 'on-hover': hover }"
                        >
                        <div class="read-more-icon">
                          <v-btn
                            :class="{ 'show-btn': hover }"
                            :color="transparent"
                            icon
                          >
                              <font-awesome-icon
                                class="icon"
                                icon="chevron-circle-right"
                                size="4x"
                              />
                          </v-btn>
                        </div>
                    </v-card>
                    <h4 class="text-center">
                      {{ item.title }}
                    </h4>
                    <p class="text-center">{{ item.year }}</p>
                  </v-card>
                </v-hover>
              </v-slide-item>
            </v-slide-group>
          </v-sheet>
        </div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "ItemCarousel",
  props: {
    items: Array,
    componentTitle: String,
    componentLinkTitle: String,
  },
  data() {
    return {
      show: null,
      itemsView: this.items,
      transparent: 'rgba(255, 255, 255, 0)',
    };
  },
};
</script>
<style scoped>
p {
  color: gray;
  margin: 0;
}
.v-card {
transition: opacity .4s ease-in-out;
}

.on-hover {
opacity: 0.6;
 }

.show-btn {
color: rgba(255, 255, 255, 1) !important;
}
.read-more-icon{
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
}
.underline {
  border-bottom: solid gray 1px;
}
.title {
  display: flex;
  align-items: center;
  justify-content: space-between;
}
</style>
