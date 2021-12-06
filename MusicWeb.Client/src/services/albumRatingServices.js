import ApiService from "@/services/apiServices";
export default {
  addAlbumRating(data) {
    return ApiService.authRequest(`/albumratings`, ApiService.post, data);
  },
};
