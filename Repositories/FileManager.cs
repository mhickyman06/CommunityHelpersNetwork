using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace HelpersNetwork.Models
{
    public class FileManagerService : IFileManagerService
    {
        public FileManagerService(IConfiguration configuration)
        {
            _imagepath = configuration["path:Images"];

        }

        public string _imagepath { get; }
        public ILogger Logger { get; }

        public async Task<string> SaveImage(IFormFile image)
        {
            try
            {
                var save_path = Path.Combine(_imagepath);
                if (!Directory.Exists(_imagepath))
                {
                    Directory.CreateDirectory(save_path);
                }
                var filename = new Guid() + image.FileName;
                using (var filestream = new FileStream(Path.Combine(save_path, filename), FileMode.Create))
                {
                    await image.CopyToAsync(filestream);
                }
                return filename;
            }catch(Exception ex)
            {
                Console.Write(ex.Message);
                return "Error";
            }
        }
    }
}
