using MusicWeb.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities
{
    public class SongGuestArtist : BaseEntity
    {
        public int SongId { get; set; }
        public int ArtistId { get; set; }

        public virtual Song Song{ get; set; }
        public virtual Artist Artist{ get; set; }
    }
}
