using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Songs
{
    public class SongWithRatingDto : SongDto
    {
        public decimal Rating { get; set; }
    }
}
