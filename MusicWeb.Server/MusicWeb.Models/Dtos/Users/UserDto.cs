using MusicWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Users
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public UserType Type { get; set; }
        public int? ArtistId { get; set; }

        /*public virtual ICollection<AlbumReviewDto> AlbumReviews { get; set; }
        public virtual ICollection<SongReview> SongReviews { get; set; }
        public virtual ICollection<ArtistComment> ArtistComments { get; set; }
        public virtual ICollection<UserObservedArtist> UserObservedArtists { get; set; }*/
        public virtual ICollection<UserFavoriteDto> UserFavoriteAlbums { get; set; }
        public virtual ICollection<UserFavoriteDto> UserFavoriteArtists { get; set; }
        public virtual ICollection<UserFavoriteDto> UserFavoriteSongs { get; set; }
       /* public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Chat> FriendChats { get; set; }
        public virtual ICollection<Message> Messages { get; set; }*/
        public virtual ICollection<UserFriendDto> UserFriends { get; set; }
    }
}
