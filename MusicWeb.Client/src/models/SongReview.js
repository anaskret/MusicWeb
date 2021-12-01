export default class SongReview {
  title = "";
  content = "";
  postDate = "";
  songId = "";
  userId = "";
  song = {};
  userName = "";
  albumName = "";
  artistName = "";
  constructor($data) {
    if ($data) {
      this.title = $data.title;
      this.content = $data.content;
      this.postDate = $data.postDate;
      this.songId = $data.songId;
      this.userId = $data.userId;
      this.song = $data.song ? $data.song : {};
      this.userName = $data.userName;
      this.albumName = $data.albumName;
      this.artistName = $data.artistName;
    }
  }
}
