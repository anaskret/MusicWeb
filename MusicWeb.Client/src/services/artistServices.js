import ApiService from "@/services/apiServices";
export default {
  getById(id) {
    return ApiService.authRequest(`/artistdata/${id}`, ApiService.get);
  },
  getPaged(pageNum, pageSize, sortType, createDateStart, createDateEnd, searchString) {
    if(searchString == '' || searchString == null){
        return ApiService.authRequest(
            `/artists/${pageNum}/${pageSize}/${sortType}/${createDateStart}/${createDateEnd}`,
            ApiService.get
            );
    } else {
        return ApiService.authRequest(
            `/artists/${pageNum}/${pageSize}/${sortType}/${createDateStart}/${createDateEnd}/${searchString}`,
            ApiService.get
            );
    }
  },
};
