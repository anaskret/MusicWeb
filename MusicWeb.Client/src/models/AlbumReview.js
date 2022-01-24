export default class AlbumReview {
  id = "";
  title = "";
  content = "";
  postDate = "";
  albumId = "";
  userId = "";
  name = "";
  artist = "";
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
      this.name = $data.name;
      this.artist = $data.artist;
      this.userName = $data.userName;
      this.artist = $data.artist;
      this.rating = $data.rating;
    }
  }
}
