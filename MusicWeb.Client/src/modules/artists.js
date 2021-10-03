import artistServices from "@/services/artistServices";
import Artist from "@/models/Artist";

export default function useArtists() {
  const getAll = async () => {
    try {
      return await artistServices.getAll();
    } catch (e) {
      console.log(e);
    }
  };
  const getById = function (id) {
    if (id) {
      return artistServices.getById(id).then((response) => {
        return new Artist(response.data);
      });
    }
  };
  return {
    getAll,
    getById,
  };
}
