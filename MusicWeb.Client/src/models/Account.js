export default class account {
  id = null;
  username = "";
  password = "";
  firstname = "";
  lastname = "";
  email = "";
  imagePath = "";
  userType = null;
  artistId = null;
  userFavoriteAlbums = [];
  userFavoriteArtists = [];
  userFavoriteSongs = [];
  userFriends = [];
  albumReviews = [];
  songReviews = [];
  userObservedArtists = [];
  constructor($data) {
    if ($data) {
      this.id = $data.id;
      this.username = $data.userName;
      this.password = $data.password;
      this.firstname = $data.firstName;
      this.lastname = $data.lastName;
      this.email = $data.email;
      this.imagePath = $data.imagePath;
      this.userType = $data.type;
      this.artistId = $data.artistId;
      this.userFavoriteAlbums = $data.userFavoriteAlbums;
      this.userFavoriteArtists = $data.userFavoriteArtists;
      this.userFavoriteSongs = $data.userFavoriteSongs;
      this.userFriends = $data.userFriends;
      this.albumReviews = $data.albumReviews;
      this.songReviews = $data.songReviews;
      this.userObservedArtists = $data.userObservedArtists;
    }
  }
}
