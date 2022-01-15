import Vue from "vue";
import Vuex from "vuex";

import { auth } from "./authModule";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: { auth },
  state: {
    tokenExpired: false,
    searchingValue: "",
    serverUrl: "http://localhost:5000",
    album: {},
    rank_artists: [],
    artist: {},
    song: {},
  },
  mutations: {
    setAlbum(state, album) {
      state.album = album;
    },
    setSong(state, song) {
      state.song = song;
    },
    setRanking(state, rank_artists) {
      state.rank_artists = rank_artists;
    },
    setArtist(state, artist) {
      state.artist = artist;
    },
    setSearchingValue(state, search) {
      state.searchingValue = search;
    },
  },
  getters: {
    album(state) {
      return state.album;
    },
    song(state) {
      return state.song;
    },
    rankArtists(state) {
      return state.rank_artists;
    },
    artist(state) {
      return state.artist;
    },
    searchingValue(state) {
      return state.searchingValue;
    },
  },
});
