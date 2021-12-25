export default class Post {
  userName = "";
  artistId = null;
  artist = {};
  album = {};
  id = null;
  text = "";
  createDate = "";
  posterId = null;
  artistPosterId = "";
  albumId = "";

  constructor($data) {
    if ($data) {
      this.userName = $data.userName;
      this.artistId = $data.artistId;
      this.artist = $data.artist;
      this.album = $data.album;
      this.id = $data.id;
      this.text = $data.text;
      this.createDate = $data.createDate;
      this.posterId = $data.posterId;
      this.artistPosterId = $data.artistPosterId;
      this.albumId = $data.albumId;
    }
  }
}
