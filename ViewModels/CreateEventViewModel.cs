using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.ViewModels
{
    public class CreateEventViewModel
    {
        public int Id { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string PageTtile { get; set; }
        public string ShortDescription { get; set; }
        public string Body { get; set; }
        public IFormFile images { get; set; }
    }
}
