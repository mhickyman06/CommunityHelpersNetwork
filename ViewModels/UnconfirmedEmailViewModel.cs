using System;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.ViewModels
{
    public class UnconfirmedEmailViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}