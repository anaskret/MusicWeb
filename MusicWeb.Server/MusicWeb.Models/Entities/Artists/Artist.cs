using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Base;
using MusicWeb.Models.Entities.Origins;
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
        public bool IsBand { get; set; }

        public int? BandId { get; set; }
        public int CountryId{ get; set; }
        public int StateId{ get; set; }
        public int CityId{ get; set; }
        public virtual BandMember BandMember { get; set; }
        public virtual Country Country{ get; set; }
        public virtual State State{ get; set; }
        public virtual City City{ get; set; }

        public virtual ICollection<Album> Albums{ get; set; }
        public virtual ICollection<Song> Songs{ get; set; }
        public virtual ICollection<SongGuestArtist> SongGuestArtists{ get; set; }
        public virtual ICollection<ArtistComment> ArtistComments{ get; set; }
        public virtual ICollection<ArtistGenre> ArtistGenres{ get; set; }
        public virtual ICollection<UserFavoriteArtist> UserFavoriteArtists{ get; set; }
        public virtual ICollection<UserObservedArtist> UserObservedArtists{ get; set; }
        public virtual ICollection<ArtistsOnTheAlbum> ArtistsOnTheAlbums{ get; set; }
        public virtual ICollection<BandMember> Band { get; set; }

    }
}
