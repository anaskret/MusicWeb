<template>
  <v-container fluid grid-list-lg class="py-16">
    <v-row justify="center">
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
              :items="scroll_settings.sort_types"
              label="Sortuj"
              @change="setSelectedType"
              v-model="updateDefaultSortType"
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
          <v-list v-if="module_name == 'Activities'">
            <div class="text-center">
              <v-dialog v-model="new_post_dialog" width="70vw">
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field
                    label="What happened today?"
                    class="pb-1"
                    v-model="post.text"
                    color="white"
                    v-bind="attrs"
                    v-on="on"
                    readonly
                    @click="focusTextarea"
                  />
                  <!-- <v-btn
                    outlined
                    color="grey"
                    height="30px"
                    class="text-uppercase align-self-center"
                    v-bind="attrs"
                    v-on="on"
                  >
                    Add Post
                  </v-btn> -->
                </template>

                <form id="newPostForm" @submit.prevent="addPost">
                  <v-card
                    style="background-color: #1e1e1e"
                    class="px-16"
                  >
                    <v-card-title class="px-0 pt-8 pb-4">Add Post</v-card-title>
                    <div>
                      <v-textarea
                        ref="textarea"
                        v-model="post.text"
                        auto-grow
                        filled
                        color="inherit"
                        label="What happened today?"
                        rows="5"
                      ></v-textarea>
                    </div>
                    <v-card-actions>
                      <v-btn
                        color="grey"
                        height="30px"
                        class="text-uppercase align-self-center pa-3"
                        type="submit"
                        outlined
                        >Add</v-btn
                      >
                    </v-card-actions>
                  </v-card>
                </form>
              </v-dialog>
            </div>
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
import InfiniteScrolItem from "@/components/InfiniteScrolItem";
import useAccounts from "@/modules/accounts";
import Post from "@/models/Post";
import moment from "moment";
export default {
  name: "InfiniteScrollList",
  data() {
    return {
      filters: {},
      is_date_picker_from: false,
      is_date_picker_to: false,
      show_list: null,
      new_post_dialog: false,
      post: new Post()
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
    focusTextarea(){
      debugger;
      this.$refs.textarea.$el.focus();
    }
  },
  
  setup() {
    const { addAccountPost } = useAccounts();

    const addPost = function () {
      this.post.createDate = moment.utc().format();
      this.post.posterId = this.$store.state.auth.userId;
      if (
        this.post.text == null ||
        this.post.text == ""
      ) {
        this.$emit("show-alert", "Post cannot be empty.", "error");
        this.new_post_dialog = true;
      } else {
        addAccountPost(this.post).then(
          (response) => {
            if (response.status == 200) {
              this.getPagedItemList();
              this.post.text = null;
              this.new_post_dialog = false;
              this.$emit("show-alert", "Post added.", "success");
            } else {
              this.$emit(
                "show-alert",
                `Something went wrong. Error ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Something went wrong. ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      }
    };
    return {
      addPost,
    };
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
