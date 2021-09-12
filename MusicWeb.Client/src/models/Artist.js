export default class Artist {
  name = "";
  establishmentDate = "";
  bio = "";
  isIndividual = false;
  isBand = false;
  bandId = 0;
  countryId = 0;
  stateId = 0;
  cityId = 0;

  constructor($data) {
    if ($data) {
      this.name = $data.name;
      this.establishmentDate = $data.establishmentDate;
      this.bio = $data.bio;
      this.isIndividual = $data.isIndividual;
      this.isBand = $data.isBand;
      this.bandId = $data.bandId;
      this.countryId = $data.countryId;
      this.stateId = $data.stateId;
      this.cityId = $data.cityId;
    }
  }
}
