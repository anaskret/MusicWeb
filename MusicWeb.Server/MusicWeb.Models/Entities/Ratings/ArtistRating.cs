using MusicWeb.Models.Entities.Base;
using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Ratings
{
    public class ArtistRating : BaseRating
    {
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
