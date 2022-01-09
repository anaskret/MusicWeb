<template>
<div>

  <InfiniteScrollList
    :items="artists"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedArtistList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_artist"
    :module_name="module_name"
  />
  <InfiniteScrollList
    :items="albums"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedAlbumList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_album"
    :module_name="module_name"
  />
  <InfiniteScrollList
    :items="songs"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedSongList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_song"
    :module_name="module_name"
  />

</div>
</template>

<script>
import useArtists from "@/modules/artists";
import useAlbums from "@/modules/albums";
import useSongs from "@/modules/songs";
import InfiniteScrollList from "@/components/InfiniteScrollList";


export default {
  name: "SearchPage",
  components: {
    InfiniteScrollList,
  },
  data() {
    return {
      artists: [],
      albums: [],
      songs: [],
      filters: {},
      scroll_settings: {
        artist_page: 0,
        album_page: 0,
        song_page: 0,
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
      redirect_module_artist: "ArtistPage",
      redirect_module_album: "AlbumPage",
      redirect_module_song: "SongPage",
      last_search: "",
      module_name: "SearchPage",
    };
  },
  watch: {
    "$store.state.searchingValue": function () {
      if (
        this.last_search !== this.$store.state.searchingValue &&
        this.$store.state.searchingValue
      ) {
        debugger;
        this.artists = [];
        this.albums = [];
        this.songs = [];
        this.scroll_settings.artist_page = 0;
        this.scroll_settings.album_page = 0;
        this.scroll_settings.song_page = 0;
        this.getPagedArtistList("", "", true);
        this.getPagedAlbumList("", "", true);
        this.getPagedSongList("", "", true);
      }
    },
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
    const { getPagedSongs } = useSongs();

    const getPagedArtistList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPagedArtists(
          this.scroll_settings.artist_page,
          this.scroll_settings.records_quantity,
          this.scroll_settings.selected_sort_type,
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
        this.scroll_settings.artist_page++;
      }
    };

     const getPagedAlbumList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPagedAlbums(
          this.scroll_settings.album_page,
          this.scroll_settings.records_quantity,
          this.scroll_settings.selected_sort_type,
          '1900-12-13T16:26:14.374Z',
          '2030-12-13T16:26:14.374Z',
          this.$store.state.searchingValue
        )
          .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.albums.push(item);
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
        this.scroll_settings.album_page++;
      }
    };

    const getPagedSongList = function (entries, observer, is_intersecting) {
      debugger;
      if (is_intersecting) {
        getPagedSongs(
          this.scroll_settings.song_page,
          this.scroll_settings.records_quantity,
          this.scroll_settings.selected_sort_type,
          '1900-12-13T16:26:14.374Z',
          '2030-12-13T16:26:14.374Z',
          // this.parseDate(this.filters.release_date_to),
          this.$store.state.searchingValue
        )
          .then((response) => {
            debugger;
            if (response.length > 0) {
              response.forEach((item) => {
                return this.songs.push(item);
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
        this.scroll_settings.song_page++;
      }
    };


    return {
      getPagedArtistList,
      getPagedAlbumList,
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
