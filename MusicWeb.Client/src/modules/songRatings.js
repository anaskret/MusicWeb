import songRatingServices from "@/services/songRatingServices";

export default function useSongRatings() {
  const addSongRating = function (data) {
    if (data) {
      return songRatingServices.addSongRating(data);
    }
  };
  return {
    addSongRating,
  };
}
