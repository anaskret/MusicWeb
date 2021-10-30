export default class Album {
  name = "";
  releaseDate = "";
  artistId = "";
  albumGenereId = "";
  songs = [];

  constructor($data) {
    if ($data) {
      this.name = $data.name;
      this.releaseDate = $data.releaseDate;
      this.artistId = $data.artistId;
      this.albumGenereId = $data.albumGenereId;
      this.songs = $data.songs ? $data.songs : [];
    }
  }
}
