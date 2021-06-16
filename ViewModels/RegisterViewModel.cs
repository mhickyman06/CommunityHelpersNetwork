using HelpersNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string Age { get; set; }
        [Required]
        public int Sex { get; set; }
        public string Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "IsEmailInUsed", controller: "Account", ErrorMessage = "Email is in used by another user")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passowrd are not the same")]
        public string ConfirmPassword { get; set; }

    }
}