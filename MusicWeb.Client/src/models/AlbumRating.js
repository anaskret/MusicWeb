export default class AlbumRating {
  rating = "";
  userId = "";
  user = {};
  albumId = "";
  album = {};
  constructor($data) {
    if ($data) {
      this.rating = $data.rating;
      this.userId = $data.userId;
      this.user = $data.user ? $data.user : null;
      this.albumId = $data.albumId;
      this.album = $data.album ? $data.album : null;
    }
  }
}
