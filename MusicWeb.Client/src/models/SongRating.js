export default class SonglbumRating {
  rating = "";
  userId = "";
  user = {};
  songId = "";
  song = {};
  constructor($data) {
    if ($data) {
      this.rating = $data.rating;
      this.userId = $data.userId;
      this.user = $data.user ? $data.user : null;
      this.songId = $data.songId;
      this.song = $data.song ? $data.song : null;
    }
  }
}
