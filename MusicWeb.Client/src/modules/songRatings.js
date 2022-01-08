import songRatingServices from "@/services/songRatingServices";
import SongRating from "@/models/SongRating.js";
export default function useSongRatings() {
  const addSongRating = function (data) {
    if (data) {
      return songRatingServices.addSongRating(data);
    }
  };
  const getSongUserRating = function (id, userId) {
    if (id && userId) {
      return songRatingServices
        .getSongUserRating(id, userId)
        .then((response) => {
          return new SongRating(response.data);
        });
    }
  };

  const updateSongUserRating = function (data) {
    if (data) {
      return songRatingServices.updateSongUserRating(data);
    }
  };
  return {
    addSongRating,
    getSongUserRating,
    updateSongUserRating,
  };
}
