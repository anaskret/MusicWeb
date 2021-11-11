import ApiService from "@/services/apiServices";
export default {
  getById(id) {
    return ApiService.authRequest(`/artistdata/${id}`, ApiService.get);
  },
  getPaged(page_num, page_size, sort_type, create_date_start, create_date_end) {
    return ApiService.authRequest(
      `/artists/${page_num}/${page_size}/${sort_type}/${create_date_start}/${create_date_end}`,
      ApiService.get
    );
  },
  getPagedWithSearchString(
    page_num,
    page_size,
    sort_type,
    create_date_start,
    create_date_end,
    search_string
  ) {
    return ApiService.authRequest(
      `/artists/${page_num}/${page_size}/${sort_type}/${create_date_start}/${create_date_end}/${search_string}`,
      ApiService.get
    );
  },
};
