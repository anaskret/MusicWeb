<template>
  <v-container fluid class="mb-lg-16">
    <v-row justify="center" class="pb-lg-3">
      <v-col lg="8">
        <!-- TODO : wyśrodkować w pionie -->
        <div class="d-flex flex-row" style="align-items: center">
          <h1 class="display-1 font-weight-bold text-left">
            {{ componentTitle }}
          </h1>
          <p class="pl-lg-16">
            {{ componentLinkTitle }}
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
        <v-sheet class="mx-auto">
          <v-slide-group class="px-4" show-arrows center-active>
            <v-slide-item v-for="(item, index) in itemsView" :key="index">
              <v-hover v-slot="{ hover }">
                <v-card>
                  <v-card
                    :img="require(`@/assets/${item.img}.svg`)"
                    class="mx-6"
                    height="200"
                    width="200"
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
      transparent: "rgba(255, 255, 255, 0)",
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
  transition: opacity 0.4s ease-in-out;
}

.on-hover {
  opacity: 0.6;
}

.show-btn {
  color: rgba(255, 255, 255, 1) !important;
}
.read-more-icon {
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
}
.underline {
  border-bottom: solid gray 1px;
}
</style>
