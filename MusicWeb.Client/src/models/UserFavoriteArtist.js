export default class UserFavoriteAlbum {
  id = null;
  userId = null;
  artistId = null;
  artist = {};
  user = {};
  constructor($data) {
    if ($data) {
      this.id = $data.id;
      this.userId = $data.userId;
      this.artistId = $data.artistId;
      this.artist = $data.artist ? $data.artist : {};
      this.user = $data.user ? $data.user : {};
    }
  }
}
