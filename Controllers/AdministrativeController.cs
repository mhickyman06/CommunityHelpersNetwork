using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HelpersNetwork.Data;
using HelpersNetwork.Models;
using HelpersNetwork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpersNetwork.Controllers
{
    [Authorize(Policy = "AdminPanel")]
    [Route("api/[controller]")]

    public class AdministratorController : Controller
    {
        private readonly IHelpersNetworkRepository<EventModel> _eventrepository;
        private readonly IHelpersNetworkRepository<News> _newsrepository;
        private readonly IHelpersNetworkRepository<ProjectGallery> _gelleryrepository;
        private IFileManagerService FileManager { get; }
        public HelpersNetworkIdentityDbContext HelpersNetworkContext { get; }

        public AdministratorController(IHelpersNetworkRepository<EventModel> eventrepository,
              IHelpersNetworkRepository<News> newsrepository,
              IHelpersNetworkRepository<ProjectGallery> projectgalleryrepository,
             IFileManagerService fileManager,
             HelpersNetworkIdentityDbContext helpersNetworkContext
            )
        {
            this._eventrepository = eventrepository;
            this._newsrepository = newsrepository;
            this._gelleryrepository = projectgalleryrepository;
            FileManager = fileManager;
            HelpersNetworkContext = helpersNetworkContext;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }


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
            return View(model);

        }
        [HttpPost, ActionName("DeleteMembers")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteMembersConfirmed(string Id)
        {
            var model = HelpersNetworkContext.Users.Find(Id);
            HelpersNetworkContext.Users.Remove(model);
            HelpersNetworkContext.SaveChanges();
            return RedirectToAction(nameof(ListMembers));
        }

        //public IActionResult DeleteNews(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var model = _newsrepository.FindbyCondition(id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(model);
        //}
        #region News

         
        [HttpGet]
        [Route("CreateNews")]
        public IActionResult CreateNews()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateNews")]
        public async Task<IActionResult> CreateNews(NewsViewModel newsView)
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
                    ImagePath = await FileManager.SaveImage(newsView.PhotoSource)
                };
                _newsrepository.Create(News);
                return RedirectToAction(nameof(News));
            }
            return View(newsView);
        }

        [HttpPost, ActionName("DeleteNews")]
        [ValidateAntiForgeryToken]
        [Route("DeleteNews")]

        public IActionResult DeleteNews(int Id)
        {
            _newsrepository.Delete(Id);
            //News EVM1 = new News
            //{
            //    Id = model.Id,
            //    Title = model.Title,
            //    DatePublished = model.DatePublished,
            //    ShortDescription = model.ShortDescription,
            //    Body = model.Body,
            //    PageTtile = model.PageTtile,
            //    ImagePath = model.ImagePath
            //};

            return Ok();
            //return RedirectToAction(nameof(ListNews));
        }

        [Route("ListNews")]
        public IActionResult ListNews()
        {
            var model = _eventrepository.Read();
            return View(model);
        }
        #endregion

        #region DailyView

        [HttpGet]
        [Route("EditDailyView")]
        public IActionResult EditDailyView(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = _eventrepository.FindbyCondition(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [Route("EditDailyView")]
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
                    _eventrepository.EditDailyViewModel(dailyViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_eventrepository.FindbyCondition(dailyViewModel.Id) == null)
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


        }

        [HttpGet]
        [Route("DailyView")]
        public IActionResult DailyView()
        {
            var model = _eventrepository.GetDailyViewModel();
            return View(model);
        }
        #endregion

        #region Event

        [HttpGet]
        [Route("CreateEvent")]
        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateEvent")]
        public async Task<IActionResult> CreateEvent(CreateEventViewModel createEventViewModel)
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
                    ImagePath = await FileManager.SaveImage(createEventViewModel.images)
                };
                _eventrepository.Create(events);
                return RedirectToAction(nameof(Index));
            }
            return View(createEventViewModel);
        }

        public IActionResult EditEvent()
        {
            return View();
        }
        //public IActionResult DeleteEvent(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var events = Repository.FindEventByCondition(id);
        //    if (events == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(events);
        //}

        [HttpPost, ActionName("DeleteEvent")]
        [ValidateAntiForgeryToken]
        [Route("DeleteEvent")]

        public IActionResult DeleteEvent(int Id)
        {
            _eventrepository.Delete(Id);
            //EventModel EVM1 = new EventModel
            //{
            //    Id = model.Id,
            //    Title = model.Title,
            //    DatePublished = model.DatePublished,
            //    ShortDescription = model.ShortDescription,
            //    Body = model.Body,
            //    PageTtile = model.PageTtile,
            //    ImagePath = model.ImagePath
            //};

            return Ok();
            //return RedirectToAction(nameof(ListEvent));
        }

        [HttpGet]
        [Route("ListEvent")]
        public IActionResult ListEvent()
        {
            var model = _eventrepository.Read();
            return View(model);
        }
        #endregion
       

       

       

       
        //public IActionResult EditDetails()
        //{
        //    return View();
        //}
    }
}