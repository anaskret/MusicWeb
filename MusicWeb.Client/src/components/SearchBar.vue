<template>
  <div class="SearchBar">
    <v-text-field
      v-if="searchClosed"
      v-model="search"
      class="search mt-6"
      :class="{ closed: searchClosed && !search }"
      outlined
      placeholder="Search"
      filled
      dense
      prepend-inner-icon="mdi-magnify"
      @focus="searchClosed = false"
      clearable
    ></v-text-field>
    <v-text-field
      v-else
      v-model="search"
      class="search mt-6"
      placeholder="Search"
      filled
      dense
      prepend-inner-icon="mdi-magnify"
      @blur="searchClosed = true"
      clearable
      v-on:keyup.enter="searchData"
    ></v-text-field>
            <v-select
          :items="items"
          label="Standard"
        ></v-select>
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
    };
  },
  methods: {
    searchData() {
     this.setSearchingValue(this.search);
      console.log(this.search);
      if (this.$router.currentRoute.path !== "/search") {
        this.$router.push({ name: "SearchPage" });
      }
    },
    ...mapMutations([
      "setSearchingValue"
    ])
  },
};
</script>

<style lang="sass">
.SearchBar
    display: flex
    align-items: center
.v-input.search
    transition: max-width 0.3s ease-in-out
    animation-direction: reverse
    .v-input__slot
        cursor: pointer
        &:before, &:after
            border-color: transparent
    &.closed
        max-width: 45px
</style>
