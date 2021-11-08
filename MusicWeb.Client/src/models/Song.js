export default class Song {
  name = "";
  releaseDate = "";
  length = "";
  positionOnAlbum = "";
  albumId = "";
  composerId = "";
  album = {};
  composer = {};
  songReviews = [];

  constructor($data) {
    if ($data) {
      this.name = $data.name;
      this.releaseDate = $data.releaseDate;
      this.length = $data.length;
      this.positionOnAlbum = $data.positionOnAlbum;
      this.albumId = $data.albumId;
      this.composerId = $data.composerId;
      this.album = $data.album ? $data.album : {};
      this.composer = $data.composer ? $data.composer : {};
      this.songReviews = $data.songReviews ? $data.songReviews : [];
    }
  }
}
