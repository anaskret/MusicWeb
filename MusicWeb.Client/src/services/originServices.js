import ApiService from "@/services/apiServices";
export default {
    getCountryById(id) {
        return ApiService.authRequest(
            `/origins/countries/${id}`,
            ApiService.get
        );
    },
    getStateById(id) {
        return ApiService.authRequest(`/origins/states/${id}`, ApiService.get);
    },
    getCityById(id) {
        return ApiService.authRequest(`/origins/cities/${id}`, ApiService.get);
    },
};
