import userFavoriteAlbumServices from "@/services/userFavoriteAlbumServices";
import UserFavoriteAlbum from "@/models/UserFavoriteAlbum.js";
import Album from "@/models/Album.js";
export default function useUserFavoriteAlbums() {
  const addUserFavoriteAlbum = function (data) {
    if (data) {
      return userFavoriteAlbumServices.addUserFavoriteAlbum(data);
    }
  };
  const getUserFavoriteAlbum = function (userId, albumId) {
    if (userId && albumId) {
      return userFavoriteAlbumServices
        .getUserFavoriteAlbum(userId, albumId)
        .then((response) => {
          return new UserFavoriteAlbum(response.data);
        });
    }
  };

  const getUserFavoriteAlbums = function (userId, pageNum, pageSize) {
    if (userId && pageNum > -1 && pageSize) {
      return userFavoriteAlbumServices
        .getUserFavoriteAlbums(userId, pageNum, pageSize)
        .then((response) => {
          let res = response.data;
          let albums = [];
          res.forEach((album) => {
            albums.push(new Album(album));
          });
          return albums;
        });
    }
  };

  const deleteUserFavoriteAlbum = function (id) {
    if (id) {
      return userFavoriteAlbumServices.deleteUserFavoriteAlbum(id);
    }
  };
  return {
    addUserFavoriteAlbum,
    getUserFavoriteAlbum,
    deleteUserFavoriteAlbum,
    getUserFavoriteAlbums,
  };
}
