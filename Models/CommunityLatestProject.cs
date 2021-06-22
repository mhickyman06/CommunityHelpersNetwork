using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.Models
{
    public class CommunityLatestProject
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Published")]
        public DateTime DatePublished { get; set; } = DateTime.Now;

        [Required]
        public string ProjectTitle { get; set; } 
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Body { get; set; }

        [Required]
        [DisplayName("Video Url")]
        public string  VideoUrl { get; set; }
    }
}