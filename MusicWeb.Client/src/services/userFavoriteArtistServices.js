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
  getUserFavoriteArtists(userId, pageNum, pageSize) {
    return ApiService.authRequest(
      `/userfavoriteartistsdata/${userId}/${pageNum}/${pageSize}`,
      ApiService.get,
      userId,
      pageNum,
      pageSize
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
