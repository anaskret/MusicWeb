using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities
{
    public class Song:BaseEntity
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Length { get; set; }
        public string ImagePath { get; set; }
        public int positionOnAlbum { get; set; }

        public int AlbumId { get; set; }
        public int ComposerId { get; set; }

        public virtual Album Album { get; set; }
        public virtual Artist Composer { get; set; }
        public virtual ICollection<SongGuestArtist> SongGuestArtists { get; set; }
        public virtual ICollection<UserFavoriteSong> UserFavoriteSongs { get; set; }
        public virtual ICollection<SongReview> SongReviews{ get; set; }
    }
}
