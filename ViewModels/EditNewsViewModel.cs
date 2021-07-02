using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.ViewModels
{
    public class EditNewsViewModel
    {
        public int Id { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        [DisplayName("Page Title")]
        public string PageTtile { get; set; }

        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }
        public string Body { get; set; }

        [DisplayName("Existing Image")]
        public string ExistingImagePath { get; set; }

        [DisplayName("Image")]
        public IFormFile ImagePath { get; set; }
    }
}
