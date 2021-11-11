import commentServices from "@/services/commentServices";
import Comment from "@/models/Comment";
import moment from "moment";

export default function useComments() {
  const getCommentById = function (id) {
    if (id) {
      return commentServices.getById(id).then((response) => {
        let res = response.data;
        let comments = [];
        res.forEach((comment) => {
          comment.postDate = moment.utc(comment.postDate).format("LLL");
          comments.push(new Comment(comment));
        });
        return comments;
      });
    }
  };
  const postNewComment = function (data) {
    if(data){
      return commentServices.postNewComment(data);
    }
  }
  return {
    getCommentById,
    postNewComment
  };
}
