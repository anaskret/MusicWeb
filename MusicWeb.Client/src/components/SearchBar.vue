<template>
  <div class="SearchBar">
    <div v-if="searchClosed">
    <v-text-field
      v-model="search"
      class="search mt-6"
      :class="{ closed: searchClosed && !search }"
      outlined
      placeholder="Search"
      filled
      prepend-inner-icon="mdi-magnify"
      @focus="searchClosed = false"
      clearable
    ></v-text-field>
    </div>
    <div v-else class="d-flex flex-row">
    <v-text-field
      
      v-model="search"
      class="search mt-6"
      placeholder="Search"
      filled
      prepend-inner-icon="mdi-magnify"
      @blur="searchClosed = true"
      clearable
      v-on:keyup.enter="searchData"
      

    ></v-text-field>
     <v-select
     v-model="type"
          :items="items"
          filled
          label="Type"
          class="mt-6"
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
</style>
