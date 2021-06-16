using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.Models
{
   public interface IFileManagerService
    {
        Task<string> SaveImage(IFormFile image);
    }
}

//public FileManager(IConfiguration configuration)
//{
//    _imagepath = configuration["path:Images"];

//}

//public string _imagepath { get; }

//public async Task<string> SaveImage(IFormFile image)
//{
//    var save_path = Path.Combine(_imagepath);
//    if (!Directory.Exists(_imagepath))
//    {
//        Directory.CreateDirectory(save_path);
//    }
//    var filename = new Guid() + image.FileName;
//    using (var filestream = new FileStream(Path.Combine(save_path, filename), FileMode.Create))
//    {
//        await image.CopyToAsync(filestream);
//    }
//    return filename;
//}