using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpersNetwork.Models
{
    public class CommunityLatestProject
    {
        //[Key]
        //public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

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