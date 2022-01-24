import ApiService from "@/services/apiServices";
export default {
  getAll() {
    return ApiService.authRequest(`/genres`, ApiService.get);
  },
};
