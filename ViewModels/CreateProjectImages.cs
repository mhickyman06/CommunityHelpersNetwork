using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.ViewModels
{
    public class CreateProjectImagesModel
    {
        public int Id { get; set; }

        [Required]
        public string ImageTitle { get; set; }

        [Required]
        public IFormFile ImagePath { get; set; }
    }
}