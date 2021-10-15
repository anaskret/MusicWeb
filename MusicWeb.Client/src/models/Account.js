export default class account {
  username = "";
  password = "";
  firstname = "";
  lastname = "";
  email = "";
  birthdate = "";
  constructor($data) {
    if ($data) {
      this.username = $data.username;
      this.password = $data.password;
      this.firstname = $data.firstname;
      this.lastname = $data.lastname;
      this.email = $data.email;
      this.birthdate = $data.birthdate;
    }
  }
}
