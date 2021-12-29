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
  deleteUserFavoriteAlbum(id) {
    return ApiService.authRequest(
      `/userfavoritealbums/${id}`,
      ApiService.delete,
      id
    );
  },
};
