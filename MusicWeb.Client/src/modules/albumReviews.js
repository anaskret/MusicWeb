import albumReviewServices from "@/services/albumReviewServices";
import AlbumReview from "@/models/AlbumReview";

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
  const getAlbumReviewFullData = function (id) {
    if (id) {
      return albumReviewServices.getAlbumReviewFullData(id).then((response) => {
        return new AlbumReview(response.data);
      });
    }
  };
  return {
    getAll,
    addReview,
    getAlbumReviewFullData,
  };
}
