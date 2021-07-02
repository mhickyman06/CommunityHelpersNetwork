using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.ViewModels
{
    public class EditUserModel : IdentityUser
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public string Religion { get; set; }

        public string State { get; set; }

        public string LocalGovt { get; set; }

        public string Nationality { get; set; }

        [DisplayName("Old Password")]
        public string OldPassword { get; set; }

        [DisplayName("New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }

    }
}
