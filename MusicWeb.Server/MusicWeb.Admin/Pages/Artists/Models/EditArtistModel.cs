using Microsoft.AspNetCore.Components.Forms;
using MusicWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Artists.Models
{
    public class EditArtistModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Establishment Date is required")]
        public DateTime EstablishmentDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Bio is required")]
        [MaxLength(500, ErrorMessage = "Bio's max length is 500 characters")]
        public string Bio { get; set; }

        public string ImagePath { get; set; }


        public ArtistType Type { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Country is required")]
        public int CountryId { get; set; }

        public int? BandId { get; set; }
    }
}
