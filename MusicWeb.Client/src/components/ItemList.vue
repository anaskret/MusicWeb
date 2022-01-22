<template>
  <v-container fluid class="mb-lg-16">
    <v-row justify="center" class="pb-lg-2">
      <v-col lg="8">
        <!-- TODO : wyśrodkować w pionie -->
        <div class="d-flex flex-row" style="align-items: center">
          <h1 class="display-1 font-weight-bold text-left">{{ list_title }}</h1>
          <p class="pl-lg-16">
            {{ list_link_title }}
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
      <v-col lg="8">
        <div class="mx-auto">
          <v-list>
            <v-list-item-group v-model="show">
              <v-list-item v-for="(item, index) in items" :key="index">
                <v-list-item-content
                  :style="
                    index != items.length - 1
                      ? {
                          borderBottom: '1px solid #cbcbf233',
                        }
                      : ''
                  "
                  @click="redirectToItem(item.id)"
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
                        :src="require('@/assets/BandPhoto.svg')"
                        :alt="item.name"
                        width="50%"
                      />
                    </v-col>
                    <v-col
                      class="d-flex justify-start align-center"
                      lg="3"
                      sm="3"
                    >
                      {{ item.name }}
                    </v-col>
                    <v-col
                      class="d-flex justify-start align-center"
                      lg="3"
                      sm="3"
                    >
                      <p>{{ item.albumName }}</p>
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
                      {{item.rating}}
                    </v-col>
                  </v-row>
                </v-list-item-content>
              </v-list-item>
            </v-list-item-group>
          </v-list>
        </div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "ItemList",
  props: {
    items: Array,
    list_title: String,
    list_link_title: String,
  },
  data() {
    return {
      model: null,
      show: null,
    };
  },
  methods: {
    redirectToItem(itemId) {
      this.$router.push({ name: "SongPage", params: { id: itemId } });
    },
  },
};
</script>
