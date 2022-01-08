using MusicWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Keyless
{
    public class ArtistRatingAverage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public string Bio { get; set; }
        public ArtistType Type { get; set; }
        public int? BandId { get; set; }
        public int CountryId { get; set; }
        public double Rating { get; set; }
        public int RatingsCount { get; set; }
        public int FavoriteCount { get; set; }
        public int ObservedCount { get; set; }
    }
}
