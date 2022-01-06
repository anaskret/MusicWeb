export default class ArtistRating {
  rating = "";
  userId = "";
  user = {};
  artistId = "";
  artist = {};
  id = "";
  constructor($data) {
    if ($data) {
      this.rating = $data.rating;
      this.userId = $data.userId;
      this.user = $data.user ? $data.user : null;
      this.artistId = $data.artistId;
      this.artist = $data.artist ? $data.artist : null;
      this.id = $data.id;
    }
  }
}
