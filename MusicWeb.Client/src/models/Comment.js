export default class Comment {
  id = null;
  content = "";
  postDate = "";
  artistId = null;
  userId = null;
  username = '';
  constructor($data) {
    if ($data) {
      this.id = $data.id ? $data.id : null;
      this.content = $data.content;
      this.postDate = $data.postDate;
      this.artistId = $data.artistId;
      this.userId = $data.userId;
      this.username = $data.username ? $data.username : {};
    }
  }
}
