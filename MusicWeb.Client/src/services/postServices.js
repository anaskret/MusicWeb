import ApiService from "@/services/apiServices";

export default {
  likePost(data) {
    return ApiService.authRequest(`/postlikes/${data.userId}/${data.postId}`, ApiService.post, data);
  },
  getCommentsByPostId(id) {
    return ApiService.authRequest(`/post/postcomments/${id}`, ApiService.get);
  },
  addNewComment(data) {
    return ApiService.authRequest(`/postcomments`, ApiService.post, data);
  },
};
