import ApiService from "@/services/apiServices";
export default {
  addAlbumRating(data) {
    return ApiService.authRequest(`/albumratings`, ApiService.post, data);
  },
  getUserRating(id, userId) {
    return ApiService.authRequest(
      `/albumratings/${id}/user/${userId}`,
      ApiService.get,
      id,
      userId
    );
  },
  updateUserRating(data) {
    return ApiService.authRequest(`/albumratings`, ApiService.put, data);
  },
};
