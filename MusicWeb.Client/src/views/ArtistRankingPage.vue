<template>
  <InfiniteScrollList
    :items="artists"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedArtistList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="module_name"
    :columns_list="columns_list"
  />
</template>

<script>
import useArtists from "@/modules/artists";
import useAlbums from "@/modules/albums";
import InfiniteScrollList from "@/components/InfiniteScrollList";

export default {
  name: "Ranking",
  components: {
    InfiniteScrollList,
  },
  data() {
    return {
      artists: [],
      albums: [],
      scroll_settings: {
        page: 0,
        records_quantity: 10,
        default_ranking_type: "Po popularności malejąco",
        selected_sort_type: 3,
      },
      intersection_active: true,
      redirect_module_name: "ArtistPage",
      module_name: "ArtistRanking",
      columns_list: ["Position", "", "Artist", "Rating", "Amount of ratings", "Favorite", "Watched"],
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
    },
    setFilters(filters) {
      this.filters = filters;
    },
  },

  setup() {
    const { getPagedArtists } = useArtists();    
    const { getPagedAlbums } = useAlbums();


    const getPagedArtistList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        console.log(this.scroll_settings.selected_sort_type)
        getPagedArtists(
          this.scroll_settings.page,
          this.scroll_settings.records_quantity,
          3,
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

    const getPagedAlbumList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPagedAlbums(
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
                return this.albums.push(item);
              });
                console.log(this.albums);
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
      getPagedArtistList,
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
