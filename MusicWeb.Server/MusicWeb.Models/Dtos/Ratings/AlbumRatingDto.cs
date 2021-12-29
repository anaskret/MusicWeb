using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Ratings
{
    public class AlbumRatingDto : CreateAlbumRatingDto
    {
        public int Id { get; set; }
    }
}
