import chatServices from "@/services/chatServices";

export default function useAccounts() {
  const getChatByUserId = async (user_id) => {
   return await chatServices.getChatByUserId(user_id);
  };

  const getPagedMessages = async (chat_id, page_num, page_size) => {
   if (page_num > -1 && page_size) {
      return chatServices
         .getPagedMessages(chat_id, page_num, page_size)
         .then((response) => {
         let res = response.data;
         // let posts = [];
         // res.forEach((post) => {
         //       posts.push(new Post(post));
         // });
         return res;
         });
      }
   };

  return {
    getChatByUserId,
    getPagedMessages
  };
}
