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
  getDiscography(artistId, pageNum, pageSize) {
    return ApiService.authRequest(
      `/artistdiscography/${artistId}/${pageNum}/${pageSize}`,
      ApiService.get,
      artistId,
      pageNum,
      pageSize
    );
  },
  getSongs(artistId, pageNum, pageSize) {
    return ApiService.authRequest(
      `/artistsongs/${artistId}/${pageNum}/${pageSize}`,
      ApiService.get,
      artistId,
      pageNum,
      pageSize
    );
  },
};
