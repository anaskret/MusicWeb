using MusicWeb.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities
{
    public class Artist : BaseEntity
    {
        public string Name { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public string Bio { get; set; }
        public bool IsIndividual { get; set; }

        public int? BandId{ get; set; }
        public int OriginId{ get; set; }
        public virtual Band Band { get; set; }
        public virtual Origin Origin { get; set; }

        public virtual ICollection<Album> Albums{ get; set; }
        public virtual ICollection<Song> Songs{ get; set; }
        public virtual ICollection<SongGuestArtist> SongGuestArtists{ get; set; }
        public virtual ICollection<ArtistComment> ArtistComments{ get; set; }
        public virtual ICollection<ArtistGenre> ArtistGenres{ get; set; }
        public virtual ICollection<UserFavoriteArtist> UserFavoriteArtists{ get; set; }
        public virtual ICollection<UserObservedArtist> UserObservedArtists{ get; set; }
        public virtual ICollection<ArtistsOnTheAlbum> ArtistsOnTheAlbums{ get; set; }

    }
}
