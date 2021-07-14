using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpersNetwork.Models
{
    public class HelpersNetworkBranchesTb
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string BranchName { get; set; }

        [Required]
        public string BranchCountry { get; set; }

        [Required]
        public string BranchState { get; set; }

        [Required]
        public string  BranchLocalGovt { get; set; }

        [Required]
        public string BranchAddress { get; set; }

        [Required]
        public string BranchContactPerson { get; set; }

        [Required]
        public string ContactPersonNumber { get; set; }
    }
}