import ApiService from "@/services/apiServices";
export default {
  getAll() {
    return ApiService.authRequest(`/songreviews`, ApiService.get);
  },
  addReview(data) {
    return ApiService.authRequest(`/songreviews`, ApiService.post, data);
  },
  getSongReviewFullData(id) {
    return ApiService.authRequest(`/songreviewsdata/${id}`, ApiService.get);
  },
};
