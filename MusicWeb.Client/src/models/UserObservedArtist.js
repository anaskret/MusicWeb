export default class UserObservedArtist {
  id = null;
  userId = null;
  artistId = null;
  favoriteDate = null;
  artist = {};
  user = {};
  constructor($data) {
    if ($data) {
      this.id = $data.id;
      this.userId = $data.userId;
      this.artistId = $data.artistId;
      this.favoriteDate = $data.favoriteDate;
      this.artist = $data.artist ? $data.artist : {};
      this.user = $data.user ? $data.user : {};
    }
  }
}
