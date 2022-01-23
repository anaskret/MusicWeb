<template>
  <InfiniteScrollList
    :items="songReviews"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedSongReviewList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="module_name"
  />
</template>

<script>
import useSongReviews from "@/modules/songReviews";
import InfiniteScrollList from "@/components/InfiniteScrollList";

export default {
  name: "SongReviewListPage",
  components: {
    InfiniteScrollList,
  },
  data() {
    return {
      songReviews: [],
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
      redirect_module_name: "SongReviewPage",
      last_search: "",
      module_name: "SongReviewList",
    };
  },
  watch: {
    "$store.state.searchingValue": function () {
      if (
        this.last_search !== this.$store.state.searchingValue &&
        this.$store.state.searchingValue
      ) {
        this.songReviews = [];
        this.getPagedSongReviewList("", "", true);
        this.$store.state.searchingValue = "";
      }
    },
  },
  methods: {
    parseDate(date) {
      return this.moment.utc(date).format();
    },
    filterList() {
      this.songReviews = [];
      this.scroll_settings.page = 0;
      this.intersection_active = true;
    },
    setFilters(filters) {
      this.filters = filters;
    },
  },

  setup() {
    const { getPaged } = useSongReviews();

    const getPagedSongReviewList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPaged(
          this.scroll_settings.page,
          this.scroll_settings.records_quantity,
          this.scroll_settings.selected_sort_type,
          '1990-12-13T16:26:14.374Z',
          // this.parseDate(this.filters.release_date_from),
          this.parseDate(this.filters.release_date_to),
          this.scroll_settings.searchingValue
        )
          .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.songReviews.push(item);
              });
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
      getPagedSongReviewList,
    };
  },
};
</script>

<style scoped>
.theme--light.v-card {
  background-color: #f5f5f5;
}
</style>
