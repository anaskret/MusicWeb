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

    config(configs, queryParams) {
        const config = {
            ...configs,
            params: {
                ...queryParams,
            },
        };
        return config;
    },

    get(resource, queryParams, configs) {
        return axios.get(resource, ApiService.config(configs, queryParams));
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

    authRequest(route, method, paramOrData, configs) {
        return new Promise((resolve) => {
            method(route, paramOrData, configs)
                .then((response) => {
                    resolve(response);
                })
                .catch((e) => {
                    console.log(e);
                    throw e;
                });
        });
    },
};

export default ApiService;
