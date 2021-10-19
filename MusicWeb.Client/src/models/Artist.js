export default class Artist {
  name = "";
  establishmentDate = "";
  bio = "";
  isIndividual = false;
  isBand = false;
  bandId = 0;
  country = "";
  state = "";
  city = "";
  albums = [];
  members = [];

  constructor($data) {
    if ($data) {
      this.name = $data.name;
      this.establishmentDate = $data.establishmentDate;
      this.bio = $data.bio;
      this.isIndividual = $data.isIndividual;
      this.isBand = $data.isBand;
      this.bandId = $data.bandId;
      this.country = $data.country;
      this.state = $data.state;
      this.city = $data.city;
      this.albums = $data.albums;
      this.members = $data.members.map((member) => member.name);
    }
  }
}
