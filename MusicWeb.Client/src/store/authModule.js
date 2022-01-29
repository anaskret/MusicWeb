import useAccounts from "@/modules/accounts";
import axios from "axios";
import Vue from "vue";

const { loginAccount, logoutAccount, registerAccount } = useAccounts();
const token = localStorage.getItem("user-token");
const userId = localStorage.getItem("user-id");
const userName = localStorage.getItem("user-name");
const initialState = token
  ? { status: { loggedIn: true }, token, userId, userName }
  : { status: { loggedIn: false }, token: null, userId: null, userName };

export const auth = {
  namespaced: true,
  state: initialState,
  actions: {
    login({ commit }, user) {
      return loginAccount(user).then(
        (response) => {
          localStorage.setItem("user-token", response.data.token);
          localStorage.setItem("user-id", response.data.userId);
          localStorage.setItem("user-name", response.data.userName);
          axios.defaults.headers.common["Authorization"] =
            "Bearer " + localStorage.getItem("user-token");
          commit("loginSuccess", response.data);
          return Promise.resolve(response);
        },
        (error) => {
          commit("loginFailure");
          return Promise.reject(error);
        }
      );
    },
    logout({ commit }) {
      commit("logout");
      localStorage.clear();
      return logoutAccount();
    },
    register({ commit }, user) {
      return registerAccount(user).then(
        () => {
          commit("registerSuccess");
          return Promise.resolve();
        },
        (error) => {
          commit("registerFailure");
          return Promise.reject(error);
        }
      );
    },
  },
  mutations: {
    loginSuccess(state, data) {
      state.status.loggedIn = true;
      state.token = data.token;
      state.userId = data.userId;
      state.userName = data.userName;
      this.commit("setCurrentUser");
      Vue.prototype.$friendsHub.subscribeUserGroup(state.userName);
      this.commit("setSetLastOpenChatId", data.lastOpenedChatId);
    },
    loginFailure(state) {
      state.status.loggedIn = false;
      state.token = null;
      state.userId = null;
    },
    logout(state) {
      this.commit("toggleChatVisability", false);
      state.status.loggedIn = false;
      state.token = null;
    },
    registerSuccess(state) {
      state.status.loggedIn = false;
    },
    registerFailure(state) {
      state.status.loggedIn = false;
    },
  },
};
