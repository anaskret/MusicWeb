import ApiService from "@/services/apiServices";

export default {
  likePost(data) {
    return ApiService.authRequest(`/postlikes/${data.userId}/${data.postId}`, ApiService.post, data);
  },
};
