using System;
using System.Collections.Generic;
using HelpersNetwork.Models;
using ReflectionIT.Mvc.Paging;

namespace HelpersNetwork.ViewModels
{
    public class NewsViewModel
    {
        public PagingList<NewsModel> newsModel { get; set; }

        public List<YouTubeVideoDetails> ProjectVideosmodel { get; set; }


    }
}