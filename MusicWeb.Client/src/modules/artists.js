import artistServices from "@/services/artistServices";
import Artist from "@/models/Artist";

export default function useArtists() {
  const getById = function (id) {
    if (id) {
      return artistServices.getById(id).then((response) => {
        return new Artist(response.data);
      });
    }
  };
  const getPaged = function (
    pageNum,
    pageSize,
    sortType,
    createDateStart,
    createDateEnd
  ) {
    if (pageNum > -1 && pageSize && createDateStart && createDateEnd) {
      return artistServices
        .getPaged(pageNum, pageSize, sortType, createDateStart, createDateEnd)
        .then((response) => {
          // return response.map(artist => new Artist(artist.data));
          return response.data; //TODO return Artist model array
        });
    }
  };
  return {
    getById,
    getPaged,
  };
}
