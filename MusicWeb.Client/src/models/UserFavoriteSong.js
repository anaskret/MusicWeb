export default class UserFavoriteSong {
  id = null;
  userId = null;
  songId = null;
  song = {};
  user = {};
  songId = null;
  constructor($data) {
    if ($data) {
      this.id = $data.id;
      this.userId = $data.userId;
      this.songId = $data.songId;
      this.song = $data.song ? $data.song : {};
      this.user = $data.user ? $data.user : {};
    }
  }
}
