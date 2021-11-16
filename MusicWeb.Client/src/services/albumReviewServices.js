import ApiService from "@/services/apiServices";
export default {
  getAll() {
    return ApiService.authRequest(`/albumreviews`, ApiService.get);
  },
  addReview(data) {
    return ApiService.authRequest(`/albumreviews`, ApiService.post, data);
  },
};
