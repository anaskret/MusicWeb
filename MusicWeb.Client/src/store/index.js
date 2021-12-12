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
  },
  mutations: {
    setAlbum(state, album) {
      debugger;
      state.album = album;
    },
  },
  getters: {
    album(state) {
      debugger;
      return state.album;
    },
  },
});
