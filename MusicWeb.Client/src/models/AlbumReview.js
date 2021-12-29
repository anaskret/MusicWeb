export default class AlbumReview {
  id = "";
  title = "";
  content = "";
  postDate = "";
  albumId = "";
  userId = "";
  album = {};
  userName = "";
  artist = "";
  rating = "";
  constructor($data) {
    if ($data) {
      this.id = $data.id;
      this.title = $data.title;
      this.content = $data.content;
      this.postDate = $data.postDate;
      this.albumId = $data.albumId;
      this.userId = $data.userId;
      this.album = $data.album ? $data.album : {};
      this.userName = $data.userName;
      this.artist = $data.artist;
      this.rating = $data.rating;
    }
  }
}
