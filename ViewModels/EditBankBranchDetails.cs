using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.ViewModels
{
    public class EditBankBranchDdtails
    {
        public int Id { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("Account Name")]
        public string BankAccountName { get; set; }

        [DisplayName("Account Number")]
        public string BankAccountNumber { get; set; }
    }
}