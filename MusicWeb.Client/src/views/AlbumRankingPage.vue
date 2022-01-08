<template>
  <InfiniteScrollList
    :items="albums"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedAlbumList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="module_name"
    :columns_list="columns_list"
  />
</template>

<script>
import useAlbums from "@/modules/albums";
import InfiniteScrollList from "@/components/InfiniteScrollList";

export default {
  name: "AlbumRanking",
  components: {
    InfiniteScrollList,
  },
  data() {
    return {
      albums: [],
      scroll_settings: {
        page: 0,
        records_quantity: 5,
        default_ranking_type: "Po popularności malejąco",
        selected_sort_type: 3,
      },
      intersection_active: true,
      redirect_module_name: "AlbumPage",
      module_name: "AlbumRanking",
      columns_list: ["Position", "", "Album", "Rating", "Amount of ratings", "Favorite", "Reviews"],
    };
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
  },

  setup() {
    const { getPagedAlbums } = useAlbums();

    const getPagedAlbumList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPagedAlbums(
          this.scroll_settings.page,
          this.scroll_settings.records_quantity,
          3,
          '1970-12-13T16:26:14.374Z',
          '2030-12-13T16:26:14.374Z'
        )
          .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.albums.push(item);
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
      getPagedAlbumList,
    };
  },
};
</script>

<style scoped>
.theme--light.v-card {
  background-color: #f5f5f5;
}
</style>
