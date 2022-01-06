import ApiService from "@/services/apiServices";
export default {
  addUserFavoriteArtist(data) {
    return ApiService.authRequest(
      `/userfavoriteartists`,
      ApiService.post,
      data
    );
  },
  getUserFavoriteArtist(userId, artistId) {
    return ApiService.authRequest(
      `/userfavoriteartists/${userId}/${artistId}`,
      ApiService.get,
      userId,
      artistId
    );
  },
  deleteUserFavoriteArtist(id) {
    return ApiService.authRequest(
      `/userfavoriteartists/${id}`,
      ApiService.delete,
      id
    );
  },
};
