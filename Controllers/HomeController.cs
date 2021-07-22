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
using ReflectionIT.Mvc.Paging;
using Google.Apis.Gmail.v1.Data;

namespace HelpersNetwork.Controllers
{
    public class Gallery : Controller
    {
        public Gallery(IHelpersNetworkRepository<ProjectGallery> galleryrepository)
        {
            _galleryrepository = galleryrepository;
        }

        public IHelpersNetworkRepository<ProjectGallery> _galleryrepository { get; }

      
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = _galleryrepository.ReadProjectImages();
            var model = await PagingList.CreateAsync(query, 10, page);
            return View(model);
        }    
    }

   
    public class ProjectVideos : Controller
    {
        public ProjectVideos(IHelpersNetworkRepository<CommunityLatestProject> projectvideorepository)
        {
            _projectvideosrepository = projectvideorepository;
        }

        public IHelpersNetworkRepository<CommunityLatestProject> _projectvideosrepository { get; }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var videostore = _projectvideosrepository.ReadProjectVideos();
            List<YouTubeVideoDetails> query = new List<YouTubeVideoDetails>();
            foreach (var videodetails in videostore)
            {
                var projectvideo = await _projectvideosrepository.GetVideoDetails(videodetails.VideoId);
                projectvideo.InbuiltId = videodetails.Id;
                projectvideo.VideoUrl = videodetails.VideoUrl;
                projectvideo.PublicationDate = Convert.ToDateTime(videodetails.DatePublished);
                query.Add(projectvideo);
            }
            var selected = query.OrderByDescending(x => x.PublicationDate);
            var model = PagingList.Create(query, 10, page);

            return View(model);
        }      
    }
    public class HomeController: Controller 
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHelpersNetworkRepository<NewsModel> _newsrepository;
        private readonly IHelpersNetworkRepository<ProjectGallery> _gelleryrepository;
        private readonly IHelpersNetworkRepository<HelpersNetworkBranchesTb> branchrepository;

        public IWebHostEnvironment webHostEnvironment { get; }
        private IFileManagerService FileManager { get; }
        public IHelpersNetworkRepository<chnbankdetails> Bankrepository { get; }

        public HomeController(ILogger<HomeController> logger,
            IWebHostEnvironment WebHostEnvironment ,
            IHelpersNetworkRepository<NewsModel> newsrepository,
            IFileManagerService fileManager,
            IHelpersNetworkRepository<ProjectGallery> galleryrepository,
            IHelpersNetworkRepository<HelpersNetworkBranchesTb> branchrepository,
            IHelpersNetworkRepository<chnbankdetails> bankrepository
            )
        {
            _logger = logger;
            webHostEnvironment = WebHostEnvironment;
            this._newsrepository = newsrepository;
            this._gelleryrepository = galleryrepository;
            this.branchrepository = branchrepository;
            Bankrepository = bankrepository;
            FileManager = fileManager;
        }


        public async Task<IActionResult> Index()
        {
            var dailymod = _newsrepository.GetDailyViewModel();

            var query = _newsrepository.ReadNews();
            
            //query.Sort((y, x) => x.DatePublished.ToString("dd/MM/yyyy HH:mm").CompareTo(y.DatePublished.ToString("dd/MM/yyyy HH:mm")));

            var newsmodel = await PagingList.CreateAsync(query, 3, 1);
            //newsmodel.Sort((y, x) => x.DatePublished.ToString("dd/MM/yyyy HH:mm").CompareTo(y.DatePublished.ToString("dd/MM/yyyy HH:mm")));

            //newsmodel.OrderBy(e => DateTime.ParseExact(e.DatePublished.ToString(), "dd.MM.yyyy", null));

            HelpersNetworkViewModel HNV1 = new HelpersNetworkViewModel
            {
                News = newsmodel,
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

        public IActionResult Branches()
        {
            var model = branchrepository.ReadBranch();
            return View(model);
        }

        public IActionResult Donate()
        {
            var model = Bankrepository.Read();
            model.OrderBy(x => x.BankName);
            return View(model);
        }
        public IActionResult _StatusMessage()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
