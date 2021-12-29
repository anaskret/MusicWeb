import ApiService from "@/services/apiServices";
export default {
  getAll() {
    return ApiService.authRequest(`/albumreviews`, ApiService.get);
  },
  addAlbumReview(data) {
    return ApiService.authRequest(`/albumreviews`, ApiService.post, data);
  },
  getAlbumReviewFullData(id) {
    return ApiService.authRequest(`/albumreviewsdata/${id}`, ApiService.get);
  },
};
