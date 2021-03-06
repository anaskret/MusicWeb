using Microsoft.AspNetCore.Identity;
using MusicWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }

        public virtual ICollection<AlbumReview> AlbumReviews{ get; set; }
        public virtual ICollection<SongReview> SongReviews{ get; set; }
        public virtual ICollection<ArtistComment> ArtistComments{ get; set; }
        public virtual ICollection<UserFavoriteAlbum> UserFavoriteAlbums{ get; set; }
        public virtual ICollection<UserFavoriteArtist> UserFavoriteArtists{ get; set; }
        public virtual ICollection<UserObservedArtist> UserObservedArtists{ get; set; }
        public virtual ICollection<UserFavoriteSong> UserFavoriteSongs{ get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Chat> FriendChats { get; set; }
        public virtual ICollection<Message> Messages{ get; set; }
        public virtual ICollection<UserFriend> UserFriends{ get; set; }
        public virtual ICollection<UserFriend> FriendUsers{ get; set; }
    }
}
