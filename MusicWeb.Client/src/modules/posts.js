import postServices from "@/services/postServices";

export default function useAccounts() {

  const likePost = function (data) {
    if (data) {
      return postServices.likePost(data);
    }
  };

  const getCommentsByPostId = (post_id) => {
    if (post_id) {
      return postServices.getCommentsByPostId(post_id).then((response) => {
        return response.data;
      });
    }
  };

  const addNewComment = function (data) {
    if (data) {
      return postServices.addNewComment(data);
    }
  };
  
  return {
    likePost,
    getCommentsByPostId,
    addNewComment
  };
}
