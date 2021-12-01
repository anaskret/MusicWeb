using MusicWeb.Models.Dtos.Albums.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Albums
{
    public class AlbumReviewDto : CreateAlbumReviewDto
    {
        public int Id { get; set; }

    }
}
