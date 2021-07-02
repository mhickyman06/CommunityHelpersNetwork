using HelpersNetwork.Models;
using Microsoft.AspNetCore.Http;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.ViewModels
{
    public class HelpersNetworkViewModel
    {
        //public List<EventModel>? EventModels { get; set; }
        public DailyViewModel?   DailyViewModel { get; set; }
        public PagingList<NewsModel>? News { get; set; }
    }
}
