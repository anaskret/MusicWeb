import axios from "axios";
import store from "@/store";

axios.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (
      error.message == "Network Error" &&
      (error.response == null || error.response == "")
    ) {
      store.state.connectionError = true;
      store.dispatch("auth/logout");
    } else if (error.response.status === 401) {
      store.state.tokenExpired = true;
      store.dispatch("auth/logout");
    } else {
      return new Promise((resolve, reject) => {
        reject(error);
      });
    }
  }
);
export default axios;
