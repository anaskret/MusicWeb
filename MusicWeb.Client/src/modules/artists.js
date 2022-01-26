import artistServices from "@/services/artistServices";
import Artist from "@/models/Artist";
import Album from "@/models/Album";
import Song from "@/models/Song";

export default function useArtists() {
  const getArtistById = function (id) {
    if (id) {
      return artistServices.getById(id).then((response) => {
        return new Artist(response.data);
      });
    }
  };
  const getPagedArtists = function (
    page_num,
    page_size,
    sort_type,
    create_date_start,
    create_date_end,
    search_string
  ) {
    if (page_num > -1 && page_size && create_date_start && create_date_end) {
      return artistServices
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
          let artists = [];
          res.forEach((artist) => {
            artists.push(new Artist(artist));
          });
          return artists;
        });
    }
  };
  const getArtistRatingAverage = function (id) {
    if (id) {
      return artistServices.getArtistRatingAverage(id).then((response) => {
        return new Artist(response.data);
      });
    }
  };

  const getDiscography = function (artistId, pageNum, pageSize) {
    if (artistId && pageNum > -1 && pageSize) {
      return artistServices
        .getDiscography(artistId, pageNum, pageSize)
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
  const getSongs = function (artistId, pageNum, pageSize) {
    if (artistId && pageNum > -1 && pageSize) {
      return artistServices
        .getSongs(artistId, pageNum, pageSize)
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

  const getPagedArtistsRanking = function (sort_type, page_num, page_size) {
    if (page_num > -1 && page_size) {
      return artistServices
        .getPagedArtistsRanking(sort_type, page_num, page_size)
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
    getPagedArtists,
    getArtistRatingAverage,
    getDiscography,
    getSongs,
    getPagedArtistsRanking,
  };
}
