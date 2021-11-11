import songServices from "@/services/songServices.js";
import Song from "@/models/Song.js";

export default function useSongs() {
  const getAll = () => {
    return songServices.getAll().then((response) => {
      return response.data;
    });
  };
  const getSongFullData = function (id) {
    if (id) {
      return songServices.getSongFullData(id).then((response) => {
        return new Song(response.data);
      });
    }
  };
  return {
    getAll,
    getSongFullData,
  };
}
