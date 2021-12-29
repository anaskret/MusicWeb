export default class UserFavoriteAlbum {
  id = null;
  userId = null;
  albumId = null;
  album = {};
  user = {};
  albumId = null;
  constructor($data) {
    if ($data) {
      this.id = $data.id;
      this.userId = $data.userId;
      this.albumId = $data.albumId;
      this.album = $data.album ? $data.album : {};
      this.user = $data.user ? $data.user : {};
    }
  }
}
