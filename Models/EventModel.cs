using HelpersNetwork;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.Models
{
    public class EventModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date Published")]
        public DateTime DatePublished { get; set; } = DateTime.Now;
        [Required]
        public string Title { get; set; }
        [Required]
        public string PageTtile { get; set; }
        [Required]
        [Display(Name ="Short Description")]
        public string ShortDescription { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        [DisplayName("Event Image")]
        public string  ImagePath { get; set; }
    }
}
