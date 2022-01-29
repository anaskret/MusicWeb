<template>
    <v-container fluid class="py-16">
        <v-row>
            <v-col lg="12" sm="12" class="ranking-header">
                <h1>
                    <span>Song</span> <span class="ranking-header-second">Ranking</span>
                </h1>
            </v-col>
        </v-row>
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
            @sort-list="sortList"
        />
    </v-container>
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
        records_quantity: 15,
        selected_sort_type: 3,
      },
      intersection_active: true,
      redirect_module_name: "SongPage",
      module_name: "SongRanking",
      columns_list: [
          {name: "Position"}, 
          {name: ""}, 
          {name: "Song"}, 
          {name: "Rating", sort_type_asc: 0, sort_type_desc: 1}, 
          {name: "Amount of ratings", sort_type_asc: 2, sort_type_desc: 3}, 
          {name: "Favorite", sort_type_asc: 4, sort_type_desc: 5}, 
          {name: "Reviews", sort_type_asc: 6, sort_type_desc: 7}
      ],
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
    sortList(sort_type){
        this.scroll_settings.selected_sort_type = sort_type;
        this.filterList();
        this.getPagedSongList('', '', true);
    }
  },

  setup() {
    const { getPagedSongsRanking } = useSongs();

    const getPagedSongList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPagedSongsRanking(
          this.scroll_settings.selected_sort_type,
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
    };
  },
};
</script>

<style scoped>
.theme--light.v-card {
  background-color: #f5f5f5;
}
.ranking-header{
    display: flex;
    justify-content: center;
}
.ranking-header-second{
    font-weight: 300;
}
</style>
