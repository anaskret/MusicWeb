import ApiService from "@/services/apiServices";
export default {
    login(data) {
        return ApiService.authRequest(`/login`, ApiService.post, data);
    },
    logout() {
        localStorage.removeItem("user-token");
        location.reload(true);
    },
    register(data) {
        return ApiService.authRequest(`/register`, ApiService.post, data);
    },
};
