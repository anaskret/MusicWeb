﻿using System;
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
        public bool IsIndividual { get; set; }

        [Required(ErrorMessage = "IsIndividual is required")]
        public bool IsBand { get; set; }

        public int? BandId { get; set; }
        public int CityId { get; set; }
    }
}
