export default class Genre {
  id = null;
  name = "";
  constructor($data) {
    if ($data) {
      this.id = $data.id;
      this.name = $data.name;
    }
  }
}
