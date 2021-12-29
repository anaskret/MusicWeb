import userFavoriteSongServices from "@/services/userFavoriteSongServices";
import UserFavoriteSong from "@/models/UserFavoriteSong.js";
export default function useUserFavoriteSongs() {
  const addUserFavoriteSong = function (data) {
    if (data) {
      return userFavoriteSongServices.addUserFavoriteSong(data);
    }
  };
  const getUserFavoriteSong = function (userId, songId) {
    if (userId && songId) {
      return userFavoriteSongServices
        .getUserFavoriteSong(userId, songId)
        .then((response) => {
          return new UserFavoriteSong(response.data);
        });
    }
  };

  const deleteUserFavoriteSong = function (id) {
    if (id) {
      return userFavoriteSongServices.deleteUserFavoriteSong(id);
    }
  };
  return {
    addUserFavoriteSong,
    getUserFavoriteSong,
    deleteUserFavoriteSong,
  };
}
