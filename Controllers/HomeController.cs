using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelpersNetwork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Authentication.Cookies;
using HelpersNetwork.ViewModels;

namespace HelpersNetwork.Controllers
{
    public class HomeController: Controller 
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHelpersNetworkRepository<EventModel> _eventrepository;
        private readonly IHelpersNetworkRepository<News> _newsrepository;
        private readonly IHelpersNetworkRepository<ProjectGallery> _gelleryrepository;

        public IWebHostEnvironment webHostEnvironment { get; }
        private IFileManagerService FileManager { get; }

        public HomeController(ILogger<HomeController> logger,
            IWebHostEnvironment WebHostEnvironment ,
            IHelpersNetworkRepository<EventModel> eventrepository,
            IHelpersNetworkRepository<News> newsrepository,
            IFileManagerService fileManager,
            IHelpersNetworkRepository<ProjectGallery> galleryrepository
            )
        {
            _logger = logger;
            webHostEnvironment = WebHostEnvironment;
            this._eventrepository = eventrepository;
            this._newsrepository = newsrepository;
            this._gelleryrepository = galleryrepository;
            FileManager = fileManager;

        }


        public IActionResult Index()
        {
            var dailymod = _eventrepository.GetDailyViewModel();
            HelpersNetworkViewModel HNV1 = new HelpersNetworkViewModel
            {
                EventModels = _eventrepository.Read(),
                DailyViewModel = dailymod
            };
            return View(HNV1);
        }
       
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult _StatusMessage()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
  


        public IActionResult Gallery()
        {
            List<ProjectGallery> model = _gelleryrepository.Read();
            return View(model);
        }
        public IActionResult News()
        {
            HelpersNetworkViewModel HNV1 = new HelpersNetworkViewModel();
            HNV1.News = _newsrepository.Read();
            HNV1.EventModels =_eventrepository.Read();
            return View(HNV1);
        }
       
        public IActionResult NewsDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = _newsrepository.FindbyCondition(id);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
