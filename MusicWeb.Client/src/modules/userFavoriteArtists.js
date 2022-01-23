import userFavoriteArtistServices from "@/services/userFavoriteArtistServices";
import UserFavoriteArtist from "@/models/UserFavoriteArtist.js";
import Artist from "@/models/Artist.js";
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

  const getUserFavoriteArtists = function (userId, pageNum, pageSize) {
    if (userId && pageNum > -1 && pageSize) {
      return userFavoriteArtistServices
        .getUserFavoriteArtists(userId, pageNum, pageSize)
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

  const deleteUserFavoriteArtist = function (id) {
    if (id) {
      return userFavoriteArtistServices.deleteUserFavoriteArtist(id);
    }
  };
  return {
    addUserFavoriteArtist,
    getUserFavoriteArtist,
    deleteUserFavoriteArtist,
    getUserFavoriteArtists,
  };
}
