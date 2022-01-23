import ApiService from "@/services/apiServices";
export default {
  addUserFavoriteAlbum(data) {
    return ApiService.authRequest(`/userfavoritealbums`, ApiService.post, data);
  },
  getUserFavoriteAlbum(userId, albumId) {
    return ApiService.authRequest(
      `/userfavoritealbums/${userId}/${albumId}`,
      ApiService.get,
      userId,
      albumId
    );
  },
  getUserFavoriteAlbums(userId, pageNum, pageSize) {
    return ApiService.authRequest(
      `/userfavoritealbumsdata/${userId}/${pageNum}/${pageSize}`,
      ApiService.get,
      userId,
      pageNum,
      pageSize
    );
  },
  deleteUserFavoriteAlbum(id) {
    return ApiService.authRequest(
      `/userfavoritealbums/${id}`,
      ApiService.delete,
      id
    );
  },
};
