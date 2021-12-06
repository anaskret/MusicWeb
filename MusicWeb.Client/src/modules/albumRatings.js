import albumRatingServices from "@/services/albumRatingServices";

export default function useAlbumRatings() {
  const addAlbumRating = function (data) {
    if (data) {
      return albumRatingServices.addAlbumRating(data);
    }
  };
  return {
    addAlbumRating,
  };
}
