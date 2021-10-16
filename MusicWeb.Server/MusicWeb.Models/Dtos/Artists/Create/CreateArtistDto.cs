using MusicWeb.Models.Dtos.Artists.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Artists.Create
{
    public class CreateArtistDto : BaseArtistDto
    {
        public byte[] ImageBytes { get; set; }
    }
}
