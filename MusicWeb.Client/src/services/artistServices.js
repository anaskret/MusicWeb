import ApiService from "@/services/apiServices";
export default {
  getAll() {
    return ApiService.authRequest(`/artistdata`, ApiService.get);
  },
  getById(id) {
    return ApiService.authRequest(`/artistdata/${id}`, ApiService.get);
  },
};
