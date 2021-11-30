export default class AlbumReview {
  title = "";
  content = "";
  postDate = "";
  albumId = "";
  userId = "";
  albumId = "";
  album = {};
  userName = "";
  artist = "";
  constructor($data) {
    if ($data) {
      this.title = $data.title;
      this.content = $data.content;
      this.postDate = $data.postDate;
      this.albumId = $data.albumId;
      this.userId = $data.userId;
      this.album = $data.album ? $data.album : {};
      this.userName = $data.userName;
      this.artist = $data.artist;
    }
  }
}
