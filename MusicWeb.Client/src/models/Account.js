export default class account {
  username = "";
  password = "";
  firstname = "";
  lastname = "";
  email = "";
  birthdate = "";
  image = "";
  userFavoriteAlbums = [];
  userFavoriteArtists = [];
  userFavoriteSongs = [];
  userFriends = [];
  constructor($data) {
    if ($data) {
      this.username = $data.userName;
      this.password = $data.password;
      this.firstname = $data.firstName;
      this.lastname = $data.lastName;
      this.email = $data.email;
      this.birthdate = $data.birthDate;
      this.image = $data.image;
      this.userFavoriteAlbums = $data.userFavoriteAlbums;
      this.userFavoriteArtists = $data.userFavoriteArtists;
      this.userFavoriteSongs = $data.userFavoriteSongs;
      this.userFriends = $data.userFriends;
    }
  }
}
