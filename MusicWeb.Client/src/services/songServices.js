import ApiService from "@/services/apiServices";
export default {
  getAll() {
    return ApiService.authRequest(`/songs`, ApiService.get);
  },
  getSongFullData(id) {
    return ApiService.authRequest(`/songsdata/${id}`, ApiService.get);
  },
};
