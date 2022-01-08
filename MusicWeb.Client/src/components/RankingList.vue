<template>
  <v-container fluid grid-list-lg class="py-16">
    <v-row justify="center">
      <v-col lg="8">
        <div class="mx-auto">
          {{scroll_settings}}
          <v-card>
            <v-card-title>
              <v-text-field
                v-model="search"
                append-icon="mdi-magnify"
                label="Search"
                single-line
                hide-details
              ></v-text-field>
            </v-card-title>
            <v-data-table
              :headers="headers"
              :items="rankArtists"
              :search="search"
              :pagination.sync="scroll_settings"
              hide-default-footer
            ></v-data-table>
          </v-card>
          <!-- <v-list>
            <v-list-item-group v-model="show_list">
              <v-list-item v-for="(item, index) in items" :key="index">
                <v-list-item-content
                  :style="
                    index != items.length - 1
                      ? {
                          borderBottom: '1px solid #cbcbf233',
                        }
                      : ''
                  "
                >
                  <RankingItem
                    :item="item"
                    :page_name="module_name"
                    :redirect_module_name="redirect_module_name"
                  />
                </v-list-item-content>
              </v-list-item>
            </v-list-item-group>
          </v-list> -->
        </div>
      </v-col>
    </v-row>
    <div
      v-if="intersection_active"
      v-intersect="{
        handler: getPagedItemList,
        options: {
          threshold: [1.0],
        },
      }"
    ></div>
  </v-container>
</template>

<script>
import { required } from "vuelidate/lib/validators";
import { mapGetters } from 'vuex';
export default {
  name: "RankingList",
  data() {
    return {
      search: '',
      headers: [
        {
          text: 'Dessert (100g serving)',
          align: 'start',
          filterable: false,
          value: 'name',
        },
        { text: 'Calories', value: 'calories' },
        { text: 'Fat (g)', value: 'fat' },
        { text: 'Carbs (g)', value: 'carbs' },
        { text: 'Protein (g)', value: 'protein' },
        { text: 'Iron (%)', value: 'iron' },
      ],
      filters: {},
      is_date_picker_from: false,
      is_date_picker_to: false,
      show_list: null,
    };
  },
  props: {
    scroll_settings: Object,
    getPagedItemList: Function,
    filterList: Function,
    intersection_active: Boolean,
    redirect_module_name: String,
    module_name: String,
  },
  computed: {
    isDisabled() {
      return this.$v.$invalid;
    },
    establishmentDateFromErrors() {
      return this.prepareErrorArray("establishment_date_from");
    },
    establishmentDateToErrors() {
      return this.prepareErrorArray("establishment_date_to");
    },
    updateDefaultSortType: {
      get() {
        return this.scroll_settings.default_sort_type;
      },
      set(newType) {
        this.scroll_settings.default_sort_type = newType;
        this.scroll_settings.selected_sort_type = 0;
      },
    },
    ...mapGetters([
      'rankArtists'
    ]), 
  },
  validations: {
    filters: {
      establishment_date_from: {
        required,
      },
      establishment_date_to: {
        required,
      },
    },
  },
  created() {
    this.setDefaultFilters();
  },
  methods: {
    prepareErrorArray(field) {
      const errors = [];
      if (!this.$v.filters[field].$dirty) return errors;
      !this.$v.filters[field].required && errors.push("Pole jest wymagane.");
      return errors;
    },
    setDefaultFilters() {
      (this.filters = {
        establishment_date_from: this.moment("1970-01-01").format("YYYY-MM-DD"),
        establishment_date_to: this.moment().add(10, "y").format("YYYY-MM-DD"),
      }),
        this.$emit("set-filters", this.filters);
    },
  },
};
</script>

<style lang="scss" scoped>
.item {
  background: lighten(#0d1117, 2%);
  border-radius: 2%;
  margin-bottom: 3%;
}
</style>
