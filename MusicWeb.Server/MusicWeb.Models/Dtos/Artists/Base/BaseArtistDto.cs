using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Artists.Base
{
    public abstract class BaseArtistDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Establishment Date is required")]
        public DateTime EstablishmentDate { get; set; }

        public string Bio { get; set; }

        [Required(ErrorMessage = "IsIndividual is required")]
        [AssertThat("IsIndividual != IsBand", ErrorMessage = "An Artist cannot be a band and an individual artist at the same time")]
        public bool IsIndividual { get; set; }

        [Required(ErrorMessage = "IsBand is required")]
        public bool IsBand { get; set; }

        [AssertThat("IsBand && BandId > 0", ErrorMessage = "BandId has to equal 0 if an artist is a band")]
        [AssertThat("IsIndividual && BandId > 0", ErrorMessage = "BandId has to equal 0 if an artist is an individual one")]
        public int? BandId { get; set; }

        [Required(ErrorMessage = "CityId is required")]
        public int CityId { get; set; }
    }
}
