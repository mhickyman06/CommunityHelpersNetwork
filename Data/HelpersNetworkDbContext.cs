using HelpersNetwork;
using HelpersNetwork.Models;
using HelpersNetwork.Views.Home;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.Data
{
    public class HelpersNetworkDbContext : DbContext
    {
        public HelpersNetworkDbContext(DbContextOptions<HelpersNetworkDbContext> options):base(options)
        {

        }
        public DbSet<EventModel> EventModels { get; set; }
        public DbSet<DailyViewModel> DailyViewModels { get; set; }
        public DbSet<News> News { get; set; }
        //public DbSet<Comment> Comments { get; set; }

    }
}
