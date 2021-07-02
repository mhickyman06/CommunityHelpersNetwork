using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.ViewModels
{
    public class EditProjectVideoViewModel
    {

        
        [DisplayName("Youtube Video Url")]
        public string VideoUrl { get; set; }

        [DisplayName("Youtube Video Id")]
        public string VideoId { get; set; }
    }
}