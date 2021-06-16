using HelpersNetwork.Data;
using HelpersNetwork.Views.Home;
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
    public class HelpersNetworkEventRepository : IHelpersNetworkEventRepository
    {
        public HelpersNetworkEventRepository(HelpersNetworkDbContext context)
        {
            Context = context;
        }

        private readonly HelpersNetworkDbContext Context;

        public void Create(EventModel eventModel)
        {
            Context.EventModels.Add(eventModel);
            Context.SaveChanges();
        }

        public EventModel Delete(int Id)
        {
            var EvementModel = Context.EventModels.Find(Id);
             Context.EventModels.Remove(EvementModel);
            Context.SaveChanges();
            return EvementModel;

        }
       



        public List<EventModel> Read()
        {
            return Context.EventModels.ToList();   
        }

        public EventModel Update(EventModel eventModel)
        {
            var EventModel = Context.EventModels.Find(eventModel.Id);
           Context.EventModels.Update(EventModel);
            Context.SaveChanges();
            return EventModel;
          
        }

       public DailyViewModel GetDailyViewModel()
        {
            return Context.DailyViewModels.FirstOrDefault();
        }

        public EventModel FindEventByCondition(int? id)
        {
            var model = Context.EventModels.FirstOrDefault(p => p.Id == id);
            return model;
        }
        public News FindNewsByCondition(int? id)
        {
            var model = Context.News.FirstOrDefault(p => p.Id == id);
            return model;
        }

        public void EditDailyViewModel(DailyViewModel dailyViewModel)
        {
            //DateTime date = new DateTime();
            //date.ToString();
            //DateTime dateStart = DateTime.Now.AddDays(-3);
            //DateTime dateEnd = DateTime.Now.AddDays(1).AddTicks(-1);
            //Context.EventModels.Where(x => (DbFunction);
            Context.DailyViewModels.Update(dailyViewModel);
            Context.SaveChanges();
        }

        public DailyViewModel GetDailyViewModelByCondition(int? id)
        {
            var model = Context.DailyViewModels.FirstOrDefault(p => p.Id == id);
            return model;
        }

        public void CreateNews(News news)
        {
            Context.News.Add(news);
            Context.SaveChanges();
        }

        public List<News> GetNewsModel()
        {
            return Context.News.ToList();
        }

        public News GetNewsByCondition(int? id)
        {
            return Context.News.Where(x => x.Id == id).FirstOrDefault();
        }

        public News DeleteNews(int Id)
        {
            var model = Context.News.Find(Id);
            Context.News.Remove(model);
            Context.SaveChanges();
            return model;
        }
    }
}
