export default class account {
  id = null;
  username = "";
  password = "";
  firstname = "";
  lastname = "";
  email = "";
  birthdate = "";
  imagePath = "";
  userFavoriteAlbums = [];
  userFavoriteArtists = [];
  userFavoriteSongs = [];
  userFriends = [];
  constructor($data) {
    if ($data) {
      this.id = $data.id;
      this.username = $data.userName;
      this.password = $data.password;
      this.firstname = $data.firstName;
      this.lastname = $data.lastName;
      this.email = $data.email;
      this.birthdate = $data.birthDate;
      this.imagePath = $data.imagePath;
      this.userFavoriteAlbums = $data.userFavoriteAlbums;
      this.userFavoriteArtists = $data.userFavoriteArtists;
      this.userFavoriteSongs = $data.userFavoriteSongs;
      this.userFriends = $data.userFriends;
    }
  }
}
