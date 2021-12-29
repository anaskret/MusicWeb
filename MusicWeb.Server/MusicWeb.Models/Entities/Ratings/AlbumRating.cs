using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Ratings
{
    public class AlbumRating : BaseRating
    {
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
