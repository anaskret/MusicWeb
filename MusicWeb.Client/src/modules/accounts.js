import accountServices from "@/services/accountServices";
import Account from "@/models/Account";

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
  return {
    loginAccount,
    logoutAccount,
    registerAccount,
    getAccountById,
    updateAccountNames
  };
}
