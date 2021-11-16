import axios from "axios";

const ApiService = {
  apiHost: "",
  init(apiHost, baseApiUrl) {
    console.log("axios initialize");
    this.apiHost = apiHost;
    axios.defaults.baseURL = baseApiUrl;
    axios.defaults.withCredentials = false;
    axios.defaults.headers.common["Accept"] = "application/json";
    axios.defaults.headers.common["ContentType"] = "application/json";
    console.log(axios.defaults);
  },

  config(configs, query_params) {
    const config = {
      ...configs,
      params: {
        ...query_params,
      },
    };
    return config;
  },

  get(resource, query_params, configs) {
    return axios.get(resource, ApiService.config(configs, query_params));
  },
  post(resource, data, configs) {
    return axios.post(resource, data, ApiService.config(configs));
  },
  put(resource, data) {
    return axios.put(resource, data, ApiService.config());
  },
  delete(resource) {
    return axios.delete(resource, ApiService.config());
  },

  authRequest(route, method, param_or_data, configs) {
    return new Promise((resolve, reject) => {
      method(route, param_or_data, configs)
        .then((response) => {
          resolve(response);
        })
        .catch((e) => {
          reject(e);
        });
    });
  },
};

export default ApiService;
