import ApiService from "@/services/apiServices";
export default {
  getAll() {
    return ApiService.authRequest(`/albumreviews`, ApiService.get);
  },
  addAlbumReview(data) {
    return ApiService.authRequest(`/albumreviews`, ApiService.post, data);
  },
  getAlbumReviewFullData(id) {
    return ApiService.authRequest(`/albumreviewsdata/${id}`, ApiService.get);
  },
  getPaged(
    page_num,
    page_size,
    sort_type,
    create_date_start,
    create_date_end,
    search_string
  ) {
    // if (search_string == "" || search_string == null) {
    //   return ApiService.authRequest(
    //     `/albumreviews/${page_num}/${page_size}/${sort_type}/${create_date_start}/${create_date_end}`,
    //     ApiService.get
    //   );
    // } else {
    return ApiService.authRequest(
      `/albumreviews/${page_num}/${page_size}/${sort_type}/${create_date_start}/${create_date_end}/${search_string}`,
      ApiService.get
    );
    // }
  },
};
