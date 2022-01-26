<template>
  <v-container fluid class="mb-lg-16">
    <v-row justify="center" class="pb-lg-3">
      <v-col lg="8">
        <div class="d-flex flex-row" style="align-items: center">
          <h1 class="display-1 font-weight-bold text-left">
            {{ component_title }}
          </h1>
          <a class="component_link_title ml-lg-10" 
          v-if="component_type == 'discography'"
          @click="redirectToList(component_type, item_id)">
            {{ component_link_title }}
            <font-awesome-icon
              class="icon"
              icon="chevron-right"
              size="1x"
              color="gray"

            />
          </a>          
          <a 
          v-else 
          class="component_link_title ml-lg-10" 
          @click="redirectToList(component_type)">
            {{ component_link_title }}
            <font-awesome-icon
              class="icon"
              icon="chevron-right"
              size="1x"
              color="gray"

            />
          </a>
        </div>
      </v-col>
    </v-row>
    <v-row justify="center">
      <v-col lg="8">
        <v-sheet class="mx-auto">
          <v-slide-group class="px-4" show-arrows="true">
            <v-slide-item v-for="(item, index) in items" :key="index">
              <v-hover v-slot="{ hover }">
                <v-card>
                  <v-card
                    :img="require(`@/assets/judgement.svg`)"
                    class="mx-6"
                    height="200"
                    width="200"
                    :elevation="hover ? 12 : 2"
                    :class="{ 'on-hover': hover }"
                    @click="redirectToItem(component_type == 'favorite' || component_type == 'observed' ? item.favoriteId : item.id)"
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
                    {{ item.name }}
                  </h4>
                  <p class="text-center">
                    {{ moment(item.releaseDate).format("YYYY") }}
                  </p>
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
    component_title: String,
    component_link_title: String,
    redirect_to: String,
    component_type: String,
    redirect_to_list: String, 
    item_id: String,
  },
  data() {
    return {
      show: null,
      transparent: "rgba(255, 255, 255, 0)",
      itemId: null
    };
  },
  methods: {
    redirectToItem(itemId) {
      this.$router.push({ name: this.redirect_to, params: { id: itemId } });
    },
    redirectToList(list_type, item_id) {
      this.$router.push({ name: this.redirect_to_list, params: { type: list_type, id: item_id } });
    },
  },

};
</script>
<style scoped>
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
.component_link_title {
  margin: 0px;
}

</style>
