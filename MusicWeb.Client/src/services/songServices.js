import ApiService from "@/services/apiServices";
export default {
  getAll() {
    return ApiService.authRequest(`/songs`, ApiService.get);
  },
  getSongFullData(id) {
    return ApiService.authRequest(`/songsdata/${id}`, ApiService.get);
  },
  getTopArtistSongs(artistId) {
    return ApiService.authRequest(`/topsongs/${artistId}`, ApiService.get);
  },
  getSongsByArtistId(artistId) {
    return ApiService.authRequest(`/artistsongs/${artistId}`, ApiService.get);
  },
  getSongRatingAverage(id) {
    return ApiService.authRequest(`songaveragerating/${id}`, ApiService.get);
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
        `/songs/${page_num}/${page_size}/${sort_type}/${create_date_start}/${create_date_end}`,
        ApiService.get
      );
    } else {
      return ApiService.authRequest(
        `/songs/${page_num}/${page_size}/${sort_type}/${create_date_start}/${create_date_end}/${search_string}`,
        ApiService.get
      );
    }
  },
  addSong(data) {
    return ApiService.authRequest(`/songs`, ApiService.post, data);
  },
  updateSong(data) {
    return ApiService.authRequest(`/songs`, ApiService.put, data);
  },
  getPagedSongsRanking(sort_type, page_num, page_size) {
    return ApiService.authRequest(
      `/songranking/${sort_type}/${page_num}/${page_size}`,
      ApiService.get
    );
  },
};
