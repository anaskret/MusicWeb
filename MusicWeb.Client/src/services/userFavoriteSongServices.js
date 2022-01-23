import ApiService from "@/services/apiServices";
export default {
  addUserFavoriteSong(data) {
    return ApiService.authRequest(`/userfavoritesongs`, ApiService.post, data);
  },
  getUserFavoriteSong(userId, songId) {
    return ApiService.authRequest(
      `/userfavoritesongs/${userId}/${songId}`,
      ApiService.get,
      userId,
      songId
    );
  },
  getUserFavoriteSongs(userId, pageNum, pageSize) {
    return ApiService.authRequest(
      `/userfavoritesongssdata/${userId}/${pageNum}/${pageSize}`,
      ApiService.get,
      userId,
      pageNum,
      pageSize
    );
  },
  deleteUserFavoriteSong(id) {
    return ApiService.authRequest(
      `/userfavoritesongs/${id}`,
      ApiService.delete,
      id
    );
  },
};
