import albumReviewServices from "@/services/albumReviewServices";
import AlbumReview from "@/models/AlbumReview";

export default function useComments() {
  const getAll = () => {
    return albumReviewServices.getAll().then((response) => {
      return response.data;
    });
  };
  const addReview = function (data) {
    if (data) {
      return albumReviewServices.addReview(data);
    }
  };
  return {
    getAll,
    addReview,
  };
}
