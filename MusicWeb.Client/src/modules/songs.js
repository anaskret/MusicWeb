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
  const getTopArtistSongs = function (id) {
    if (id) {
      return songServices.getTopArtistSongs(id).then((response) => {
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
  const getPagedSongs = function (
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
  const getPagedSongsRanking = function (
    sort_type,
    page_num,
    page_size
  ) {
    if (page_num > -1 && page_size) {
      return songServices
        .getPagedSongsRanking(
            sort_type,
            page_num,
            page_size
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
    getSongRatingAverage,
    getPagedSongs,
    getTopArtistSongs,
    getPagedSongsRanking
  };
}
