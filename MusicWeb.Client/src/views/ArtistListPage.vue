<template>
  <v-container fluid grid-list-lg class="py-16">
    <v-row justify="center">
      <v-col lg="8">
        <div class="mx-auto">
          <div class="d-flex">
            <v-menu
              v-model="isDatePickerFrom"
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
                  v-model.trim="$v.filters.establishmentDateFrom.$model"
                  :error-messages="establishmentDateFromErrors"
                  readonly
                  required
                  @input="$v.filters.establishmentDateFrom.$touch()"
                  @blur="$v.filters.establishmentDateFrom.$touch()"
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
              <v-date-picker
                color="#647da1"
                v-model.trim="$v.filters.establishmentDateFrom.$model"
                @input="isDatePickerFrom = false"
              ></v-date-picker>
            </v-menu>
            <v-menu
              v-model="isDatePickerTo"
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
                  v-model.trim="$v.filters.establishmentDateTo.$model"
                  :error-messages="establishmentDateToErrors"
                  readonly
                  required
                  @input="$v.filters.establishmentDateTo.$touch()"
                  @blur="$v.filters.establishmentDateTo.$touch()"
                  v-bind="attrs"
                  v-on="on"
                ></v-text-field>
              </template>
              <v-date-picker
                color="#647da1"
                v-model.trim="$v.filters.establishmentDateTo.$model"
                @input="isDatePickerTo = false"
              ></v-date-picker>
            </v-menu>
          </div>
          <v-select
            :items="sortTypes"
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
      v-if="intersectionActive"
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
      recordsQuantity: 5,
      defaultSortType: "Alfabetycznie malejąco",
      sortTypes: [
        "Alfabetycznie malejąco",
        "Alfabetycznie rosnąco",
        "Po popularności malejąco",
        "Po popularności rosnąco",
      ],
      slectedSortType: 0,
      isDatePickerFrom: false,
      isDatePickerTo: false,
      intersectionActive: true,
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
      return this.prepareErrorArray("establishmentDateFrom");
    },
    establishmentDateToErrors() {
      return this.prepareErrorArray("establishmentDateTo");
    },
    updateDefaultSortType:{
      get(){
        return this.defaultSortType;
      },
      set(newType){
        this.defaultSortType = newType;
        this.slectedSortType = 0;
      }
    }
  },

  validations: {
    filters: {
      establishmentDateFrom: {
        required,
      },
      establishmentDateTo: {
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
      this.intersectionActive = true;
    },
    setDefaultFilters() {
      (this.filters = {
        establishmentDateFrom: this.moment("1970-01-01").format("YYYY-MM-DD"),
        establishmentDateTo: this.moment().add(10, "y").format("YYYY-MM-DD"),
      }),
        this.updateDefaultSortType = "Alfabetycznie malejąco";
        this.filterList();
    },
    setSelectedType(selectedType) {
      this.slectedSortType = this.sortTypes.findIndex(
        (sortType) => sortType == selectedType
      );
    },
  },

  setup() {
    const { getPaged } = useArtists();

    const getPagedArtistList = function (entries, observer, isIntersecting) {
      if (isIntersecting) {
        getPaged(
          this.page,
          this.recordsQuantity,
          this.slectedSortType,
          this.parseDate(this.filters.establishmentDateFrom),
          this.parseDate(this.filters.establishmentDateTo)
        )
          .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.artists.push(item);
              });
            } else {
              this.intersectionActive = false;
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
