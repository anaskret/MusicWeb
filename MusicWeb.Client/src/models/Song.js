export default class Song {
  id = null;
  name = "";
  releaseDate = "";
  duration = "";
  positionOnAlbum = "";
  description = "";
  albumId = "";
  composerId = "";
  album = {};
  composer = {};
  songReviews = [];
  rating = "";
  ratingsCount = "";

  constructor($data) {
    if ($data) {
      this.id = $data.id;
      this.name = $data.name;
      this.releaseDate = $data.releaseDate;
      this.duration = $data.length;
      this.positionOnAlbum = $data.positionOnAlbum;
      this.description = $data.text;
      this.albumId = $data.albumId;
      this.composerId = $data.composerId;
      this.album = $data.album ? $data.album : {};
      this.composer = $data.composer ? $data.composer : {};
      this.songReviews = $data.songReviews ? $data.songReviews : [];
      this.rating = $data.rating;
      this.ratingsCount = $data.ratingsCount;
    }
  }
}
