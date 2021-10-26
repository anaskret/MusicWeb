using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities
{
    public class ArtistsOnTheAlbum : BaseEntity
    {
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }
        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
