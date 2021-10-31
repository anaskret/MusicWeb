﻿using MusicWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Settings.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [StringLength(50, ErrorMessage = "Password has to have between {2} and {1} characters", MinimumLength = 6)]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords are different")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Make sure email is valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; } = DateTime.Now;
    }
}
