using MusicWeb.Models.Entities.Posts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Posts
{
    public class ArtistPost : BasePost
    {
        public int ArtistPosterId { get; set; }
        public int AlbumId { get; set; }

        public virtual UserObservedArtist PosterArtist { get; set; }
        public virtual Album Album { get; set; }
    }
}
