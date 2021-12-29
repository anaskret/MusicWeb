import userFavoriteAlbumServices from "@/services/userFavoriteAlbumServices";
import UserFavoriteAlbum from "@/models/UserFavoriteAlbum.js";
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

  const deleteUserFavoriteAlbum = function (id) {
    if (id) {
      return userFavoriteAlbumServices.deleteUserFavoriteAlbum(id);
    }
  };
  return {
    addUserFavoriteAlbum,
    getUserFavoriteAlbum,
    deleteUserFavoriteAlbum,
  };
}
