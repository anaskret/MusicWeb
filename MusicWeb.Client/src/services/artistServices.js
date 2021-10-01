import ApiService from "@/services/apiServices";
import { authHeader } from "../helpers/authHeader";
export default {
    getAll() {
        return ApiService.authRequest(`/artists`, ApiService.get, {
            Headers: authHeader(),
        });
    },
    getById(id) {
        return ApiService.authRequest(`/artistdata/${id}`, ApiService.get);
    },
};
