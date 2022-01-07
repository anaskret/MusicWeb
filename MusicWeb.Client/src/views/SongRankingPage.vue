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
    :columns_list="columns_list"
  />
</template>

<script>
import useSongs from "@/modules/songs";
import InfiniteScrollList from "@/components/InfiniteScrollList";

export default {
  name: "SongRanking",
  components: {
    InfiniteScrollList,
  },
  data() {
    return {
      songs: [],
      scroll_settings: {
        page: 0,
        records_quantity: 10,
        default_ranking_type: "Po popularności malejąco",
        selected_sort_type: 3,
      },
      intersection_active: true,
      redirect_module_name: "SongPage",
      module_name: "SongRanking",
      columns_list: ["Position", "", "Song", "Rating", "Amount of ratings", "Favorite", "Reviews"],
    };
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
  },

  setup() {
    const { getPagedSongs } = useSongs();

    const getPagedSongList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPagedSongs(
          this.scroll_settings.page,
          this.scroll_settings.records_quantity,
          this.scroll_settings.selected_sort_type,
          '1990-12-13T16:26:14.374Z',
          // this.parseDate(this.filters.release_date_from),
          this.parseDate(this.filters.release_date_to),
          this.$store.state.searchingValue
        )
          .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.songs.push(item);
              });
                console.log(this.songs);
              this.last_search = this.$store.state.searchingValue;
              this.$store.state.searchingValue = "";
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
