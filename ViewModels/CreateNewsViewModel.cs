using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.ViewModels
{
    public class CreateNewsViewModel
    {
        [Required]
        public DateTime DatePublished { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DisplayName("Page Title")]
        public string PageTtile { get; set; }
        [Required]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        [DisplayName("Image")]
        public IFormFile imagepath { get; set; }
    }
}
