import ApiService from "@/services/apiServices";
export default {
  addArtistRating(data) {
    return ApiService.authRequest(`/artistratings`, ApiService.post, data);
  },
  getUserArtistRating(id, userId) {
    return ApiService.authRequest(
      `/artistratings/${id}/user/${userId}`,
      ApiService.get,
      id,
      userId
    );
  },
  updateUserArtistRating(data) {
    return ApiService.authRequest(`/artistratings`, ApiService.put, data);
  },
};
