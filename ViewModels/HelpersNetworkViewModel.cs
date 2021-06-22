using HelpersNetwork.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.ViewModels
{
    public class HelpersNetworkViewModel
    {
        public List<EventModel>? EventModels { get; set; }
        public DailyViewModel?   DailyViewModel { get; set; }
        public List<News>? News { get; set; }
    }
}
