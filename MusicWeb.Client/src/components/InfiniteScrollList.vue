<template>
  <v-container fluid grid-list-lg class="py-16">
              <div v-if="module_name == 'ArtistRanking' || module_name == 'AlbumRanking' || module_name=='SongRanking'">
            <v-simple-table>
            <thead>
          <tr>
            <th v-for="(column, index) in columns_list" :key="index">{{column}}</th>
            <!-- <th class="text-left">
              Name
            </th>
            <th class="text-left">
              Calories
            </th> -->
          </tr>
        </thead>
        <tbody>
               <tr v-for="(item, index) in items"
              :key="index"
        >
          <td>{{index + 1}}</td>
          <td><div>
          <v-img :src="require('@/assets/BandPhoto.svg')" style = "width: 50px;"/>
        </div></td>
          <td>{{ item.name }}</td>
          <td>{{ item.rating }}</td>
          <td>{{ item.ratingsCount }}</td>
          <td>{{item.favoriteCount}}</td>
          <td v-if="module_name == 'ArtistRanking'">{{item.observedCount}}</td>
          <td v-else>{{item.reviewsCount}}</td>
        </tr>
        </tbody>
          </v-simple-table>
          </div>
    <v-row justify="center" v-else>
      <v-col lg="8">
        <div class="mx-auto">
          <div v-if="module_name != 'Activities'">
            <div class="d-flex">
              <v-menu
                v-model="is_date_picker_from"
                :close-on-content-click="false"
                :nudge-right="40"
                transition="scale-transition"
                offset-y
                min-width="auto"
                outlined
              >
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field
                    class="p-4"
                    label="Filtruj po dacie od"
                    prepend-icon="mdi-calendar"
                    v-model.trim="$v.filters.establishment_date_from.$model"
                    :error-messages="establishmentDateFromErrors"
                    readonly
                    required
                    @input="$v.filters.establishment_date_from.$touch()"
                    @blur="$v.filters.establishment_date_from.$touch()"
                    v-bind="attrs"
                    v-on="on"
                  ></v-text-field>
                </template>
                <v-date-picker
                  color="#647da1"
                  v-model.trim="$v.filters.establishment_date_from.$model"
                  @input="is_date_picker_from = false"
                ></v-date-picker>
              </v-menu>
              <v-menu
                v-model="is_date_picker_to"
                :close-on-content-click="false"
                :nudge-right="40"
                transition="scale-transition"
                offset-y
                min-width="auto"
                outlined
              >
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field
                    class="p-4"
                    label="Filtruj po dacie do"
                    prepend-icon="mdi-calendar"
                    v-model.trim="$v.filters.establishment_date_to.$model"
                    :error-messages="establishmentDateToErrors"
                    readonly
                    required
                    @input="$v.filters.establishment_date_to.$touch()"
                    @blur="$v.filters.establishment_date_to.$touch()"
                    v-bind="attrs"
                    v-on="on"
                  ></v-text-field>
                </template>
                <v-date-picker
                  color="#647da1"
                  v-model.trim="$v.filters.establishment_date_to.$model"
                  @input="is_date_picker_to = false"
                ></v-date-picker>
              </v-menu>
            </div>
            <v-select
              :items="scroll_settings.sort_types"
              label="Sortuj"
              @change="setSelectedType"
              v-model="updateDefaultSortType"
              outlined
            >
              <template v-slot:item="{ item, attrs, on }">
                <v-list-item
                  v-bind="attrs"
                  v-on="on"
                  style="background: #0d1117"
                >
                  <v-list-item-title
                    :id="attrs['aria-labelledby']"
                    v-text="item"
                  ></v-list-item-title>
                </v-list-item>
              </template>
            </v-select>
            <v-btn @click="setDefaultFilters">Domyślne</v-btn>
            <v-btn @click="filterList">Filtruj/Sortuj</v-btn>
          </div>
        </div>
      </v-col>
    </v-row>
    <v-row justify="center" v-if="module_name != 'ArtistRanking' && module_name != 'AlbumRanking' && module_name != 'SongRanking'">

      <v-col lg="8">
          <v-list v-if="module_name == 'Activities'">
            <v-list-item
              class="item"
              v-for="(item, index) in items"
              :key="index"
            >
              <v-list-item-content>
                <InfiniteScrolItem :item="item" :page_name="module_name" />
              </v-list-item-content>
            </v-list-item>
          </v-list>
          <v-list v-else>
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
                  <InfiniteScrolItem
                    :item="item"
                    :page_name="module_name"
                    :redirect_module_name="redirect_module_name"
                  />
                </v-list-item-content>
              </v-list-item>
            </v-list-item-group>
          </v-list>
        <!-- </div> -->
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
import InfiniteScrolItem from "@/components/InfiniteScrolItem";
export default {
  name: "InfiniteScrollList",
  data() {
    return {
      filters: {},
      is_date_picker_from: false,
      is_date_picker_to: false,
      show_list: null,
    };
  },
  props: {
    items: Array,
    scroll_settings: Object,
    getPagedItemList: Function,
    filterList: Function,
    intersection_active: Boolean,
    redirect_module_name: String,
    module_name: String,
    columns_list: Array,

  },
  components: {
    InfiniteScrolItem,
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
    setSelectedType(selectedType) {
      this.scroll_settings.selected_sort_type =
        this.scroll_settings.sort_types.findIndex(
          (sortType) => sortType == selectedType
        );
    },
    setDefaultFilters() {
      (this.filters = {
        establishment_date_from: this.moment("1970-01-01").format("YYYY-MM-DD"),
        establishment_date_to: this.moment().add(10, "y").format("YYYY-MM-DD"),
      }),
        this.$emit("set-filters", this.filters);
      this.updateDefaultSortType = "Alfabetycznie malejąco";
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
