import chatServices from "@/services/chatServices";
import Message from "@/models/Message";

export default function useAccounts() {
  const createNewChat = async (data) => {
  if (data) {
      return await chatServices.createNewChat(data);
    }
  };

  const getChatByUserId = async (user_id) => {
    return await chatServices.getChatByUserId(user_id);
  };

  const getPagedMessages = async (chat_id, page_num, page_size) => {
      debugger;
    if (page_num > -1 && page_size) {
      return chatServices
        .getPagedMessages(chat_id, page_num, page_size)
        .then((response) => {
          let res = response.data;
          res = res.map(message => new Message(message));
          return res;
        });
    }
  };

  const addNewMessage = async (data) => {
    if (data) {
        return await chatServices.addNewMessage(data);
    }
  };

  return {
    getChatByUserId,
    getPagedMessages,
    addNewMessage,
    createNewChat
  };
}
