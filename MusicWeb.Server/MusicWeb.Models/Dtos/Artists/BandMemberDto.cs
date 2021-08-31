using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Artists
{
    public class BandMemberDto
    {
        public int BandId { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }
    }
}
