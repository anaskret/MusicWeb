using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Artists.Create
{
    public class CreateArtistDto
    {
        public string Name { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public string Bio { get; set; }
        public bool IsIndividual { get; set; }
        public bool IsBand { get; set; }

        public int? BandId { get; set; }
        public int CityId { get; set; }
    }
}
