using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Ratings
{
    public class SongRating : BaseRating
    {
        public int SongId { get; set; }
        public Song Song{ get; set; }
    }
}
