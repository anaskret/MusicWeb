<template>
  <InfiniteScrollList
    :items="artists"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedArtistList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
  />
</template>

<script>
import useArtists from "@/modules/artists";
import InfiniteScrollList from "@/components/InfiniteScrollList";

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
      redirect_module_name: "ArtistPage"
    };
  },
  methods: {
    parseDate(date) {
      return this.moment.utc(date).format();
    },
    filterList() {
      this.artists = [];
      this.scroll_settings.page = 0;
      this.intersection_active = true;
      this.getPagedArtistList();
    },
    setFilters(filters) {
      this.filters = filters;
    },
  },

  setup() {
    const { getPaged } = useArtists();

    const getPagedArtistList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPaged(
          this.scroll_settings.page,
          this.scroll_settings.records_quantity,
          this.scroll_settings.selected_sort_type,
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
        this.scroll_settings.page++;
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
