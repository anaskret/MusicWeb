export default class Artist {
  id = null;
  name = "";
  establishmentDate = "";
  description = "";
  isIndividual = false;
  isBand = false;
  bandId = 0;
  country = "";
  state = "";
  city = "";
  albums = [];
  members = [];
  genres = [];
  rating = "";
  ratingsCount = "";
  favoriteCount = null;

  constructor($data) {
    if ($data) {
      this.id = $data.id;
      this.name = $data.name;
      this.establishmentDate = $data.establishmentDate;
      this.description = $data.bio;
      this.isIndividual = $data.isIndividual ? $data.isIndividual : "";
      this.isBand = $data.isBand ? $data.isBand : "";
      this.bandId = $data.bandId;
      this.country = $data.country ? $data.country : "";
      this.state = $data.state ? $data.state : "";
      this.city = $data.city ? $data.city : "";
      this.albums = $data.albums ? $data.albums : [];
      this.members = $data.members
        ? $data.members.map((member) => member.name)
        : [];
      this.genres = $data.genres ? $data.genres.map((genre) => genre.name) : [];
      this.rating = $data.rating ? $data.rating : 0;
      this.ratingsCount = $data.ratingsCount ? $data.ratingsCount : 0;
      this.favoriteCount = $data.favoriteCount ? $data.favoriteCount : 0;
    }
  }
}
