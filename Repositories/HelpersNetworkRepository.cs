﻿using HelpersNetwork.Data;
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
        private DbSet<T> table = null;
        public HelpersNetworkRepository(HelpersNetworkIdentityDbContext context)
        {
            this._context = context;
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

        public void EditDailyViewModel(DailyViewModel dailyViewModel)
        {
            _context.DailyViewModels.Attach(dailyViewModel);
            _context.Entry(dailyViewModel).State = EntityState.Modified;

        }

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

        public void Update(T model)
        {
            table.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

    //public class HelpersNetworkEventRepository : IHelpersNetworkEventRepository
    //{
    //    public HelpersNetworkEventRepository(HelpersNetworkIdentityDbContext context)
    //    {
    //        Context = context;
    //    }

    //    private readonly HelpersNetworkIdentityDbContext Context;

    //    public void Create(EventModel eventModel)
    //    {
    //        Context.EventModels.Add(eventModel);
    //        Context.SaveChanges();
    //    }

    //    public EventModel Delete(int Id)
    //    {

    //        var EvementModel = Context.EventModels.Find(Id);
    //         Context.EventModels.Remove(EvementModel);
    //        Context.SaveChanges();
    //        return EvementModel;

    //    }




    //    public List<EventModel> Read()
    //    {
    //        return Context.EventModels.ToList();   
    //    }

    //    public EventModel Update(EventModel eventModel)
    //    {
    //        var EventModel = Context.EventModels.Find(eventModel.Id);
    //       Context.EventModels.Update(EventModel);
    //        Context.SaveChanges();
    //        return EventModel;

    //    }

    //   public DailyViewModel GetDailyViewModel()
    //    {
    //        return Context.DailyViewModels.FirstOrDefault();
    //    }

    //    public EventModel FindEventByCondition(int? id)
    //    {
    //        var model = Context.EventModels.FirstOrDefault(p => p.Id == id);
    //        return model;
    //    }
    //    public News FindNewsByCondition(int? id)
    //    {
    //        var model = Context.News.FirstOrDefault(p => p.Id == id);
    //        return model;
    //    }

    //    public void EditDailyViewModel(DailyViewModel dailyViewModel)
    //    {

    //        Context.DailyViewModels.Update(dailyViewModel);
    //        Context.SaveChanges();
    //    }

    //    public DailyViewModel GetDailyViewModelByCondition(int? id)
    //    {
    //        var model = Context.DailyViewModels.FirstOrDefault(p => p.Id == id);
    //        return model;
    //    }

    //    public void CreateNews(News news)
    //    {
    //        Context.News.Add(news);
    //        Context.SaveChanges();
    //    }

    //    public List<News> GetNewsModel()
    //    {
    //        return Context.News.ToList();
    //    }

    //    public News GetNewsByCondition(int? id)
    //    {
    //        return Context.News.Where(x => x.Id == id).FirstOrDefault();
    //    }

    //    public News DeleteNews(int Id)
    //    {
    //        var model = Context.News.Find(Id);
    //        Context.News.Remove(model);
    //        Context.SaveChanges();
    //        return model;
    //    }
    //}
}
