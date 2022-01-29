<template>
  <div class="SearchBar">
    <div v-if="searchClosed">
        <v-text-field
            v-model="search"
            class="search"
            :class="{ closed: searchClosed && !search}"
            outlined
            placeholder="Search"
            filled
            prepend-inner-icon="mdi-magnify"
            @focus="searchClosed = false"
            clearable
        ></v-text-field>
    </div>
    <div v-else class="search-container">
        <v-text-field
            v-model="search"
            class="search"
            placeholder="Search"
            filled
            prepend-inner-icon="mdi-magnify"
            @blur="searchClosed = true"
            clearable
            v-on:keyup.enter="searchData"
            style="width: 30%;height: 50%;"
        ></v-text-field>
        <v-select
            v-model="type"
            class="search-type"
            :items="items"
            filled
            label="Type"
            style="width: 30%;height: 50%;"
        ></v-select>
    </div>
  </div>
</template>

<script>
import {mapMutations} from "vuex";

export default {
  name: "SearchBar",
  data() {
    return {
      search: null,
      searchClosed: true,
      type: null,
      items:[
        "Artist",
        "Album",
        "Song",
      ]
    };
  },
  methods: {
    searchData() {
      this.setSearching(this.search, this.type);
      if (this.type == "Artist" && this.$router.currentRoute.path !== "/artists") {
        this.$router.push({ name: "ArtistListPage" });
      }
      else if (this.type == "Album" && this.$router.currentRoute.path !== "/albums") {
        this.$router.push({ name: "AlbumListPage" });
      }
      else if (this.type == "Song" && this.$router.currentRoute.path !== "/songs") {
        this.$router.push({ name: "SongListPage" });
      }
      },
    ...mapMutations([
      "setSearching",
    ])
  },
};
</script>

<style lang="scss">
.SearchBar{
    display: flex;
    align-items: center;
    position: absolute;
    right: 3%;
    top: 17%;
}
.v-input.search{
    transition: max-width 0.3s ease-in-out;
    animation-direction: reverse;
    .v-input__slot{
        cursor: pointer;
        &:before, &:after{
            border-color: transparent;
        }
    }
    &.closed{
        max-width: 45px;
    }
}
.search-container{
    display: flex;
    flex-direction: row;
    justify-content: flex-end;
}
@media (min-width: 1300px) and (max-width: 1600px){
    .SearchBar{
        right: 4%;
    }
}
@media (min-width: 1000px) and (max-width: 1300px){
    .SearchBar{
        right: 5%;
    }
}
@media (min-width: 850px) and (max-width: 1000px){
    .SearchBar{
        right: 6%;
    }
}
@media (min-width: 700px) and (max-width: 850px){
    .SearchBar{
        right: 7%;
    }
}
@media (max-width: 720px){
    .SearchBar{
        right: 47%;
        top: 38%;
    }
    .search-container{
        right: 0!important;
    }
    .search-type{
        width: 50%!important;
    }
    .search{
        width: 49%!important;
    }
}
</style>
