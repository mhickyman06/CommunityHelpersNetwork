using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.Models
{
    public class NewsModel
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
        [DataType(DataType.Text)]
        [Display(Name = "Short Description")]
        [StringLength(400)]
        public string ShortDescription { get; set; }   
        [Required]
        [DataType(DataType.Text)]
        public string Body { get; set; }
       
        public string ImagePath { get; set; }

        //public string DateCreated { get; set; }

    }
}
