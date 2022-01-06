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
  return {
    getArtistById,
    getPaged,
    getArtistRatingAverage,
  };
}
