import songServices from "@/services/songServices.js";
import Song from "@/models/Song.js";

export default function useSongs() {
  const getAll = () => {
    return songServices.getAll().then((response) => {
      return response.data;
    });
  };
  const getSongFullData = function (id) {
    if (id) {
      return songServices.getSongFullData(id).then((response) => {
        return new Song(response.data);
      });
    }
  };
  const getSongsByArtistId = function (artist_id) {
    if (artist_id) {
      return songServices.getSongsByArtistId(artist_id).then((response) => {
        let res = response.data;
        let songs = [];
        res.forEach((song) => {
          songs.push(new Song(song));
        });
        return songs;
      });
    }
  };
  const getSongRatingAverage = function (id) {
    if (id) {
      return songServices.getSongRatingAverage(id).then((response) => {
        return new Song(response.data);
      });
    }
  };
  const getPaged = function (
    page_num,
    page_size,
    sort_type,
    create_date_start,
    create_date_end,
    search_string
  ) {
    if (page_num > -1 && page_size && create_date_start && create_date_end) {
      return songServices
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
    getSongFullData,
    getSongsByArtistId,
    getSongRatingAverage,
    getPaged,
  };
}
