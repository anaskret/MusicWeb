import albumServices from "@/services/albumServices";
import Album from "@/models/Album.js";
import Song from "@/models/Song.js";

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
  const getAlbumSongs = function (albumId, pageNum, pageSize) {
    if (albumId && pageNum > -1 && pageSize) {
      return albumServices
        .getAlbumSongs(albumId, pageNum, pageSize)
        .then((response) => {
          let res = response.data;
          let songs = [];
          res.forEach((song) => {
            songs.push(new Song(song));
          });
          return songs;
        });
    }
  };
  return {
    getAll,
    getAlbumFullData,
    getAlbumRatingAverage,
    getPagedAlbums,
    getAlbumSongs,
  };
}
