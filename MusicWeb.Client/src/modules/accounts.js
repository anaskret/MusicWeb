import accountServices from "@/services/accountServices";

export default function useAccounts() {
    const loginAccount = async (data) => {
        try {
            return await accountServices.login(data);
        } catch (e) {
            console.log(e);
            throw e;
        }
    };

    const logoutAccount = async () => {
        try {
            return await accountServices.logout();
        } catch (e) {
            console.log(e);
        }
    };
    return {
        loginAccount,
        logoutAccount,
    };
}
