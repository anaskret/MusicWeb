using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Models.Artists
{
    public class ArtistFullInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public string Bio { get; set; }
        public bool IsIndividual { get; set; }
        public bool IsBand { get; set; }

        public int? BandId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public List<AlbumDto> Albums { get; set; }
        public List<ArtistCommentDto> ArtistComments { get; set; }
        public List<ArtistGenreDto> ArtistGenres{ get; set; }
        public List<BandMemberDto> Members{ get; set; }
    }
}
