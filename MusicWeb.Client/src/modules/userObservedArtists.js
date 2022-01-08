import userObservedArtistServices from "@/services/userObservedArtistServices";
import UserObservedArtist from "@/models/UserObservedArtist.js";
export default function useUserObservedArtists() {
  const addUserObservedArtist = function (data) {
    if (data) {
      return userObservedArtistServices.addUserObservedArtist(data);
    }
  };
  const getUserObservedArtist = function (userId, artistId) {
    if (userId && artistId) {
      return userObservedArtistServices
        .getUserObservedArtist(userId, artistId)
        .then((response) => {
          return new UserObservedArtist(response.data);
        });
    }
  };

  const deleteUserObservedArtist = function (id) {
    if (id) {
      return userObservedArtistServices.deleteUserObservedArtist(id);
    }
  };
  return {
    addUserObservedArtist,
    getUserObservedArtist,
    deleteUserObservedArtist,
  };
}
