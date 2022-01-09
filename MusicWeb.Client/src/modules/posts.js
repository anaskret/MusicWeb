import postServices from "@/services/postServices";

export default function useAccounts() {

  const likePost = function (data) {
    if (data) {
      return postServices.likePost(data);
    }
  };

  return {
    likePost,
  };
}
