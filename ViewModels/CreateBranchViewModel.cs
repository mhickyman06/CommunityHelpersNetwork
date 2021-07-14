using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.ViewModels
{
    public class CreateBranchViewModel
    {
        
        [Required]
        [DisplayName("Branch Name")]
        public string BranchName { get; set; }

        [Required]
        [DisplayName("Branch Country")]
        public string BranchCountry { get; set; }

        [Required]
        [DisplayName("Branch State")]

        public string BranchState { get; set; }

        [Required]
        [DisplayName("Branch Local Government Area")]

        public string BranchLocalGovt { get; set; }

        [Required]
        [DisplayName("Branch Address")]

        public string BranchAddress { get; set; }

        [Required]
        [DisplayName("Contact Person")]

        public string BranchContactPerson { get; set; }

        [Required]
        [DisplayName("Contact Person Number")]
        public string ContactPersonNumber { get; set; }
    }
}