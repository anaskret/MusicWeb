using MusicWeb.Models.Dtos.Artists.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Artists
{
    public class ArtistDto : CreateArtistDto
    {
        public int Id { get; set; }
    }
}
