import genreServices from "@/services/genreServices";

export default function useGenres() {
  const getAll = () => {
    return genreServices.getAll().then((response) => {
      return response.data;
    });
  };
  return {
    getAll,
  };
}
