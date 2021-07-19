using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.ViewModels
{
    public class EditBranchViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Branch Name")]
        public string BranchName { get; set; }

        [DisplayName("Branch Country")]
        public string BranchCountry { get; set; }

        [DisplayName("Branch State")]

        public string BranchState { get; set; }

        [DisplayName("Branch Local Government Area")]

        public string BranchLocalGovt { get; set; }

        [DisplayName("Branch Address")]

        public string BranchAddress { get; set; }

        [DisplayName("Contact Person")]

        public string BranchContactPerson { get; set; }

        [DisplayName("Contact Person Number")]
        public string ContactPersonNumber { get; set; }
    }
}