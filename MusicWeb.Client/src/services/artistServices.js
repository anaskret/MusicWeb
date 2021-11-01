import ApiService from "@/services/apiServices";
export default {
  getById(id) {
    return ApiService.authRequest(`/artistdata/${id}`, ApiService.get);
  },
  getPaged(pageNum, pageSize, sortType, createDateStart, createDateEnd) {
    return ApiService.authRequest(
      `/artists/${pageNum}/${pageSize}/${sortType}/${createDateStart}/${createDateEnd}`,
      ApiService.get
    );
  },
  getPagedWithSearchString(
    pageNum,
    pageSize,
    sortType,
    createDateStart,
    createDateEnd,
    searchString
  ) {
    return ApiService.authRequest(
      `/artists/${pageNum}/${pageSize}/${sortType}/${createDateStart}/${createDateEnd}/${searchString}`,
      ApiService.get
    );
  },
};
