import accountServices from "@/services/accountServices";
import Account from "@/models/Account";
import Post from "@/models/Post";

export default function useAccounts() {
  const loginAccount = async (data) => {
    return await accountServices.login(data);
  };

  const logoutAccount = async () => {
    return await accountServices.logout();
  };

  const registerAccount = async (data) => {
    return await accountServices.register(data);
  };

  const getAccountById = async (id) => {
    if (id) {
      return accountServices.getById(id).then((response) => {
        return new Account(response.data);
      });
    }
  };

  const updateAccountNames = async (data) => {
    return await accountServices.updateNames(data);
  };

  const updateAccountPassword = async (data) => {
    return await accountServices.updatePassword(data);
  };

  const updateAccountEmail = async (data) => {
    return await accountServices.updateEmail(data);
  };

  const updateAccountImage = async (data) => {
    return await accountServices.updateImage(data);
  };

  const getPaged = function (
    user_id,
    page_num,
    page_size
  ) {
    if (page_num > -1 && page_size) {
      return accountServices
        .getPaged(
            user_id,
            page_num,
            page_size
        )
        .then((response) => {
          let res = response.data;
          let posts = [];
          res.forEach((post) => {
            posts.push(new Post(post));
          });
          return posts;
        });
    }
  };
  return {
    loginAccount,
    logoutAccount,
    registerAccount,
    getAccountById,
    updateAccountNames,
    updateAccountPassword,
    updateAccountEmail,
    updateAccountImage,
<<<<<<< HEAD
    getPaged
=======
>>>>>>> features/api/artistpagetopsongs
  };
}
