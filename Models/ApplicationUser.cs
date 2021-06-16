using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string Age { get; set; }
        [Required]
        public string Sex { get; set; }
        public string Address { get; set; }
        
    }
}
