using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Users
{
    public class UpdatePasswordDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage =  "OldPassword is required")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "NewPassword is required")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare("NewPassword", ErrorMessage = "Passwords are different")]
        public string ConfirmPassword { get; set; }
    }
}
