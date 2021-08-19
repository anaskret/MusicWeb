using MusicWeb.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<ArtistGenre> ArtistGenres { get; set; }
    }
}
