using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Dtos.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Songs
{
    public class SongFullDataDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Length { get; set; }
        public string Text { get; set; }
        public int AlbumId { get; set; }
        public int ComposerId { get; set; }
        public int PositionOnAlbum { get; set; }
        public AlbumDto Album { get; set; }
        public ArtistDto Composer { get; set; }

        public SongFullDataDto()
        {
            Album = new AlbumDto();
            Composer = new ArtistDto();
        }
    }
}
