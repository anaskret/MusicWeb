using MusicWeb.Models.Dtos.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Albums.Create
{
    public class CreateAlbumDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int ArtistId { get; set; }
        public int AlbumGenreId { get; set; }
        public List<SongDto> Songs { get; set; }
        public List<AlbumReviewDto> Reviews { get; set; }
        public CreateAlbumDto()
        {
            Songs = new List<SongDto>();
            Reviews = new List<AlbumReviewDto>();
        }
    }
}
