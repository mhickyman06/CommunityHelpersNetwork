using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.ViewModels
{
    public class CreateBankDetailsViewModel
    {
       
        [Required]
        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [Required]
        [DisplayName("Account Name")]
        public string BankAccountName { get; set; }

        [Required]
        [DisplayName("Account Number")]
        public string BankAccountNumber { get; set; }
    }
}