using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Albums.Base
{
    public abstract class BaseAlbumDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ArtistId { get; set; }
        public int AlbumGenreId { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
        public Boolean IsConfirmed { get; set; }
    }
}
