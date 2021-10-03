import accountServices from "@/services/accountServices";

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
  return {
    loginAccount,
    logoutAccount,
    registerAccount,
  };
}
