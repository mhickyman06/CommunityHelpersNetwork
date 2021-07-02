using Microsoft.AspNetCore.Identity;
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
        public string Gender { get; set; }
        public string Address { get; set; }

        [Required]
        public string Religion { get; set; }

        public string State { get; set; }

        public string  LocalGovt { get; set; }

        public string  Nationality { get; set; }


    }
}
