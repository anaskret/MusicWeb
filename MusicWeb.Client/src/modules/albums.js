import albumServices from "@/services/albumServices";
import Album from "@/models/Album.js";

export default function useAlbums() {
  const getAll = () => {
    return albumServices.getAll().then((response) => {
      return response.data;
    });
  };
  const getAlbumFullData = function (id) {
    if (id) {
      return albumServices.getAlbumFullData(id).then((response) => {
        return new Album(response.data);
      });
    }
  };
  return {
    getAll,
    getAlbumFullData,
  };
}
