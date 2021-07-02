using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using HelpersNetwork.Data;
using HelpersNetwork.Models;
using HelpersNetwork.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReflectionIT.Mvc.Paging;

namespace HelpersNetwork.Controllers
{

    [Authorize(Policy = "AdminPanel")]
    [Route("api/[controller]")]

    public class ListNews : Controller
    {
        public ListNews(IHelpersNetworkRepository<NewsModel> newsrepository)
        {
            Newsrepository = newsrepository;
        }

        public IHelpersNetworkRepository<NewsModel> Newsrepository { get; }

        [Route("Index")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = Newsrepository.ReadNews();
            var model = await PagingList.CreateAsync(query, 2, page);
            //model.OrderByDescending(x => x.DatePublished);
            return View(model);
        }
    }

    [Authorize(Policy = "AdminPanel")]
    [Route("api/[controller]")]

    public class ListProjectPhotos : Controller
    {
        public ListProjectPhotos(IHelpersNetworkRepository<ProjectGallery> projectimagesrepository)
        {
            projectimagerepository = projectimagesrepository;
        }

        public IHelpersNetworkRepository<ProjectGallery> projectimagerepository { get; }

        [Route("Index")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = projectimagerepository.ReadProjectImages();
            var model = await PagingList.CreateAsync(query, 2, page);
            //model.OrderByDescending(x => x.DatePublished);
            return View(model);
        }
    }

    [Authorize(Policy = "AdminPanel")]
    [Route("api/[controller]")]

    public class ListProjectVideos : Controller
    {
        public ListProjectVideos(IHelpersNetworkRepository<CommunityLatestProject> projectvideosrepository)
        {
            _projectvideosrepository = projectvideosrepository;
        }

        public IHelpersNetworkRepository<CommunityLatestProject> _projectvideosrepository { get; }

        [HttpGet]
        [Route("Index")]

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
            var model =  PagingList.Create(query, 1, page);

