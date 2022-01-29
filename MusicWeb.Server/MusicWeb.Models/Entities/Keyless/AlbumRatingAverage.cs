using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Keyless
{
    public class AlbumRatingAverage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImagePath { get; set; }
        public int ArtistId { get; set; }
        public int AlbumGenreId { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public int RatingsCount { get; set; }
        public int FavoriteCount { get; set; }
        public int ReviewsCount { get; set; }
        public string ArtistName { get; set; }
    }
}
