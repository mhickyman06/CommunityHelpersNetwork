using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using HelpersNetwork.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;



namespace HelpersNetwork.Models
{
    public class HelpersNetworkRepository<T> : IHelpersNetworkRepository<T> where T : class
    {
        private HelpersNetworkIdentityDbContext _context;
        private readonly IFileManagerService fileManagerService;
        private DbSet<T> table = null;
        public HelpersNetworkRepository(HelpersNetworkIdentityDbContext context,
            IFileManagerService fileManagerService)
        {
            this._context = context;
            this.fileManagerService = fileManagerService;
            table = _context.Set<T>();
        }
        public void Create(T model)
        {
            table.Add(model);
        }

        public void Delete(int? Id)
        {
            T existing = table.Find(Id);
            table.Remove(existing);          
        }
        public void Delete(int? Id, string imagePath)
        {
            T existing = table.Find(Id);
            fileManagerService.DeleteImage(imagePath);
            table.Remove(existing);
        }

        //public void EditDailyViewModel(DailyViewModel dailyViewModel)
        //{
        //    _context.DailyViewModels.Attach(dailyViewModel);
        //    _context.Entry(dailyViewModel).State = EntityState.Modified;

        //}

        public T FindbyCondition(int? id)
        {
            return table.Find(id);
        }

        public DailyViewModel GetDailyViewModel()
        {
            return _context.DailyViewModels.FirstOrDefault();
        }

        public List<T> Read()
        {
            return table.ToList();
        }
        public IOrderedQueryable<HelpersNetworkBranchesTb> ReadBranch()
        {

            var query = _context.Branches.AsNoTracking().OrderByDescending(x => x.BranchName);
            return query;
        }
        public IOrderedQueryable<NewsModel> ReadNews()
        {

            var query = _context.News.AsNoTracking().OrderByDescending(x => x.DatePublished);
            return query;
        }
        public IOrderedQueryable<ProjectGallery> ReadProjectImages()
        {

            var query = _context.ProjectGalleries.AsNoTracking().OrderByDescending(x => x.DatePublished);
            return query;
        }
        public IOrderedQueryable<CommunityLatestProject> ReadProjectVideos()
        {

            var query = _context.communityLatestProjects.AsNoTracking().OrderByDescending(x => x.DatePublished);
            return query;
        }
        public void Update( T model)
        {
            table.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<YouTubeVideoDetails> GetVideoDetails(string searchid)
        {
            YouTubeVideoDetails videoDetails = null;
            using (var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAwxnAxSvngDvA5-81Tze8iFHrZstoTsZY",
            }))
            {
                var searchRequest = youtubeService.Videos.List("snippet");              
                searchRequest.Id = searchid;
                var searchResponse = await searchRequest.ExecuteAsync();

                var youTubeVideo = searchResponse.Items.FirstOrDefault();

                if (youTubeVideo != null)
                {

                    videoDetails = new YouTubeVideoDetails()
                    {
                        Description = youTubeVideo.Snippet.Description,
                        Title = youTubeVideo.Snippet.Title,
                        ChannelTitle = youTubeVideo.Snippet.ChannelTitle,
                        PublicationDate = youTubeVideo.Snippet.PublishedAt,
                        ThumbnailPath = youTubeVideo.Snippet.Thumbnails.Default__.Url
                    };
                }
            }
            return videoDetails;
        }
        public async Task<YouTubeVideoDetails> GetVideoDetails(string searchid,long  thumbnailwidth, long thumbnailheight)
        {
            YouTubeVideoDetails videoDetails = null;
            using (var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAwxnAxSvngDvA5-81Tze8iFHrZstoTsZY",
            }))
            {
                var searchRequest = youtubeService.Videos.List("snippet");
                searchRequest.Id = searchid;
                var searchResponse = await searchRequest.ExecuteAsync();

                var youTubeVideo = searchResponse.Items.FirstOrDefault();

                youTubeVideo.Snippet.Thumbnails.Default__.Width = thumbnailwidth;

                youTubeVideo.Snippet.Thumbnails.Default__.Height = thumbnailheight;

                if (youTubeVideo != null)
                {
                    videoDetails = new YouTubeVideoDetails()
                    {
                       
                        Description = youTubeVideo.Snippet.Description,
                        Title = youTubeVideo.Snippet.Title,
                        ChannelTitle = youTubeVideo.Snippet.ChannelTitle,
                        PublicationDate = youTubeVideo.Snippet.PublishedAt,
                        ThumbnailPath = youTubeVideo.Snippet.Thumbnails.Default__.Url

                    };
                }
            }
            return videoDetails;
        }
    } 
}

