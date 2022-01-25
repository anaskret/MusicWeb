import genreServices from "@/services/genreServices";

export default function useGenres() {
  const getAllGenres = () => {
    return genreServices.getAllGenres().then((response) => {
      return response.data;
    });
  };
  return {
    getAllGenres,
  };
}
