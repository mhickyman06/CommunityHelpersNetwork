using System;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.ViewModels
{
    public class PdfModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Amount { get; set; }

        public string Message { get; set; }

    }
}