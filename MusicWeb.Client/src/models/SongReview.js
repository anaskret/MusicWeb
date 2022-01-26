export default class SongReview {
  id = null;
  title = "";
  content = "";
  postDate = "";
  songId = "";
  userId = "";
  name = "";
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
      this.name = $data.name;
      this.album = $data.album;
      this.artist = $data.artist;
      this.userName = $data.userName;
      this.albumName = $data.albumName;
      this.artistName = $data.artistName;
      this.rating = $data.id;
    }
  }
}
