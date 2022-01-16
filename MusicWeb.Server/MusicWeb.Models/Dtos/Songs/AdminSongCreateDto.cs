using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Songs
{
    public class AdminSongCreateDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Length { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageBytes { get; set; }
        public int PositionOnAlbum { get; set; }
        public string Text { get; set; }

        public int ComposerId { get; set; }

        public bool IsConfirmed { get; set; } = true;
        public int AlbumId { get; set; }
    }
}
