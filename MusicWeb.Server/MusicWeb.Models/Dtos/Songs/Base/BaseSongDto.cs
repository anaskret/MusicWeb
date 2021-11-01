using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Songs.Base
{
    public abstract class BaseSongDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Length { get; set; }
        public int AlbumId { get; set; }
        public int ComposerId { get; set; }
        public int positionOnAlbum { get; set; }
    }
}
