import songReviewServices from "@/services/songReviewServices";
import SongReview from "@/models/SongReview";

export default function useSongReviews() {
  const getAll = () => {
    return songReviewServices.getAll().then((response) => {
      return response.data;
    });
  };
  const addReview = function (data) {
    if (data) {
      return songReviewServices.addReview(data);
    }
  };
  const getSongReviewFullData = function (id) {
    if (id) {
      return songReviewServices.getSongReviewFullData(id).then((response) => {
        return new SongReview(response.data);
      });
    }
  };
  return {
    getAll,
    addReview,
    getSongReviewFullData,
  };
}
