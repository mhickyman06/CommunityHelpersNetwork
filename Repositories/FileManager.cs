using HelpersNetwork.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<FileManagerService> logger;
        private readonly IWebHostEnvironment hostEnvironment;

        public FileManagerService(IConfiguration configuration,
            ILogger<FileManagerService> logger,
            IWebHostEnvironment hostEnvironment)
        {
            _imagepath = configuration["path:Images"];
            this.logger = logger;
            this.hostEnvironment = hostEnvironment;
        }

        public string _imagepath { get; }

        public async Task<string> SaveImage(IFormFile image)
        {
            try
            {
                var save_path = Path.Combine(hostEnvironment.WebRootPath, "ContentImages");

                //var save_path = Path.Combine(_imagepath);

                if (!Directory.Exists(_imagepath))
                {
                    Directory.CreateDirectory(save_path);
                }
                Guid guid = Guid.NewGuid();
                var filename = guid + image.FileName;
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
        public void DeleteImage(string imagepath)
        {
            try
            {
                var save_path = Path.Combine(_imagepath, imagepath);
                File.Delete(save_path);
            }
            catch
            {
                logger.LogInformation("Error");
            }
        }

        public async Task<string> UpdateImage(string existingimage, IFormFile newimagepath)
        {
            DeleteImage(existingimage);
            return await SaveImage(newimagepath);
        }
    }
}
