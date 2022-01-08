import artistRatingServices from "@/services/artistRatingServices";
import ArtistRating from "@/models/ArtistRating.js";
export default function useArtistRatings() {
  const addArtistRating = function (data) {
    if (data) {
      return artistRatingServices.addArtistRating(data);
    }
  };
  const getUserArtistRating = function (id, userId) {
    if (id && userId) {
      return artistRatingServices
        .getUserArtistRating(id, userId)
        .then((response) => {
          return new ArtistRating(response.data);
        });
    }
  };

  const updateUserArtistRating = function (data) {
    if (data) {
      return artistRatingServices.updateUserArtistRating(data);
    }
  };
  return {
    addArtistRating,
    getUserArtistRating,
    updateUserArtistRating,
  };
}
