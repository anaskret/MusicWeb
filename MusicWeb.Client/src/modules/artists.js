import { ref } from "@vue/composition-api";
import artistServices from "@/services/artistServices";
import Artist from "@/models/Artist";

export default function useArtists() {
  const artist = ref(null);

  const getAll = async () => {
    try {
      return await artistServices.getAll();
    } catch (e) {
      console.log(e);
    }
  };
  const getById = function (id) {
    if (id) {
      artistServices.getById(id).then((response) => {
        artist.value = new Artist(response.data.data);
      });
    }
  };
  return {
    getAll,
    getById,
  };
}
