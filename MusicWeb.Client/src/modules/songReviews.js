import songReviewServices from "@/services/songReviewServices";
import SongReview from "@/models/SongReview";

export default function useSongReviews() {
  const getAll = () => {
    return songReviewServices.getAll().then((response) => {
      return response.data;
    });
  };
  const addSongReview = function (data) {
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
  const getPaged = function (
    page_num,
    page_size,
    sort_type,
    create_date_start,
    create_date_end
  ) {
    if (page_num > -1 && page_size && create_date_start && create_date_end) {
      return songReviewServices
        .getPaged(
          page_num,
          page_size,
          sort_type,
          create_date_start,
          create_date_end
        )
        .then((response) => {
          let res = response.data;
          let songReviews = [];
          res.forEach((songReview) => {
            songReviews.push(new SongReview(songReview));
          });
          return songReviews;
        });
    }
  };
  const getSongReviews = function (songId, pageNum, pageSize) {
    if (songId && pageNum > -1 && pageSize) {
      return songReviewServices
        .getSongReviews(songId, pageNum, pageSize)
        .then((response) => {
          let res = response.data;
          let songReviews = [];
          res.forEach((songReview) => {
            songReviews.push(new SongReview(songReview));
          });
          return songReviews;
        });
    }
  };
  return {
    getAll,
    addSongReview,
    getSongReviewFullData,
    getPaged,
    getSongReviews,
  };
}
