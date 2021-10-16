using MusicWeb.Models.Dtos.Artists.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Models.Artists
{
    public class ArtistCommentDto : CreateArtistCommentDto
    {
        public int Id { get; set; }
    }
}
