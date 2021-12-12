using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Keyless
{
    public class SongRatingAverage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Length { get; set; }
        public string ImagePath { get; set; }
        public int PositionOnAlbum { get; set; }
        public string Text { get; set; }
        public int AlbumId { get; set; }
        public int ComposerId { get; set; }
        public double Rating { get; set; }
        public int RatingsCount { get; set; }

    }
}
