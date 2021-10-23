using MusicWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Artists.Models
{
    public class ArtistModel
    {
        public string Name { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public string Bio { get; set; }
        public string ImagePath { get; set; }
        public bool IsIndividual { get; set; }
        public bool IsBand { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        public ArtistType ArtistType { get; set; }

        public int? BandId { get; set; }
        public int CityId { get; set; }
    }
}
