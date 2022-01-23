import ApiService from "@/services/apiServices";
export default {
  addUserObservedArtist(data) {
    return ApiService.authRequest(
      `/userobservedartists`,
      ApiService.post,
      data
    );
  },
  getUserObservedArtist(userId, artistId) {
    return ApiService.authRequest(
      `/userobservedartists/${userId}/${artistId}`,
      ApiService.get,
      userId,
      artistId
    );
  },
  getUserObservedArtists(userId, pageNum, pageSize) {
    return ApiService.authRequest(
      `/userobservedartistsdata/${userId}/${pageNum}/${pageSize}`,
      ApiService.get,
      userId,
      pageNum,
      pageSize
    );
  },
  deleteUserObservedArtist(id) {
    return ApiService.authRequest(
      `/userobservedartists/${id}`,
      ApiService.delete,
      id
    );
  },
};
