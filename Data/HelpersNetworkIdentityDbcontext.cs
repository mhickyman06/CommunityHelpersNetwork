using HelpersNetwork.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
namespace HelpersNetwork.Data
{
    public class HelpersNetworkIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public HelpersNetworkIdentityDbContext(DbContextOptions<HelpersNetworkIdentityDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<EventModel> EventModels { get; set; }
        public DbSet<DailyViewModel> DailyViewModels { get; set; }
        public DbSet<News> News { get; set; }

        public DbSet<ProjectGallery> ProjectGalleries { get; set; }

        public DbSet<CommunityLatestProject> communityLatestProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<EventModel>().HasData(
                    new EventModel
                    {
                        Id = 1,
                        DatePublished = DateTime.Now,
                        PageTtile = "Ovalshape Moringa Tea",
                        Title = "Ovalshape Nigeria presents Moringa Tea",
                        ShortDescription = "Community Helpers Network is a faith based Non-Governmental Organisation that takes the light of the church ",
                        Body = " Community Helpers Network is a faith based Non-Governmental" +
                        " Organisation that takes the   light of the church to the community" +
                        "for human capacity and infrastructure development. We also bring the" +
                        " community back to the church for personal and spiritual developments and interventions.",
                        ImagePath = "00000000-0000-0000-0000-000000000000HelpersHeadImage.jpg"
                    },
                     new EventModel
                     {
                         Id = 2,
                         DatePublished = DateTime.Now,
                         PageTtile = "Ovalshape Moringa Tea",
                         Title = "Ovalshape Nigeria presents Moringa Tea",
                         ShortDescription = "Community Helpers Network is a faith based Non-Governmental Organisation that takes the light of the church ",
                         Body = " Community Helpers Network is a faith based Non-Governmental" +
                        " Organisation that takes the   light of the church to the community" +
                        "for human capacity and infrastructure development. We also bring the" +
                        " community back to the church for personal and spiritual developments and interventions.",
                         ImagePath = "00000000-0000-0000-0000-000000000000HelpersHeadImage.jpg"
                     },
                      new EventModel
                      {
                          Id= 3,
                          DatePublished = DateTime.Now,
                          PageTtile = "Ovalshape Moringa Tea",
                          Title = "Ovalshape Nigeria presents Moringa Tea",
                          ShortDescription = "Community Helpers Network is a faith based Non-Governmental Organisation that takes the light of the church ",
                          Body = " Community Helpers Network is a faith based Non-Governmental" +
                        " Organisation that takes the   light of the church to the community" +
                        "for human capacity and infrastructure development. We also bring the" +
                        " community back to the church for personal and spiritual developments and interventions.",
                          ImagePath = "00000000-0000-0000-0000-000000000000HelpersHeadImage.jpg"
                      }
                );
            builder.Entity<ProjectGallery>().HasData(
                    new ProjectGallery
                    {
                        Id = 1,
                        ImagePath = "galery-img2.jpg",
                        ImageTitle = "Capured  during the meeting",
                        DatePublished = DateTime.Now,                      
                    },
                     new ProjectGallery
                     {
                         Id = 2,
                         ImagePath = "galery-img3.jpg",
                         ImageTitle = "Capured  during the meeting",
                         DatePublished = DateTime.Now,
                     },
                      new ProjectGallery
                      {
                          Id = 3,
                          ImagePath = "galery-img5.jpg",
                          ImageTitle = "Capured  during the meeting",
                          DatePublished = DateTime.Now,
                      },
                       new ProjectGallery
                       {
                           Id = 4,
                           ImagePath = "galery-img6.jpg",
                           ImageTitle = "Capured  during the meeting",
                           DatePublished = DateTime.Now,
                       }
                ) ;
            base.OnModelCreating(builder);
        }
    }
  
}
