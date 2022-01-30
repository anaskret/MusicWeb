<template>
<div>

  <InfiniteScrollList
  v-if="this.type == 'favorite'"
    :items="albums"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getFavoriteList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="favorite_module_name"
  />
  <InfiniteScrollList
  v-else-if="this.type == 'discography' && this.item_id != null"
    :items="albums"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getDiscographyList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="favorite_module_name"
  />
  <InfiniteScrollList
  v-else
    :items="albums"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedAlbumList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="module_name"
  />
</div>
</template>

<script>
import useAlbums from "@/modules/albums";
import useArtists from "@/modules/artists";
import useUserFavoriteAlbums from "@/modules/userFavoriteAlbums.js";
import InfiniteScrollList from "@/components/InfiniteScrollList";
import {mapGetters, mapMutations} from "vuex";


export default {
  name: "AlbumListPage",
  components: {
    InfiniteScrollList,
  },
  data() {
    return {
      albums: [],
      filters: {},
      scroll_settings: {
        page: 0,
        records_quantity: 5,
        default_sort_type: "Ascending Alphabetical",
        sort_types: [
          "Ascending Alphabetical",
          "Descending Alphabetical",
          "Descending Popularity",
          "Ascending Popularity",
        ],
        selected_sort_type: 0,
      },
      intersection_active: true,
      redirect_module_name: "AlbumPage",
      last_search: "",
      module_name: "AlbumList",
      favorite_module_name: "AlbumFavoriteList",
      type: this.$route.params.type,
      item_id: this.$route.params.id,
    };
  },
  watch: {
    searchingValue: {
      immediate: true,
      handler() {
      if (
          this.searchingValue && this.last_search != this.searchingValue
        ) {
          this.albums = [];
          this.scroll_settings.page = 0;
          this.intersection_active = true;
         this.getPagedAlbumList("", "", true);
        }
      }
    },
  },
  methods: {
    parseDate(date) {
      return this.moment.utc(date).format();
    },
    filterList() {
      this.albums = [];
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
    const { getPagedAlbums } = useAlbums();
    const { getDiscography } = useArtists();
    const { getUserFavoriteAlbums } = useUserFavoriteAlbums();

    const getPagedAlbumList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPagedAlbums(
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
                return this.albums.push(item);
              });
              this.last_search = this.searchingValue;
            } else {
             this.intersection_active = false;
            }
          })
          .catch((err) => {
            console.log(err);
          });
        this.scroll_settings.page++;
      }
    };

    const getDiscographyList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getDiscography(
          this.item_id,
          this.scroll_settings.page,
          this.scroll_settings.records_quantity
        )
           .then((response) => {
          if (response.length > 0) {
            response.forEach((item) => {
              return this.albums.push(item);
            });
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
    const getFavoriteList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getUserFavoriteAlbums(
          this.$store.state.auth.userId,
          this.scroll_settings.page,
          this.scroll_settings.records_quantity
        )
           .then((response) => {
          if (response.length > 0) {
            response.forEach((item) => {
              return this.albums.push(item);
            });
          }  else {
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
      getPagedAlbumList,
      getFavoriteList,
      getDiscographyList
    };
  },
};
</script>

<style scoped>
.theme--light.v-card {
  background-color: #f5f5f5;
}
</style>
