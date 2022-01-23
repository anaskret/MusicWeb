import userObservedArtistServices from "@/services/userObservedArtistServices";
import UserObservedArtist from "@/models/UserObservedArtist.js";
import Artist from "@/models/Artist.js";

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

  const getUserObservedArtists = function (userId, pageNum, pageSize) {
    if (userId && pageNum > -1 && pageSize) {
      return userObservedArtistServices
        .getUserObservedArtists(userId, pageNum, pageSize)
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

  const deleteUserObservedArtist = function (id) {
    if (id) {
      return userObservedArtistServices.deleteUserObservedArtist(id);
    }
  };
  return {
    addUserObservedArtist,
    getUserObservedArtist,
    deleteUserObservedArtist,
    getUserObservedArtists,
  };
}
