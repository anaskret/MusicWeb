using MusicWeb.Models.Dtos.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Albums
{
    public class AdminAlbumCreateDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageBytes{ get; set; }
        public int ArtistId { get; set; }
        public int AlbumGenreId { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
        public bool IsConfirmed { get; set; }

        public List<AdminSongCreateDto> Songs { get; set; }
    }
}
