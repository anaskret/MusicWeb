import ApiService from "@/services/apiServices";
export default {
  getAll() {
    return ApiService.authRequest(`/albums`, ApiService.get);
  },
};
