<template>
<div>

   <InfiniteScrollList
    v-if="id != null"
    :items="albumReviews"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getAlbumReviewsList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="module_name"
    :page="page_name"
  />
  <InfiniteScrollList
  v-else
    :items="albumReviews"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedAlbumReviewList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="module_name"
  /> 
</div>
</template>

<script>
import useAlbumReviews from "@/modules/albumReviews";
import InfiniteScrollList from "@/components/InfiniteScrollList";

export default {
  name: "AlbumReviewListPage",
  components: {
    InfiniteScrollList,
  },
  data() {
    return {
      albumReviews: [],
      filters: {},
      scroll_settings: {
        page: 0,
        records_quantity: 5,
        default_sort_type: "Descending Alphabetical",
        sort_types: [
          "Descending Alphabetical",
          "Ascending Alphabetical",
          "Descending Popularity",
          "Ascending Popularity",
        ],
        selected_sort_type: 0,
      },
      intersection_active: true,
      redirect_module_name: "AlbumReviewPage",
      last_search: "",
      module_name: "AlbumReviewList",
      album_module_name: "ReviewForAlbumList",
      id: this.$route.params.id,
      page_name: "ReviewsForAlbum",
    };
  },
  watch: {
    "$store.state.searchingValue": function () {
      if (
        this.last_search !== this.$store.state.searchingValue &&
        this.$store.state.searchingValue
      ) {
        this.albumReviews = [];
        this.getPagedAlbumReviewList("", "", true);
        this.$store.state.searchingValue = "";
      }
    },
  },
  methods: {
    parseDate(date) {
      return this.moment.utc(date).format();
    },
    filterList() {
      this.albumReviews = [];
      this.scroll_settings.page = 0;
      this.intersection_active = true;
    },
    setFilters(filters) {
      this.filters = filters;
    },
  },

  setup() {
    const { getPaged, getAlbumReviews } = useAlbumReviews();

    const getPagedAlbumReviewList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPaged(
          this.scroll_settings.page,
          this.scroll_settings.records_quantity,
          this.scroll_settings.selected_sort_type,
          '1990-12-13T16:26:14.374Z',
          this.parseDate(this.filters.release_date_to),
          " "
        )
          .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.albumReviews.push(item);
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
    const getAlbumReviewsList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getAlbumReviews(
          this.id,
          this.scroll_settings.page,
          this.scroll_settings.records_quantity
        )
          .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.albumReviews.push(item);
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
      getPagedAlbumReviewList,
      getAlbumReviewsList,
    };
  },
};
</script>

<style scoped>
.theme--light.v-card {
  background-color: #f5f5f5;
}
</style>
