export default class SongRating {
  rating = "";
  userId = "";
  user = {};
  songId = "";
  song = {};
  id = "";
  constructor($data) {
    if ($data) {
      this.rating = $data.rating;
      this.userId = $data.userId;
      this.user = $data.user ? $data.user : null;
      this.songId = $data.songId;
      this.song = $data.song ? $data.song : null;
      this.id = $data.id;
    }
  }
}
