import userFavoriteArtistServices from "@/services/userFavoriteArtistServices";
import UserFavoriteArtist from "@/models/UserFavoriteArtist.js";
export default function useUserFavoriteArtists() {
  const addUserFavoriteArtist = function (data) {
    if (data) {
      return userFavoriteArtistServices.addUserFavoriteArtist(data);
    }
  };
  const getUserFavoriteArtist = function (userId, artistId) {
    if (userId && artistId) {
      return userFavoriteArtistServices
        .getUserFavoriteArtist(userId, artistId)
        .then((response) => {
          return new UserFavoriteArtist(response.data);
        });
    }
  };

  const deleteUserFavoriteArtist = function (id) {
    if (id) {
      return userFavoriteArtistServices.deleteUserFavoriteArtist(id);
    }
  };
  return {
    addUserFavoriteArtist,
    getUserFavoriteArtist,
    deleteUserFavoriteArtist,
  };
}
