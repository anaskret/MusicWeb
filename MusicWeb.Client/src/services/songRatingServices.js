import ApiService from "@/services/apiServices";
export default {
  addSongRating(data) {
    return ApiService.authRequest(`/songratings`, ApiService.post, data);
  },
  getSongUserRating(id, userId) {
    return ApiService.authRequest(
      `/songratings/${id}/user/${userId}`,
      ApiService.get,
      id,
      userId
    );
  },
  updateSongUserRating(data) {
    return ApiService.authRequest(`/songratings`, ApiService.put, data);
  },
};
