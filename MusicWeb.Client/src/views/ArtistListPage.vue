<template>
<div>
  <InfiniteScrollList
  v-if="this.type == 'favorite'"
    :items="artists"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getFavoriteList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="favorite_module_name"
  />
  <InfiniteScrollList
  v-else-if="this.type == 'observed'"
    :items="artists"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getObservedList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="observed_module_name"
  />
  <InfiniteScrollList
  v-else
    :items="artists"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedArtistList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="module_name"
  />
</div>
</template>

<script>
import useArtists from "@/modules/artists";
import useUserFavoriteArtists from "@/modules/userFavoriteArtists.js";
import useUserObservedArtists from "@/modules/userObservedArtists.js";
import InfiniteScrollList from "@/components/InfiniteScrollList";
import {mapGetters, mapMutations} from "vuex";


export default {
  name: "ArtistListPage",
  components: {
    InfiniteScrollList,
  },
  data() {
    return {
      artists: [],
      filters: {},
      scroll_settings: {
        page: 0,
        records_quantity: 5,
        default_sort_type: "Ascending Alfabetical",
        sort_types: [
          "Ascending Alfabetical",
          "Descending Alfabetical",
          "Descending Popularity",
          "Ascending Popularity",
        ],
        selected_sort_type: 0,
      },
      intersection_active: true,
      redirect_module_name: "ArtistPage",
      last_search: "",
      module_name: "ArtistList",
      favorite_module_name: "ArtistFavoriteList", 
      observed_module_name: "ArtistObservedList",
      type: this.$route.params.type,
    };
  },
  watch: {
    searchingValue: {
      immediate: true,
      handler() {
      if (
          this.searchingValue && this.last_search != this.searchingValue
        ) {
          this.artists = [];
          this.scroll_settings.page = 0;
          this.intersection_active = true;
         this.getPagedArtistList("", "", true);
        }
      }
    },
  },
  methods: {
    parseDate(date) {
      return this.moment(date).format();
    },
    filterList() {
      this.artists = [];
      this.scroll_settings.page = 0;
      this.intersection_active = true;
    },
    setFilters(filters) {
      this.filters = filters;
    },
    ...mapMutations([
      "setSearching",
    ]), 
  },
  computed: {
    ...mapGetters([
      'searchingValue', 
      'searchingType',
      'intersection',
    ]),    
  },
  setup() {
    const { getPagedArtists } = useArtists();
    const { getUserFavoriteArtists } = useUserFavoriteArtists();
    const { getUserObservedArtists } = useUserObservedArtists();

    const getPagedArtistList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPagedArtists(
          this.scroll_settings.page,
          this.scroll_settings.records_quantity,
          this.scroll_settings.selected_sort_type,
          '0001-01-01',
          '2200-01-01',
          this.searchingValue
        )
          .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.artists.push(item);
              });
              this.last_search = this.searchingValue;
            } else {
             this.intersection_active = false;
             console.log(false);
            }
          })
          .catch((err) => {
            console.log(err);
          });
        this.scroll_settings.page++;
      }
    };

     const getFavoriteList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getUserFavoriteArtists(
          this.$store.state.auth.userId,
          this.scroll_settings.page,
          this.scroll_settings.records_quantity
        )
         .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.artists.push(item);
              });
            }else {
             this.intersection_active = false;
            }
          })
          .catch((err) => {
            console.log(err);
          });
        this.scroll_settings.page++;
      }
    };
     const getObservedList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getUserObservedArtists(
          this.$store.state.auth.userId,
          this.scroll_settings.page,
          this.scroll_settings.records_quantity
        )
          .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.artists.push(item);
              });
              this.last_search = this.searchingValue;
            }
             else {
             this.intersection_active = false;
            }
          })
          .catch((err) => {
            console.log(err);
          });
        this.scroll_settings.page++;
      }
    };

    return {
      getPagedArtistList,
      getFavoriteList,
      getObservedList,
    };
  },
};
</script>

<style scoped>
.theme--light.v-card {
  background-color: #f5f5f5;
}
</style>
