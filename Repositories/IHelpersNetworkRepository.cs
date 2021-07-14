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
        T FindbyCondition(int? id);

        List<T> Read();

        IOrderedQueryable<HelpersNetworkBranchesTb> ReadBranch();

        IOrderedQueryable<NewsModel> ReadNews();
        IOrderedQueryable<ProjectGallery> ReadProjectImages();

        IOrderedQueryable<CommunityLatestProject> ReadProjectVideos();
        void Delete(int? Id);
        void Delete(int? Id,string imagepath);

        void Save();
        void Update(T eventModel);
        DailyViewModel GetDailyViewModel();

        public Task<YouTubeVideoDetails> GetVideoDetails(string searchid);
        //void EditDailyViewModel(DailyViewModel dailyViewModel);
    }
    //public interface IHelpersNetworkEventRepository
    // {
    //     void Create(EventModel eventModel);
    //     EventModel FindEventByCondition(int? id);
    //     News FindNewsByCondition(int? id);
    //     List<EventModel> Read();
    //     EventModel Delete(int Id);
    //     News DeleteNews(int Id);
    //     EventModel Update(EventModel eventModel);
    //     DailyViewModel GetDailyViewModel();
    //     List<News> GetNewsModel();

    //     DailyViewModel GetDailyViewModelByCondition(int? id);
    //     News GetNewsByCondition(int? id);
    //     void CreateNews(News news);

    //     void EditDailyViewModel(DailyViewModel dailyViewModel);
    // }
}
