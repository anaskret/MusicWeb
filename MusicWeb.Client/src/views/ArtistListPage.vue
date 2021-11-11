<template>
  <v-container fluid grid-list-lg class="py-16">
    <v-row justify="center">
      <v-col lg="8">
        <div class="mx-auto">
          <div class="d-flex">
            <v-menu
              v-model="is_date_picker_from"
              :close-on-content-click="false"
              :nudge-right="40"
              transition="scale-transition"
              offset-y
              min-width="auto"
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
            :items="sort_types"
            label="Sortuj"
            @change="setSelectedType"
            v-model="updateDefaultSortType"
          >
            <template v-slot:item="{ item, attrs, on }">
              <v-list-item v-bind="attrs" v-on="on" style="background: #0d1117">
                <v-list-item-title
                  :id="attrs['aria-labelledby']"
                  v-text="item"
                ></v-list-item-title>
              </v-list-item>
            </template>
          </v-select>
          <v-btn @click="setDefaultFilters">Domyślne</v-btn>
          <v-btn @click="filterList">Filtruj/Sortuj</v-btn>
          <v-list>
            <v-list-item-group v-model="show">
              <v-list-item v-for="(artist, index) in artists" :key="index">
                <v-list-item-content
                  :style="
                    index != artists.length - 1
                      ? {
                          borderBottom: '1px solid #cbcbf233',
                        }
                      : ''
                  "
                >
                  <v-card @click="redirectToArtist(artist.id)">
                    <div class="d-flex flex-no-wrap justify-space-between">
                      <div>
                        <v-card-title
                          class="text-h5"
                          v-text="artist.name"
                        ></v-card-title>

                        <v-card-subtitle
                          ><p>
                            {{ moment(artist.establishmentDate).format("L") }}
                          </p></v-card-subtitle
                        >

                        <v-card-actions>
                          <v-btn
                            class="ml-2 mt-3"
                            fab
                            icon
                            height="40px"
                            right
                            width="40px"
                          >
                            <font-awesome-icon
                              class="icon"
                              icon="chevron-right"
                              size="2x"
                            />
                          </v-btn>
                        </v-card-actions>
                      </div>

                      <v-avatar class="ma-3" size="125" tile>
                        <v-img :src="require(`@/assets/judgement.svg`)"></v-img>
                      </v-avatar>
                    </div>
                  </v-card>
                </v-list-item-content>
              </v-list-item>
            </v-list-item-group>
          </v-list>
        </div>
      </v-col>
    </v-row>
    <div
      v-if="intersection_active"
      v-intersect="{
        handler: getPagedArtistList,
        options: {
          threshold: [1.0],
        },
      }"
    ></div>
  </v-container>
</template>

<script>
import { required } from "vuelidate/lib/validators";
import useArtists from "@/modules/artists";

export default {
  name: "ArtistListPage",
  components: {},
  data() {
    return {
      artists: [],
      filters: {},
      page: 0,
      records_quantity: 5,
      default_sort_type: "Alfabetycznie malejąco",
      sort_types: [
        "Alfabetycznie malejąco",
        "Alfabetycznie rosnąco",
        "Po popularności malejąco",
        "Po popularności rosnąco",
      ],
      selected_sort_type: 0,
      is_date_picker_from: false,
      is_date_picker_to: false,
      intersection_active: true,
      show: null,
    };
  },
  created() {
    this.setDefaultFilters();
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
        return this.default_sort_type;
      },
      set(newType) {
        this.default_sort_type = newType;
        this.selected_sort_type = 0;
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
  methods: {
    redirectToArtist(artistId) {
      this.$router.push({ name: "ArtistPage", params: { id: artistId } });
    },
    prepareErrorArray(field) {
      const errors = [];
      if (!this.$v.filters[field].$dirty) return errors;
      !this.$v.filters[field].required && errors.push("Pole jest wymagane.");
      return errors;
    },
    parseDate(date) {
      return this.moment.utc(date).format();
    },
    filterList() {
      this.artists = [];
      this.page = 0;
      this.intersection_active = true;
    },
    setDefaultFilters() {
      (this.filters = {
        establishment_date_from: this.moment("1970-01-01").format("YYYY-MM-DD"),
        establishment_date_to: this.moment().add(10, "y").format("YYYY-MM-DD"),
      }),
        (this.updateDefaultSortType = "Alfabetycznie malejąco");
      this.filterList();
    },
    setSelectedType(selectedType) {
      this.selected_sort_type = this.sort_types.findIndex(
        (sortType) => sortType == selectedType
      );
    },
  },

  setup() {
    const { getPaged } = useArtists();

    const getPagedArtistList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPaged(
          this.page,
          this.records_quantity,
          this.selected_sort_type,
          this.parseDate(this.filters.establishment_date_from),
          this.parseDate(this.filters.establishment_date_to)
        )
          .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.artists.push(item);
              });
            } else {
              this.intersection_active = false;
            }
          })
          .catch((err) => {
            console.log(err);
          });
        this.page++;
      }
    };

    return {
      getPagedArtistList,
    };
  },
};
</script>

<style scoped>
.theme--light.v-card {
  background-color: #f5f5f5;
}
</style>
