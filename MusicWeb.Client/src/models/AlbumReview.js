export default class albumReview {
  title = "";
  content = "";
  postDate = "";
  albumId = "";
  userId = "";
  albumId = "";
  album = {};
  user = {};
  constructor($data) {
    if ($data) {
      this.title = $data.title;
      this.content = $data.content;
      this.postDate = $data.postDate;
      this.albumId = $data.albumId;
      this.userId = $data.userId;
      this.album = $data.album ? $data.album : {};
      this.user = $data.user ? $data.user : {};
    }
  }
}
