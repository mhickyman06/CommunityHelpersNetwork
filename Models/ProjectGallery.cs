using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.Models
{
    public class ProjectGallery
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime DatePublished { get; set; } = DateTime.Now;

        [Required]
        [DisplayName("Gallery Title")]
        public string ImageTitle { get; set; }

        [Required]
        [DisplayName("Photo Path")]
        public string ImagePath { get; set; }
    }
}
