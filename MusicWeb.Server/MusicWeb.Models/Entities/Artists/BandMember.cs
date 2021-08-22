using MusicWeb.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Artists
{
    public class BandMember : BaseEntity
    {
        public int BandId { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Band { get; set; }
        public virtual Artist Member { get; set; }
    }
}
