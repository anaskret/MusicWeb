import ApiService from "@/services/apiServices";
export default {
  getById(id) {
    return ApiService.authRequest(`/artistcomments/${id}`, ApiService.get);
  },
  postNewComment(data){
    return ApiService.authRequest(`/artistcomments`, ApiService.post, data);
  }
};
