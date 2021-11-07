export default class Comment {
  id = null;
  content = "";
  postDate = "";
  artistId = null;
  userId = null;
  userName = '';
  constructor($data) {
    if ($data) {
      this.id = $data.id ? $data.id : null;
      this.content = $data.content;
      this.postDate = $data.postDate;
      this.artistId = $data.artistId;
      this.userId = $data.userId;
      this.userName = $data.userName;
    }
  }
}