            return View(model);
        }
    }

    [Authorize(Policy = "AdminPanel")]
    [Route("api/[controller]")]

    public class ListMembers : Controller
    {
        public ListMembers(HelpersNetworkIdentityDbContext context)
        {
            _context = context;
        }

        public HelpersNetworkIdentityDbContext _context { get; }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var query = _context.Users.AsNoTracking().OrderBy(x => x.Name);
            var model = await PagingList.CreateAsync(query, 1, page);
            return View(model);
        }
    }







    [Authorize(Policy = "AdminPanel")]
    [Route("api/[controller]")]

    public class AdministratorController : Controller
    {
        private readonly IHelpersNetworkRepository<NewsModel> _newsrepository;
        private readonly IHelpersNetworkRepository<ProjectGallery> _gelleryrepository;
        private readonly IHelpersNetworkRepository<DailyViewModel> dailyviewrepository;
        private readonly IHelpersNetworkRepository<CommunityLatestProject> projectvideosrepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPasswordHasher<ApplicationUser> passwordHasher;
        private readonly ILogger<AdministratorController> logger;

        private IFileManagerService FileManager { get; }
        public HelpersNetworkIdentityDbContext HelpersNetworkContext { get; }

        public AdministratorController(
              IHelpersNetworkRepository<NewsModel> newsrepository,
              IHelpersNetworkRepository<ProjectGallery> projectgalleryrepository,
             IFileManagerService fileManager,
             HelpersNetworkIdentityDbContext helpersNetworkContext,
             IHelpersNetworkRepository<DailyViewModel> dailyviewrepository,
             IHelpersNetworkRepository<CommunityLatestProject> projectvideosrepository,
             UserManager<ApplicationUser> userManager,
             IPasswordHasher<ApplicationUser> passwordHasher,
             ILogger<AdministratorController> logger
            )
        {
            this._newsrepository = newsrepository;
            this._gelleryrepository = projectgalleryrepository;
            FileManager = fileManager;
            HelpersNetworkContext = helpersNetworkContext;
            this.dailyviewrepository = dailyviewrepository;
            this.projectvideosrepository = projectvideosrepository;
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
            this.logger = logger;
        }



        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        

        #region Project Video

     
        [HttpGet]
        [Route("CreateProjectVideo")]

        public IActionResult CreateProjectVideo()
        {
            return View();
        }


        [HttpPost]
        [Route("CreateProjectVideo")]

        public IActionResult CreateProjectVideo(CreateProjectVideoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var projectvideo = new CommunityLatestProject
                {
                    DatePublished = DateTime.Now.ToString(),
                    VideoUrl = model.VideoUrl,
                    VideoId = model.VideoId
                };

                projectvideosrepository.Create(projectvideo);
                projectvideosrepository.Save();
                return RedirectToAction(nameof(ListProjectVideos));

            }
            return View(model);
        }


        [HttpGet]
        [Route("UpdateProjectVideo/{Id}")]

        public IActionResult UpdateProjectVideo(int? Id)
        {
            var video =  projectvideosrepository.FindbyCondition(Id);
            if(video == null)
            {
                return NotFound();
            }
            var model = new EditProjectVideoViewModel()
            {
                VideoId = video.VideoId,
                VideoUrl = video.VideoUrl
            };
            return View(model);
        }

        [HttpPost]
        [Route("UpdateProjectVideo/{Id}")]
        public IActionResult UpdateProjectVideo(int? Id,EditProjectVideoViewModel viewmodel)
        {
            var video =  projectvideosrepository.FindbyCondition(Id);
            if(video == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                video.VideoUrl = viewmodel.VideoUrl;
                video.VideoId = viewmodel.VideoId;
                video.DatePublished = DateTime.Now.ToString();

                projectvideosrepository.Update(video);
                projectvideosrepository.Save();
                return RedirectToAction(nameof(ListProjectVideos));
            }
          
            return View(viewmodel);
        }

        #endregion

        #region Application User

      

        [HttpPost("RemoveUser")]
        [Route("RemoveUser/{Id}")]

        public async Task<JsonResult> RemoveUser(string Id)
        {          
            var user = await userManager.FindByIdAsync(Id);
            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    logger.LogInformation("Successfully deleted a user with the name " + user.Name);
                    return Json("Successfully Deleted");
                }

                foreach (var error in result.Errors)
                {
                    logger.LogInformation(error.Description);
                }
            }
          
            return Json("Couldn't Delete this User");
        }

        [HttpGet]
        [Route("EditUser")]
        public async Task<IActionResult> EditUser(string Id)
        {           
            var user = await userManager.FindByIdAsync(Id);
            if(user == null)
            {
                return NotFound();
            }
            var model = new EditUserModel()
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Gender = user.Gender,
                Religion = user.Religion,
                Nationality = user.Nationality,
                State = user.State,
                LocalGovt = user.LocalGovt,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Email = user.Email,
                OldPassword = user.PasswordHash
            };
           
            return View(model);
        }

        [HttpPost]
        [Route("EditUser")]

        public async Task<IActionResult> EditUser(string Id,EditUserModel model)
        {
            var user = await userManager.FindByIdAsync(Id);
            if(user == null)
            {
                return NotFound();
            }
            user.Name = model.Name;
            user.Age = model.Age;
            user.Gender = model.Gender;
            user.Religion = model.Religion;
            user.Nationality = model.Nationality;
            user.State = model.State;
            user.LocalGovt = model.LocalGovt;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;
            user.UserName = model.UserName;
            user.Email = model.UserName;

            if(model.ConfirmNewPassword != null)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, model.ConfirmNewPassword);
            }
            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return RedirectToAction(nameof(ListMembers));
            }
            return RedirectToAction(nameof(ListMembers));
        }

        #endregion

        #region News



        [HttpGet]
        [Route("CreateNews")]
        public IActionResult CreateNews()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateNews")]
        public async Task<IActionResult> CreateNews(CreateNewsViewModel newsView)
        {

            if (ModelState.IsValid)
            {
                var News = new NewsModel()
                {
                    //Id = newsView.i,
                    Title = newsView.Title,
                    PageTtile = newsView.PageTtile,
                    DatePublished = DateTime.Now,
                    ShortDescription = newsView.ShortDescription,
                    Body = newsView.Body,
                    ImagePath = await FileManager.SaveImage(newsView.imagepath)
                };
                _newsrepository.Create(News);
                _newsrepository.Save();
                return RedirectToAction(nameof(ListNews));
            }         
            return View(newsView);
        }

        [HttpPost("DeleteNews")]
        //[ValidateAntiForgeryToken]
        [Route("DeleteNews")]

        public async Task<JsonResult> DeleteNews(int? Id)
        {
            var newmodel = await HelpersNetworkContext.News.FindAsync(Id);
            try
            {
                _newsrepository.Delete(Id, newmodel.ImagePath);
                _newsrepository.Save();

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Json("Couldn't Delete this News");
            }

            logger.LogInformation("Successfully Deleted a news with the page title " + newmodel.PageTtile); 

            return Json(new { Status = "Successfully Deleted" });

        }

        [HttpGet("EditNews")]
        [Route("EditNews")]
        public  IActionResult EditNews(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var news = _newsrepository.FindbyCondition(id);

            var newsmodel = new EditNewsViewModel
            {
                Id = news.Id,
                PageTtile = news.PageTtile,
                Title = news.Title,
                Body = news.Body,
                ShortDescription = news.ShortDescription,
                ExistingImagePath = news.ImagePath
            };
            return View(newsmodel);
        }


        [HttpPost("EditNews")]
        [Route("EditNews")]
        public async Task<IActionResult> EditNews(int? id, EditNewsViewModel editNewsViewModel)
        {
            var news = _newsrepository.FindbyCondition(id);

            if (news == null)
            {
                return NotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    news.Id = editNewsViewModel.Id;
                    news.PageTtile = editNewsViewModel.PageTtile;
                    news.Title = editNewsViewModel.Title;
                    news.ShortDescription = editNewsViewModel.ShortDescription;
                    news.Body = editNewsViewModel.Body;
                    news.DatePublished = DateTime.Now;
                    if(editNewsViewModel.ImagePath != null)
                    {
                        news.ImagePath = await FileManager.UpdateImage(editNewsViewModel.ExistingImagePath, editNewsViewModel.ImagePath);
                    }
                    else
                    {
                        news.ImagePath = editNewsViewModel.ExistingImagePath;
                    }
                    _newsrepository.Update(news);
                    _newsrepository.Save();
                    return RedirectToAction(nameof(ListNews));
                }
            }
            return View(editNewsViewModel);
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
            var dailyview = dailyviewrepository.FindbyCondition(id);
            var model = new EditDailyView
            {
                Id = dailyview.Id,
                Body = dailyview.Body
            };
            return View(model);
        }
        [HttpPost("EditDailyView")]
        [Route("EditDailyView")]
        public IActionResult EditDailyView(int? id, EditDailyView editDailyView)
        {
            var dailyview = dailyviewrepository.FindbyCondition(id);

            if (dailyview == null)
            {
                return NotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    dailyview.Id = editDailyView.Id;
                    dailyview.Body = editDailyView.Body;
                  
                    dailyviewrepository.Update(dailyview);
                    _newsrepository.Save();
                    return RedirectToAction(nameof(GetDailyView));
                }
            }
            return View(editDailyView);
        }

        [HttpGet]
        [Route("GetDailyView")]
        public IActionResult GetDailyView()
        {
            var model = _newsrepository.GetDailyViewModel();
            return View(model);
        }
        #endregion

        //#region ProjectGallery

        [HttpGet]
        [Route("ProjectImages")]

        public IActionResult ProjectImages()
        {
            return View();
        }

        [HttpPost]
        [Route("ProjectImages")]

        public async Task<IActionResult> ProjectImages(CreateProjectImagesModel createProjectImages)
        {
            if (ModelState.IsValid)
            {
                var model = new ProjectGallery()
                {
                    ImageTitle = createProjectImages.ImageTitle,
                    ImagePath = await FileManager.SaveImage(createProjectImages.ImagePath),
                    DatePublished = DateTime.Now
                };
                _gelleryrepository.Create(model);
                _gelleryrepository.Save();
                return RedirectToAction(nameof(ListProjectPhotos));
            }
            return View(createProjectImages);
        }
   

        [HttpPost]
        [Route("DeleteProjectImages")]

        public JsonResult DeleteProjectImages(int Id)
        {
            var newmodel = _gelleryrepository.FindbyCondition(Id);
            try
            {
                _gelleryrepository.Delete(Id, newmodel.ImagePath);
                _gelleryrepository.Save();

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return Json("Couldn't Delete this Project Image");
            }

            logger.LogInformation("Successfully Deleted ");

            return Json(new { Status = "Successfully Deleted" });

        }

        [HttpGet]
        [Route("EditProjectImages")]
        public IActionResult EditProjectImages(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var projectimages = _gelleryrepository.FindbyCondition(id);
            var model = new EditProjectImages
            {
                Id = projectimages.Id,
                ImageTitle = projectimages.ImageTitle,
                ExistingImagePath = projectimages.ImagePath
            };
            return View(model);
        }
        [HttpPost("EditProjectImages")]
        [Route("EditProjectImages")]
        public async Task<IActionResult> EditProjectImages(int? id, EditProjectImages editProjectImages)
        {
            var projectgallery = _gelleryrepository.FindbyCondition(id);

            if (projectgallery == null)
            {
                return NotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    projectgallery.Id = editProjectImages.Id;
                    projectgallery.ImageTitle = editProjectImages.ImageTitle;
                    if(editProjectImages.ImagePath == null)
                    {
                        projectgallery.ImagePath = editProjectImages.ExistingImagePath;
                    }
                    else
                    {
                        projectgallery.ImagePath = await FileManager.UpdateImage(editProjectImages.ExistingImagePath, editProjectImages.ImagePath);
                    };
                    _gelleryrepository.Update(projectgallery);
                    _newsrepository.Save();
                    return RedirectToAction(nameof(ListProjectPhotos));
                }
            }
            return View(editProjectImages);
        }

        //#endregion
    }
}