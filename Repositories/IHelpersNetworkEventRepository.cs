using HelpersNetwork.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.Models
{
   public interface IHelpersNetworkEventRepository
    {
        void Create(EventModel eventModel);
        EventModel FindEventByCondition(int? id);
        News FindNewsByCondition(int? id);
        List<EventModel> Read();
        EventModel Delete(int Id);
        News DeleteNews(int Id);
        EventModel Update(EventModel eventModel);
        DailyViewModel GetDailyViewModel();
        List<News> GetNewsModel();

        DailyViewModel GetDailyViewModelByCondition(int? id);
        News GetNewsByCondition(int? id);
        void CreateNews(News news);

        void EditDailyViewModel(DailyViewModel dailyViewModel);
    }
}
