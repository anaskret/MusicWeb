import albumServices from "@/services/albumServices";

export default function useArtists() {
  const getAll = () => {
    return albumServices.getAll().then((response) => {
      return response.data.name;
    });
  };
  return {
    getAll,
  };
}
