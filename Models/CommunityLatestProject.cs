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
        public string DatePublished { get; set; } 
      
        [Required]
        [DisplayName("Youtube Video Url")]
        public string  VideoUrl { get; set; }

        [Required]
        [DisplayName("Youtube Video Id")]
        public string VideoId { get; set; }
    }
}