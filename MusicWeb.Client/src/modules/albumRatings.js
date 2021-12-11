import albumRatingServices from "@/services/albumRatingServices";
import AlbumRating from "@/models/AlbumRating.js";
export default function useAlbumRatings() {
  const addAlbumRating = function (data) {
    if (data) {
      return albumRatingServices.addAlbumRating(data);
    }
  };
  const getUserRating = function (id, userId) {
    if (id && userId) {
      return albumRatingServices.getUserRating(id, userId).then((response) => {
        return new AlbumRating(response.data);
      });
    }
  };
  return {
    addAlbumRating,
    getUserRating,
  };
}
