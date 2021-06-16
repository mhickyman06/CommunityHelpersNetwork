using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HelpersNetwork.Data;
using HelpersNetwork.Models;
using HelpersNetwork.ViewModels;
using HelpersNetwork.Views.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpersNetwork.Controllers
{
    [Authorize(Policy = "AdminPanel")]
    public class AdministrativeController : Controller
    {
        private readonly IHelpersNetworkEventRepository Repository;
        private IFileManagerService FileManager { get; }
        //private RoleManager<IdentityRole> RoleManager { get; }
        public HelpersNetworkIdentityDbContext HelpersNetworkContext { get; }

        public AdministrativeController(IHelpersNetworkEventRepository repository,
             IFileManagerService fileManager,
             //RoleManager<IdentityRole> roleManager,
             HelpersNetworkIdentityDbContext helpersNetworkContext
            )
        {
            Repository = repository;
            FileManager = fileManager;
            //RoleManager = roleManager;
            HelpersNetworkContext = helpersNetworkContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public IActionResult CreateRole()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleView)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        IdentityRole role = new IdentityRole()
        //        {
        //            Name = createRoleView.RoleName
        //        };
        //        IdentityResult result = await RoleManager.CreateAsync(role);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        foreach (IdentityError error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //    }

        //    return View(createRoleView);
        //}

            public IActionResult ListMembers()
            {

                 var Members = HelpersNetworkContext.Users.ToList(); 
                 return View(Members);

            }
        [HttpGet]
        public IActionResult DeleteMembers(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string Id = id.ToString();
            var model = HelpersNetworkContext.Users.FirstOrDefault(p => p.Id == Id);
            if (model == null)
            {
                return NotFound();
            }
            //return View(movie);
            return View(model);
            //if(id == null)
            //{
            //    return NotFound();
            //}
            //var model = HelpersNetworkContext.Users.Find(id);
            //return View(model);
        }
        [HttpPost, ActionName("DeleteMembers")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteMembersConfirmed(string Id)
        {
            //var model = Repository.DeleteNews(Id);
            var model = HelpersNetworkContext.Users.Find(Id);
            HelpersNetworkContext.Users.Remove(model);
            HelpersNetworkContext.SaveChanges();         
            return RedirectToAction(nameof(ListMembers));
        }
        public IActionResult DeleteNews(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = Repository.FindNewsByCondition(id);
            if (model == null)
            {
                return NotFound();
            }
            //retur
            return View(model);
        }

        [HttpPost, ActionName("DeleteNews")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteNewsConfirmed(int Id)
        {
            var model = Repository.DeleteNews(Id);
            News EVM1 = new News
            {
                Id = model.Id,
                Title = model.Title,
                DatePublished = model.DatePublished,
                ShortDescription = model.ShortDescription,
                Body = model.Body,
                PageTtile = model.PageTtile,
                Images = model.Images
            };

            return RedirectToAction(nameof(ListNews));
        }
        [HttpGet]

        public IActionResult EditDailyView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = Repository.GetDailyViewModelByCondition(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        //[ ActionName("EditViewModel")]
        public IActionResult EditDailyView(int id, DailyViewModel dailyViewModel)
        {
            if (id != dailyViewModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    Repository.EditDailyViewModel(dailyViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (Repository.GetDailyViewModelByCondition(dailyViewModel.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(DailyView));
            }
            return View(dailyViewModel);

            //var model = dailyViewModel;
            //if (ModelState.IsValid)
            //{
            //    Repository.EditDailyViewModel(dailyViewModel);
            //    return RedirectToAction(nameof(DailyView));
            //}
            //return View(model);
        }
        public IActionResult DeleteEvent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var events = Repository.FindEventByCondition(id);
            if (events == null)
            {
                return NotFound();
            }
            //return View(movie);
            return View(events);
        }
        //[HttpPost]
        [HttpPost, ActionName("DeleteEvent")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteEventConfirmed(int Id)
        {
            var model = Repository.Delete(Id);
            EventModel EVM1 = new EventModel
            {
                Id = model.Id,
                Title = model.Title,
                DatePublished = model.DatePublished,
                ShortDescription = model.ShortDescription,
                Body = model.Body,
                PageTtile = model.PageTtile,
                Images = model.Images
            };

            return RedirectToAction(nameof(ListEvent));
        }

        public IActionResult ListEvent()
        {
            var model = Repository.Read();
            return View(model);
        }
        public IActionResult ListNews()
        {
            var model = Repository.GetNewsModel();
            return View(model);
        }

        public IActionResult DailyView()
        {
            var model = Repository.GetDailyViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateNews()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNews(/*News news*/NewsViewModel newsView)
        {

            if (ModelState.IsValid)
            {
                var News = new News()
                {
                    Id = newsView.Id,
                    Title = newsView.Title,
                    PageTtile = newsView.PageTtile,
                    DatePublished = newsView.DatePublished,
                    ShortDescription = newsView.ShortDescription,
                    Body = newsView.Body,
                    Images = await FileManager.SaveImage(newsView.PhotoSource)
                };
                Repository.CreateNews(/*news*/ News);
                return RedirectToAction(nameof(News));
            }
            return View(newsView);
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvent(/*News news*/CreateEventViewModel createEventViewModel)
        {

            if (ModelState.IsValid)
            {
                var events = new EventModel()
                {
                    Id = createEventViewModel.Id,
                    Title = createEventViewModel.Title,
                    PageTtile = createEventViewModel.PageTtile,
                    DatePublished = createEventViewModel.DatePublished,
                    ShortDescription = createEventViewModel.ShortDescription,
                    Body = createEventViewModel.Body,
                    Images = await FileManager.SaveImage(createEventViewModel.images)
                };
                Repository.Create(/*news*/ events);
                return RedirectToAction(nameof(Index));
            }
            return View(createEventViewModel);
        }

        public IActionResult EditEvent()
        {
            return View();
        }
        public IActionResult EditDetails()
        {
            return View();
        }
    }
}