using HelpersNetwork.Models;
using HelpersNetwork.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Extensions;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HelpersNetwork.Controllers
{
   
    public class NewsController : Controller
    {
        private readonly IHelpersNetworkRepository<NewsModel> newsrepository;
        private readonly IHelpersNetworkRepository<CommunityLatestProject> projectvideorepository;

        public NewsController(IHelpersNetworkRepository<NewsModel> newsrepository,
            IHelpersNetworkRepository<CommunityLatestProject> projectvideorepository)
        {
            this.newsrepository = newsrepository;
            this.projectvideorepository = projectvideorepository;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var query = newsrepository.ReadNews();
            var videos = projectvideorepository.ReadProjectVideos();
            List<YouTubeVideoDetails> youtubevideo = new List<YouTubeVideoDetails>();
            foreach (var videodetails in videos)
            {
                var projectvideo = await projectvideorepository.GetVideoDetails(videodetails.VideoId);
                projectvideo.InbuiltId = videodetails.Id;
                projectvideo.VideoUrl = videodetails.VideoUrl;
                projectvideo.PublicationDate = Convert.ToDateTime(videodetails.DatePublished);
                youtubevideo.Add(projectvideo);
            }

            List<YouTubeVideoDetails> selectedvideos = new List<YouTubeVideoDetails>();
            var selected =  youtubevideo.GetRange(0, 2);
            selected.OrderByDescending(x => x.PublicationDate);
            var news = await PagingList.CreateAsync(query, 10, page);

            var model = new NewsViewModel
            {
                newsModel = news,
                ProjectVideosmodel = selected
            };
            return View(model);
        }

        public IActionResult NewsDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = newsrepository.FindbyCondition(id);
            return View(model);
        }
    }
}