using System;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.ViewModels
{
    public class SendMailViewModel
    {
        public string ToEmail { get; set; }
        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }
    }
}