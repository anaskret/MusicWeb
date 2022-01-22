<template>
  <InfiniteScrollList
    :items="songs"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedSongList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="module_name"
  />
</template>

<script>
import useSongs from "@/modules/songs";
import InfiniteScrollList from "@/components/InfiniteScrollList";
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
        default_sort_type: "Alfabetycznie malejąco",
        sort_types: [
          "Alfabetycznie malejąco",
          "Alfabetycznie rosnąco",
          "Po popularności malejąco",
          "Po popularności rosnąco",
        ],
        selected_sort_type: 0,
      },
      intersection_active: true,
      redirect_module_name: "SongPage",
      last_search: "",
      module_name: "SongList",
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

    return {
      getPagedSongList,
    };
  },
};
</script>

<style scoped>
.theme--light.v-card {
  background-color: #f5f5f5;
}
</style>
