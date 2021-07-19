using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelpersNetwork.ViewModels
{
    public class EditProjectVideoViewModel
    {
        public string Id { get; set; }

        [DisplayName("Youtube Video Url")]
        public string VideoUrl { get; set; }

        [DisplayName("Youtube Video Id")]
        public string VideoId { get; set; }
    }
}