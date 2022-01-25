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
  getAlbumSongs(albumId, pageNum, pageSize) {
    return ApiService.authRequest(
      `/albumsongs/${albumId}/${pageNum}/${pageSize}`,
      ApiService.get,
      albumId,
      pageNum,
      pageSize
    );
  },
  addAlbum(data) {
    return ApiService.authRequest(`/albums`, ApiService.post, data);
  },
  updateAlbum(data) {
    return ApiService.authRequest(`/albums`, ApiService.put, data);
  },
  getAllForArtist(artistId) {
    return ApiService.authRequest(
      `/albums/artist/${artistId}`,
      ApiService.get,
      artistId
    );
  },
};
