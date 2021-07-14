using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.ViewModels
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "IsEmailInUsed", controller: "Account", ErrorMessage = "Email is in used by another user")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

         [Display(Name = "Remember me")]
        public bool IsPersistent { get; set; }

        public string SessionResponse { get; set; }

        public string UserId { get; set; }

        public bool ShowResend { get; set; }
    }
}