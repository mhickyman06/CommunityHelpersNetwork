using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelpersNetwork.Models;
using Microsoft.AspNetCore.Authorization;
using HelpersNetwork.Views.Home;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Authentication.Cookies;
using HelpersNetwork.ViewModels;

namespace HelpersNetwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHelpersNetworkEventRepository Repository;

        public IWebHostEnvironment webHostEnvironment { get; }
        private IFileManagerService FileManager { get; }

        public HomeController(ILogger<HomeController> logger,
            IWebHostEnvironment WebHostEnvironment ,
            IHelpersNetworkEventRepository repository,
            IFileManagerService fileManager
            )
        {
            _logger = logger;
            webHostEnvironment = WebHostEnvironment;
            Repository = repository;
            FileManager = fileManager;

        }


        public IActionResult Index()
        {
            var dailymod = Repository.GetDailyViewModel();

            HelpersNetworkViewModel HNV1 = new HelpersNetworkViewModel
            {
                EventModels = Repository.Read(),
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
    //    public IActionResult ConfirmEmail()
    //    {
    //         private readonly UserManager<HelpersNetworkUser> _userManager;

    //    public ConfirmEmailModel(UserManager<HelpersNetworkUser> userManager)
    //    {
    //        _userManager = userManager;
    //    }

    //    [TempData]
    //    public string StatusMessage { get; set; }

    //    public async Task<IActionResult> OnGetAsync(string userId, string code)
    //    {
    //        if (userId == null || code == null)
    //        {
    //            return RedirectToPage("/Index");
    //        }

    //        var user = await _userManager.FindByIdAsync(userId);
    //        if (user == null)
    //        {
    //            return NotFound($"Unable to load user with ID '{userId}'.");
    //        }

    //        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
    //        var result = await _userManager.ConfirmEmailAsync(user, code);
    //        StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
    //        return Page();
    //    }
    //}
    //        return View();
    //    }






        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult News()
        {
            HelpersNetworkViewModel HNV1 = new HelpersNetworkViewModel();
            HNV1.News = Repository.GetNewsModel();
            HNV1.EventModels = Repository.Read();
            return View(HNV1);
        }
       
        public IActionResult NewsDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = Repository.GetNewsByCondition(id);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
