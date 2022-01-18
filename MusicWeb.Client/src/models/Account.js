export default class account {
  username = "";
  password = "";
  firstname = "";
  lastname = "";
  email = "";
  birthdate = "";
  imagePath = "";
  userType = null;
  artistId = null;
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
      this.imagePath = $data.imagePath;
      this.userType = $data.type;
      this.artistId = $data.artistId;
      this.userFavoriteAlbums = $data.userFavoriteAlbums;
      this.userFavoriteArtists = $data.userFavoriteArtists;
      this.userFavoriteSongs = $data.userFavoriteSongs;
      this.userFriends = $data.userFriends;
    }
  }
}
