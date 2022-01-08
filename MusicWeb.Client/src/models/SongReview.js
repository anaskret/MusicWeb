export default class SongReview {
  id = null;
  title = "";
  content = "";
  postDate = "";
  songId = "";
  userId = "";
  song = {};
  userName = "";
  albumName = "";
  artistName = "";
  rating = null;
  constructor($data) {
    if ($data) {
      this.id = $data.id;
      this.title = $data.title;
      this.content = $data.content;
      this.postDate = $data.postDate;
      this.songId = $data.songId;
      this.userId = $data.userId;
      this.song = $data.song ? $data.song : {};
      this.userName = $data.userName;
      this.albumName = $data.albumName;
      this.artistName = $data.artistName;
      this.rating = $data.id;
    }
  }
}
