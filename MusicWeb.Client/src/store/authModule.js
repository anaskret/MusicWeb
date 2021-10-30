import useAccounts from "@/modules/accounts";
import axios from "axios";

const { loginAccount, logoutAccount, registerAccount } = useAccounts();
const token = localStorage.getItem("user-token");
const userId = localStorage.getItem("user-id");
const initialState = token
  ? { status: { loggedIn: true }, token, userId }
  : { status: { loggedIn: false }, token: null, userId: null };

export const auth = {
  namespaced: true,
  state: initialState,
  actions: {
    login({ commit }, user) {
      return loginAccount(user).then(
        (response) => {
          localStorage.setItem("user-token", response.data.token);
          localStorage.setItem("user-id", response.data.userId);
          axios.defaults.headers.common["Authorization"] =
            "Bearer " + localStorage.getItem("user-token");
          commit("loginSuccess", response.data.token);
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
    loginSuccess(state, token) {
      state.status.loggedIn = true;
      state.token = token;
    },
    loginFailure(state) {
      state.status.loggedIn = false;
      state.token = null;
    },
    logout(state) {
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
