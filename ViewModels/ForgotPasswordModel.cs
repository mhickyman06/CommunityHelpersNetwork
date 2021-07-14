using System;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.ViewModels
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}