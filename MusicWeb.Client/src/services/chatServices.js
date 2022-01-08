import ApiService from "@/services/apiServices";
export default {
  createNewChat(data){
    return ApiService.authRequest(`/chats`, ApiService.post, data);
  },
  getChatByUserId(user_id) {
    return ApiService.authRequest(`/chats/user/${user_id}`, ApiService.get);
  },
  getPagedMessages(chat_id, page_num, page_size) {
    return ApiService.authRequest(
      `/messages/${chat_id}/${page_num}/${page_size}`,
      ApiService.get
    );
  },
  addNewMessage(data) {
    return ApiService.authRequest(`/messages`, ApiService.post, data);
  },
};
