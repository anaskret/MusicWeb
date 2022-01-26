import ApiService from "@/services/apiServices";
export default {
  getAll() {
    return ApiService.authRequest(`/songreviews`, ApiService.get);
  },
  addReview(data) {
    return ApiService.authRequest(`/songreviews`, ApiService.post, data);
  },
  getSongReviewFullData(id) {
    return ApiService.authRequest(`/songreviewsdata/${id}`, ApiService.get);
  },
  getPaged(page_num, page_size, sort_type, create_date_start, create_date_end) {
    return ApiService.authRequest(
      `/songreviews/${page_num}/${page_size}/${sort_type}/${create_date_start}/${create_date_end}`,
      ApiService.get
    );
  },
  getSongReviews(songId, pageNum, pageSize) {
    return ApiService.authRequest(
      `/reviewsforsong/${songId}/${pageNum}/${pageSize}`,
      ApiService.get,
      songId,
      pageNum,
      pageSize
    );
  },
};
