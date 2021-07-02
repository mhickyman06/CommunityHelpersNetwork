using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.ViewModels
{
    public class EditProjectImages
    {
        public int Id { get; set; }

        [DisplayName("Image Title")]
        public string ImageTitle { get; set; }

        [DisplayName("Existing Image Path")]
        public string ExistingImagePath { get; set; }
        [DisplayName("Photo")]
        public IFormFile ImagePath { get; set; }
    }
}