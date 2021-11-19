import albumReviewServices from "@/services/albumReviewServices";

export default function useAlbumReviews() {
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
