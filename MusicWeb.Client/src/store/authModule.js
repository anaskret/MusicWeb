import useAccounts from "@/modules/accounts";
import axios from "axios";

const { loginAccount } = useAccounts();
const token = localStorage.getItem("user-token");
const initialState = token
    ? { status: { loggedIn: true }, token }
    : { status: { loggedIn: false }, token: null };

export const auth = {
    namespaced: true,
    state: initialState,
    actions: {
        login({ commit }, user) {
            return loginAccount(user).then(
                (response) => {
                    localStorage.setItem("user-token", response.data.token);
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
        // logout({ commit }) {
        //     AuthService.logout();
        //     commit("logout");
        // },
        // register({ commit }, user) {
        //     return AuthService.register(user).then(
        //         (response) => {
        //             commit("registerSuccess");
        //             return Promise.resolve(response.data);
        //         },
        //         (error) => {
        //             commit("registerFailure");
        //             return Promise.reject(error);
        //         }
        //     );
        // },
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
        // logout(state) {
        //     state.status.loggedIn = false;
        //     state.user = null;
        // },
        // registerSuccess(state) {
        //     state.status.loggedIn = false;
        // },
        // registerFailure(state) {
        //     state.status.loggedIn = false;
        // },
    },
};
