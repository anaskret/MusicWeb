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
    setArtist(state, artist) {
      state.artist = artist;
    },
  },
  getters: {
    album(state) {
      return state.album;
    },
    song(state) {
      return state.song;
    },
    artist(state) {
      return state.artist;
    },
  },
});
