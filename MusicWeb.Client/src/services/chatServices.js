import ApiService from "@/services/apiServices";
export default {
  getChatByUserId(user_id) {
    return ApiService.authRequest(`/chats/user/${user_id}`, ApiService.get);
  },
  getPagedMessages(chat_id, page_num, page_size) {
    return ApiService.authRequest(`/messages/${chat_id}/${page_num}/${page_size}`, ApiService.get);
  },
};
