import ApiService from "@/services/apiServices";
import router from "@/router";
export default {
  login(data) {
    return ApiService.authRequest(`/login`, ApiService.post, data);
  },
  logout() {
    localStorage.removeItem("user-token");
    localStorage.removeItem("user-id");
    router.push({ name: "Login" });
  },
  register(data) {
    return ApiService.authRequest(`/register`, ApiService.post, data);
  },
  getById(id) {
    return ApiService.authRequest(`/users/${id}`, ApiService.get);
  },
  updateNames(data) {
    return ApiService.authRequest(`/users/names`, ApiService.put, data);
  },
  updatePassword(data) {
    return ApiService.authRequest(`/users/password`, ApiService.put, data);
  },
  updateEmail(data) {
    return ApiService.authRequest(`/users/email`, ApiService.put, data);
  },
  updateImage(data) {
    return ApiService.authRequest(`/users/image`, ApiService.put, data);
  },
  getPaged(user_id, page_initialize_date, page_num, page_size) {
    return ApiService.authRequest(
      `/userposts/${user_id}/${page_initialize_date}/${page_num}/${page_size}`,
      ApiService.get
    );
  },
  addPost(data) {
    return ApiService.authRequest(`/posts`, ApiService.post, data);
  },
  watchArtist(data) {
    return ApiService.authRequest(
      `/userobservedartists`,
      ApiService.post,
      data
    );
  },
  getAccounts() {
    return ApiService.authRequest(`/users`, ApiService.get);
  },
  getFriends(user_id) {
    return ApiService.authRequest(
      `/userfriendsbyuserId/${user_id}`,
      ApiService.get
    );
  },
  addFriendRequest(data) {
    return ApiService.authRequest(`/userfriends`, ApiService.post, data);
  },
  acceptFriendRequest(data) {
    return ApiService.authRequest(
      `/userfriends/acceptrequest`,
      ApiService.post,
      data
    );
  },
  discardFriendRequest(user_id, friend_id) {
    return ApiService.authRequest(
      `/userfriends/${user_id}/${friend_id}`,
      ApiService.delete
    );
  },
};
