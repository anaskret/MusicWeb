export default class UserObservedArtist {
  id = null;
  userId = null;
  artistId = null;
  observedDate = null;
  name = "";
  artist = {};
  user = {};
  constructor($data) {
    if ($data) {
      this.id = $data.id;
      this.userId = $data.userId;
      this.artistId = $data.artistId;
      this.name = $data.name;
      this.observedDate = $data.observedDate;
      this.artist = $data.artist ? $data.artist : {};
      this.user = $data.user ? $data.user : {};
    }
  }
}
