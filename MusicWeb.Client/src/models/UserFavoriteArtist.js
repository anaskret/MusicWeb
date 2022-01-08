export default class UserFavoriteArtist {
  id = null;
  userId = null;
  artistId = null;
  artist = {};
  user = {};
  artistId = null;
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
