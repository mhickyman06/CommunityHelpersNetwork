using System;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.Models
{
    public class chnbankdetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BankName { get; set; }

        [Required]
        public string BankAccountName { get; set; }

        [Required]
        public string BankAccountNumber { get; set; }
    }
}