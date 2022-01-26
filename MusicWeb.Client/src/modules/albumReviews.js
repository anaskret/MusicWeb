import albumReviewServices from "@/services/albumReviewServices";
import AlbumReview from "@/models/AlbumReview";

export default function useAlbumReviews() {
  const getAll = () => {
    return albumReviewServices.getAll().then((response) => {
      return response.data;
    });
  };
  const addAlbumReview = function (data) {
    if (data) {
      return albumReviewServices.addAlbumReview(data);
    }
  };
  const getAlbumReviewFullData = function (id) {
    if (id) {
      return albumReviewServices.getAlbumReviewFullData(id).then((response) => {
        return new AlbumReview(response.data);
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
      return albumReviewServices
        .getPaged(
          page_num,
          page_size,
          sort_type,
          create_date_start,
          create_date_end
        )
        .then((response) => {
          let res = response.data;
          let albumReviews = [];
          res.forEach((albumReview) => {
            albumReviews.push(new AlbumReview(albumReview));
          });
          return albumReviews;
        });
    }
  };

  const getAlbumReviews = function (albumId, pageNum, pageSize) {
    if (albumId && pageNum > -1 && pageSize) {
      return albumReviewServices
        .getAlbumReviews(albumId, pageNum, pageSize)
        .then((response) => {
          let res = response.data;
          let albumReviews = [];
          res.forEach((albumReview) => {
            albumReviews.push(new AlbumReview(albumReview));
          });
          return albumReviews;
        });
    }
  };
  return {
    getAll,
    addAlbumReview,
    getAlbumReviewFullData,
    getPaged,
    getAlbumReviews,
  };
}
