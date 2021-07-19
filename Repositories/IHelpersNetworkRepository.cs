using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.Models
{
    public delegate void OrderingFormat();
    public interface IHelpersNetworkRepository<T> where T: class
    {
        void Create(T model);
        T FindbyCondition(Guid id);

        List<T> Read();

        IOrderedQueryable<HelpersNetworkBranchesTb> ReadBranch();

        IOrderedQueryable<NewsModel> ReadNews();
        IOrderedQueryable<ProjectGallery> ReadProjectImages();

        IOrderedQueryable<CommunityLatestProject> ReadProjectVideos();
        void Delete(Guid Id);
        void Delete(Guid Id,string imagepath);

        void Save();
        void Update(T eventModel);
        DailyViewModel GetDailyViewModel();

        public Task<YouTubeVideoDetails> GetVideoDetails(string searchid);
    }
}
