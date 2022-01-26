import ApiService from "@/services/apiServices";
export default {
  getAllGenres() {
    return ApiService.authRequest(`/genres`, ApiService.get);
  },
};
