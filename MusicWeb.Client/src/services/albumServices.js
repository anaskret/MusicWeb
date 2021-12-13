import ApiService from "@/services/apiServices";
export default {
  getAll() {
    return ApiService.authRequest(`/albums`, ApiService.get);
  },
  getAlbumFullData(id) {
    return ApiService.authRequest(`/albumsdata/${id}`, ApiService.get);
  },
  getAlbumRatingAverage(id) {
    return ApiService.authRequest(`albumaveragerating/${id}`, ApiService.get);
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
        `/albums/${page_num}/${page_size}/${sort_type}/${create_date_start}/${create_date_end}`,
        ApiService.get
      );
    } else {
      return ApiService.authRequest(
        `/albums/${page_num}/${page_size}/${sort_type}/${create_date_start}/${create_date_end}/${search_string}`,
        ApiService.get
      );
    }
  },
};
