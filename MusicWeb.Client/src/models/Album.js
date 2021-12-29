export default class Album {
  id = null;
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

  constructor($data) {
    if ($data) {
      this.id = $data.id;
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
      this.rating = $data.rating;
      this.ratingsCount = $data.ratingsCount;
      this.favoriteCount = $data.favoriteCount;
    }
  }
}
