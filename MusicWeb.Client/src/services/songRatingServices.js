import ApiService from "@/services/apiServices";
export default {
  addSongRating(data) {
    return ApiService.authRequest(`/songratings`, ApiService.post, data);
  },
};
