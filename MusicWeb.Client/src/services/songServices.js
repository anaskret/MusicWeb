import ApiService from "@/services/apiServices";
export default {
  getAll() {
    return ApiService.authRequest(`/songs`, ApiService.get);
  },
  getSongFullData(id) {
    return ApiService.authRequest(`/songsdata/${id}`, ApiService.get);
  },
  getSongsByArtistId(artistId) {
    return ApiService.authRequest(`/artistsongs/${artistId}`, ApiService.get);
  },
  getSongRatingAverage(id) {
    return ApiService.authRequest(`songaveragerating/${id}`, ApiService.get);
  },
};
