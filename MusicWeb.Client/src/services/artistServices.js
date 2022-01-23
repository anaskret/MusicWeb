import ApiService from "@/services/apiServices";
export default {
  getById(id) {
    return ApiService.authRequest(`/artistdata/${id}`, ApiService.get);
  },
  getArtistRatingAverage(id) {
    return ApiService.authRequest(`artistaveragerating/${id}`, ApiService.get);
  },
  getPaged(
    page_num,
    page_size,
    sort_type,
    create_date_start,
    create_date_end,
    search_string
  ) {
    if (search_string == "" || search_string == null) {
      return ApiService.authRequest(
        `/artists/${page_num}/${page_size}/${sort_type}/${create_date_start}/${create_date_end}`,
        ApiService.get
      );
    } else {
      return ApiService.authRequest(
        `/artists/${page_num}/${page_size}/${sort_type}/${create_date_start}/${create_date_end}/${search_string}`,
        ApiService.get
      );
    }
  },
  getPagedArtistsRanking(
    sort_type,
    page_num,
    page_size
  ) {
    return ApiService.authRequest(
    `/artistranking/${sort_type}/${page_num}/${page_size}`,
    ApiService.get
    );
  },
};
