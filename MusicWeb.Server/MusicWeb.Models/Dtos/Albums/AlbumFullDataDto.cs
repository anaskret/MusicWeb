using MusicWeb.Models.Dtos.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Albums
{
    public class AlbumFullDataDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ArtistId { get; set; }
        public int AlbumGenreId { get; set; }
        public List<SongDto> Songs { get; set; }
        public AlbumFullDataDto()
        {
            Songs = new List<SongDto>();
        }
    }
}
