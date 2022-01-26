<template>
<div>

  <InfiniteScrollList
  v-if="this.type == 'favorite'"
    :items="songs"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getFavoriteList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="favorite_module_name"
  />
    <InfiniteScrollList
  v-else-if="this.type == 'artist' && this.item_id != null"
    :items="songs"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getSongsList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="favorite_module_name"
  />
    <InfiniteScrollList
  v-else-if="this.type == 'album' && this.item_id != null"
    :items="songs"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getAlbumSongsList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="favorite_module_name"
  />
   <InfiniteScrollList
  v-else
    :items="songs"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedSongList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="module_name"
  />
</div>
</template>

<script>
import useSongs from "@/modules/songs";
import useArtists from "@/modules/artists";
import useAlbums from "@/modules/albums";
import InfiniteScrollList from "@/components/InfiniteScrollList";
import useUserFavoriteSongs from "@/modules/userFavoriteSongs.js";
import {mapGetters, mapMutations} from "vuex";



export default {
  name: "SongListPage",
  components: {
    InfiniteScrollList,
  },
  data() {
    return {
      songs: [],
      filters: {},
      scroll_settings: {
        page: 0,
        records_quantity: 5,
        default_sort_type: "Descending Alfabetical",
        sort_types: [
          "Descending Alfabetical",
          "Ascending Alfabetical",
          "Descending Popularity",
          "Ascending Popularity",
        ],
        selected_sort_type: 0,
      },
      intersection_active: true,
      redirect_module_name: "SongPage",
      last_search: "",
      module_name: "SongList",
      type: this.$route.params.type,
      favorite_module_name: "SongFavoriteList", 
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
          this.songs = [];
          this.scroll_settings.page = 0;
          this.intersection_active = true;
         this.getPagedSongList("", "", true);
        }
      }
    },
  },
  methods: {
    parseDate(date) {
      return this.moment.utc(date).format();
    },
    filterList() {
      this.songs = [];
      this.scroll_settings.page = 0;
      this.intersection_active = true;
    },
    setFilters(filters) {
      this.filters = filters;
    },
    ...mapMutations([
      "setSearching",
    ])
  },
  computed: {
    ...mapGetters([
      'searchingValue', 
      'searchingType',
      'intersection',
    ]),

  },

  setup() {
    const { getPagedSongs } = useSongs();
    const { getSongs } = useArtists();
    const { getAlbumSongs } = useAlbums();
    const { getUserFavoriteSongs } = useUserFavoriteSongs();

    const getPagedSongList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPagedSongs(
          this.scroll_settings.page,
          this.scroll_settings.records_quantity,
          this.scroll_settings.selected_sort_type,
          '1900-01-01',
          '2200-01-01',
          this.searchingValue
        )
          .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.songs.push(item);
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

    const getSongsList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getSongs(
          this.item_id,
          this.scroll_settings.page,
          this.scroll_settings.records_quantity
        )
        .then((response) => {
          if (response.length > 0) {
            response.forEach((item) => {
              return this.songs.push(item);
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

    const getAlbumSongsList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getAlbumSongs(
          this.item_id,
          this.scroll_settings.page,
          this.scroll_settings.records_quantity
        )
        .then((response) => {
          if (response.length > 0) {
            response.forEach((item) => {
              return this.songs.push(item);
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
        getUserFavoriteSongs(
          this.$store.state.auth.userId,
          this.scroll_settings.page,
          this.scroll_settings.records_quantity
        )
           .then((response) => {
          if (response.length > 0) {
            response.forEach((item) => {
              return this.songs.push(item);
            });
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


    return {
      getPagedSongList,
      getFavoriteList, 
      getSongsList,
      getAlbumSongsList,
    };
  },
};
</script>

<style scoped>
.theme--light.v-card {
  background-color: #f5f5f5;
}
</style>
