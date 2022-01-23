import albumServices from "@/services/albumServices";
import Album from "@/models/Album.js";

export default function useAlbums() {
  const getAll = () => {
    return albumServices.getAll().then((response) => {
      return response.data;
    });
  };
  const getAlbumFullData = function (id) {
    if (id) {
      return albumServices.getAlbumFullData(id).then((response) => {
        return new Album(response.data);
      });
    }
  };
  const getAlbumRatingAverage = function (id) {
    if (id) {
      return albumServices.getAlbumRatingAverage(id).then((response) => {
        return new Album(response.data);
      });
    }
  };
  const getPagedAlbums = function (
    page_num,
    page_size,
    sort_type,
    create_date_start,
    create_date_end,
    search_string
  ) {
    if (page_num > -1 && page_size && create_date_start && create_date_end) {
      return albumServices
        .getPaged(
          page_num,
          page_size,
          sort_type,
          create_date_start,
          create_date_end,
          search_string
        )
        .then((response) => {
          let res = response.data;
          let albums = [];
          res.forEach((album) => {
            albums.push(new Album(album));
          });
          return albums;
        });
    }
  };
  const getPagedAlbumsRanking = function (
    sort_type,
    page_num,
    page_size
  ) {
    if (page_num > -1 && page_size) {
      return albumServices
        .getPagedAlbumsRanking(
            sort_type,
            page_num,
            page_size
        )
        .then((response) => {
          let res = response.data;
          let albums = [];
          res.forEach((album) => {
            albums.push(new Album(album));
          });
          return albums;
        });
    }
  };
  return {
    getAll,
    getAlbumFullData,
    getAlbumRatingAverage,
    getPagedAlbums,
    getPagedAlbumsRanking
  };
}
