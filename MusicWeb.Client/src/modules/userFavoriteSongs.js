import userFavoriteSongServices from "@/services/userFavoriteSongServices";
import UserFavoriteSong from "@/models/UserFavoriteSong.js";
import Song from "@/models/Song.js";
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
  const getUserFavoriteSongs = function (userId, pageNum, pageSize) {
    if (userId && pageNum > -1 && pageSize) {
      return userFavoriteSongServices
        .getUserFavoriteSongs(userId, pageNum, pageSize)
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

  const deleteUserFavoriteSong = function (id) {
    if (id) {
      return userFavoriteSongServices.deleteUserFavoriteSong(id);
    }
  };
  return {
    addUserFavoriteSong,
    getUserFavoriteSong,
    deleteUserFavoriteSong,
    getUserFavoriteSongs,
  };
}
