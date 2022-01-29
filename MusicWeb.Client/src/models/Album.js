export default class Album {
  id = null;
  imagePath = "";
  name = "";
  releaseDate = "";
  artistId = "";
  albumGenreId = "";
  description = "";
  duration = "";
  isConfirmed = "";
  artist = {};
  albumGenre = {};
  albumReviews = [];
  songs = [];
  rating = "";
  ratingsCount = "";
  favoriteCount = null;
  reviewsCount = null;
  artistName = "";

  constructor($data) {
    if ($data) {
      this.id = $data.id;
      this.imagePath = $data.imagePath;
      this.name = $data.name;
      this.releaseDate = $data.releaseDate;
      this.artistId = $data.artistId;
      this.albumGenreId = $data.albumGenreId;
      this.duration = $data.duration;
      this.description = $data.description;
      this.isConfirmed = $data.isConfirmed;
      this.songs = $data.songs ? $data.songs : [];
      this.albumReviews = $data.albumReviews ? $data.albumReviews : [];
      this.artist = $data.artist ? $data.artist : {};
      this.albumGenre = $data.albumGenre ? $data.albumGenre : {};
      this.rating = $data.rating ? $data.rating : 0;
      this.ratingsCount = $data.ratingsCount ? $data.ratingsCount : 0;
      this.favoriteCount = $data.favoriteCount ? $data.favoriteCount : 0;
      this.reviewsCount = $data.reviewsCount ? $data.reviewsCount : 0;
      this.artistName = $data.artistName;
    }
  }
}
