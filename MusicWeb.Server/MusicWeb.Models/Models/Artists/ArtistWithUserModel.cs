using Microsoft.AspNetCore.Components.Forms;
using MusicWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Models.Artists
{
    public class ArtistWithUserModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Establishment Date is required")]
        public DateTime EstablishmentDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Bio is required")]
        [MaxLength(500, ErrorMessage = "Bio's max length is 500 characters")]
        public string Bio { get; set; }


        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        public IBrowserFile Image { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageBytes { get; set; }


        public ArtistType Type{ get; set; }

        public int CountryId { get; set; }
        public int StateId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "City is required")]
        public int CityId { get; set; }

        public int? BandId { get; set; }
    }
}
