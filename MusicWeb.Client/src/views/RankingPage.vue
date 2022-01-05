<template>
  <RankingList
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedArtistList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="module_name"
  />
</template>

<script>
import useArtists from "@/modules/artists";
import RankingList from "@/components/RankingList";
import { mapMutations } from 'vuex';

export default {
  name: "ArtistListPage",
  components: {
    RankingList,
  },
  data() {
    return {
      artists: [],
      filters: {},
      scroll_settings: {
        totalItems: 100,
        records_quantity: 10,
        page: 0,
      },
      intersection_active: true,
      redirect_module_name: "ArtistPage",
      last_search: "",
      module_name: "ArtistList",
    };
  },
  watch: {
    artists() {
      this.setRanking(this.artists);
    }
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
    ...mapMutations([
      'setRanking'
    ]),
  },

  setup() {
    const { getPaged } = useArtists();

    const getPagedArtistList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPaged(
          this.scroll_settings.page,
          this.scroll_settings.records_quantity,
          0,
          this.parseDate(this.filters.establishment_date_from),
          this.parseDate(this.filters.establishment_date_to),
          this.$store.state.searchingValue
        )
          .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.artists.push(item);
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
