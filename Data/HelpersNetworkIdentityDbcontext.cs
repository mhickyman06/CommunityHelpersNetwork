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
        public DbSet<DailyViewModel> DailyViewModels { get; set; }
        public DbSet<NewsModel> News { get; set; }

        public DbSet<ProjectGallery> ProjectGalleries { get; set; }

        public DbSet<CommunityLatestProject> communityLatestProjects { get; set; }

        public DbSet<HelpersNetworkBranchesTb> Branches { get; set; }

        public DbSet<chnbankdetails> chnbankdetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.Entity<NewsModel>().HasData(
            //        new NewsModel
            //        {
            //            Id = 1,
            //            DatePublished = DateTime.Now,
            //            PageTtile = "ovalshape moringa tea",
            //            Title = "ovalshape nigeria presents moringa tea",
            //            ShortDescription = "community helpers network is a faith based non-governmental organisation that takes the light of the church ",
            //            Body = " community helpers network is a faith based non-governmental" +
            //            " organisation that takes the   light of the church to the community" +
            //            "for human capacity and infrastructure development. we also bring the" +
            //            " community back to the church for personal and spiritual developments and interventions.",
            //            ImagePath = "00000000-0000-0000-0000-000000000000helpersheadimage.jpg",
            //        },
            //          new NewsModel
            //          {
            //              Id = 2,
            //              DatePublished = DateTime.Now,
            //              PageTtile = "ovalshape moringa tea",
            //              Title = "ovalshape nigeria presents moringa tea",
            //              ShortDescription = "community helpers network is a faith based non-governmental organisation that takes the light of the church ",
            //              Body = " community helpers network is a faith based non-governmental" +
            //            " organisation that takes the   light of the church to the community" +
            //            "for human capacity and infrastructure development. we also bring the" +
            //            " community back to the church for personal and spiritual developments and interventions.",
            //              ImagePath = "00000000-0000-0000-0000-000000000000helpersheadimage.jpg"
            //          },
            //            new NewsModel
            //            {
            //                Id = 3,
            //                DatePublished = DateTime.Now,
            //                PageTtile = "ovalshape moringa tea",
            //                Title = "ovalshape nigeria presents moringa tea",
            //                ShortDescription = "community helpers network is a faith based non-governmental organisation that takes the light of the church ",
            //                Body = " community helpers network is a faith based non-governmental" +
            //            " organisation that takes the   light of the church to the community" +
            //            "for human capacity and infrastructure development. we also bring the" +
            //            " community back to the church for personal and spiritual developments and interventions.",
            //                ImagePath = "00000000-0000-0000-0000-000000000000helpersheadimage.jpg"
            //            }
            //    );

            //builder.Entity<ProjectGallery>().HasData(
            //        new ProjectGallery
            //        {
            //            Id = 1,
            //            DatePublished = DateTime.Now,
            //            ImageTitle = "Captured during meeting",
            //            ImagePath = "galery-img2.jpg",
            //        },
            //          new ProjectGallery
            //          {
            //              Id = 2,
            //              DatePublished = DateTime.Now,
            //              ImageTitle = "Captured during meeting",
            //              ImagePath = "galery-img3.jpg",
            //          },
            //            new ProjectGallery
            //            {
            //                Id = 3,
            //                DatePublished = DateTime.Now,
            //                ImageTitle = "Captured during meeting",
            //                ImagePath = "galery-img4.jpg",
            //            },
            //            new ProjectGallery
            //            {
            //                Id = 4,
            //                DatePublished = DateTime.Now,
            //                ImageTitle = "Captured during meeting",
            //                ImagePath = "galery-img5.jpg",
            //            },
            //            new ProjectGallery
            //            {
            //                Id = 5,
            //                DatePublished = DateTime.Now,
            //                ImageTitle = "Captured during meeting",
            //                ImagePath = "galery-img6.jpg",
            //            }
            //    );
           base.OnModelCreating(builder);
        }
    }
}

