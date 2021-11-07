import artistServices from "@/services/artistServices";
import Artist from "@/models/Artist";

export default function useArtists() {
  const getArtistById = function (id) {
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
    createDateEnd,
    searchString
  ) {
    if (pageNum > -1 && pageSize && createDateStart && createDateEnd) {
      return artistServices
        .getPaged(pageNum, pageSize, sortType, createDateStart, createDateEnd, searchString)
        .then((response) => {
          let res = response.data;
          let artists = [];
          res.forEach((artist) => {
            artists.push(new Artist(artist));
          });
          return artists;
        });
    }
  };
  return {
    getArtistById,
    getPaged,
  };
}
