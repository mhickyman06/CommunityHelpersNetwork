using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HelpersNetwork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpersNetwork.Models.SeedRoles;
using HelpersNetwork.Models;

namespace StudentProject.Models.SeedRoles
{
    public class RolesSeeder
    {
        private HelpersNetworkIdentityDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHelpersNetworkRepository<NewsModel> newsrepository;
        private readonly IHelpersNetworkRepository<CommunityLatestProject> videorepository;
        private readonly RoleManager<IdentityRole> _schAppRoleTab;
        public RolesSeeder(HelpersNetworkIdentityDbContext context,
            RoleManager<IdentityRole> schAppRoleTab,
            UserManager<ApplicationUser> _usermanager,
            IHelpersNetworkRepository<NewsModel> newsrepository,
            IHelpersNetworkRepository<CommunityLatestProject> videorepository)
        {
            this.userManager = _usermanager;
            this.newsrepository = newsrepository;
            this.videorepository = videorepository;
            this.context = context;
            _schAppRoleTab = schAppRoleTab;
        }

        public void SeedYoutubeVideo()
        {
            var video = videorepository.Read();
            if(video == null)
            {
                var model1 = new CommunityLatestProject
                {
                    VideoUrl = "https://youtu.be/QnYTp-2KS2A",
                    VideoId = "QnYTp-2KS2A"
                };
                videorepository.Create(model1);

                var model2 = new CommunityLatestProject
                {
                    VideoUrl = "https://youtu.be/wC3IPsurFoc",
                    VideoId = "wC3IPsurFoc"
                };
                videorepository.Create(model2);

                videorepository.Save();
            }
        }

        public void SeedNews()
        {
            var news = newsrepository.ReadNews();
            if(news == null)
            {
                var model1 = new NewsModel
                {
                    DatePublished = DateTime.Now,
                    Title = "ovalshape nigeria presents moringa tea",
                    PageTtile = "ovalshape moringa tea",
                    ImagePath = "abfd6090-49a1-43b1-b5de-64d913a215d7HelpersHeadImage.jpg",
                    ShortDescription = "community helpers network is a faith based non-governmental organisation that takes the light of the church ",
                    Body = "community helpers network is a faith based non-governmental organisation that takes the " +
                        "  light of the church to the community for human capacity and infrastructure development." +
                        " we also bring the community back to the church for personal and spiritual developments and interventions.",
                };

                newsrepository.Create(model1);

                var model2 = new NewsModel
                {
                    DatePublished = DateTime.Now,
                    Title = "ovalshape nigeria presents moringa tea",
                    PageTtile = "ovalshape moringa tea",
                    ImagePath = "0b31e854-744d-4f47-ae88-5c3dd82cd36eHelpersHeadImage.jpg",
                    ShortDescription = "community helpers network is a faith based non-governmental organisation that takes the light of the church ",
                    Body = "community helpers network is a faith based non-governmental organisation that takes the " +
                       "  light of the church to the community for human capacity and infrastructure development." +
                       " we also bring the community back to the church for personal and spiritual developments and interventions.",
                };

                newsrepository.Create(model2);

                var model3 = new NewsModel
                {
                    DatePublished = DateTime.Now,
                    Title = "ovalshape nigeria presents moringa tea",
                    PageTtile = "ovalshape moringa tea",
                    ImagePath = "93fbd78a-5d60-46af-9d77-276c7727360dcharity-logo-with-human-icons_1025-131.jpg",
                    ShortDescription = "community helpers network is a faith based non-governmental organisation that takes the light of the church ",
                    Body = "community helpers network is a faith based non-governmental organisation that takes the " +
                      "  light of the church to the community for human capacity and infrastructure development." +
                      " we also bring the community back to the church for personal and spiritual developments and interventions.",
                };

                newsrepository.Create(model3);
                newsrepository.Save();
            }
        }
        public async Task SeedRole()
        {
            var roleStore = new RoleStore<IdentityRole>(context);

            #region system administrator Role
            if (!context.Roles.Any(r => r.Name == ConstantRoles.SystemAdministrator))
            {
                var role = new IdentityRole()
                {
                   
                    Name = ConstantRoles.SystemAdministrator.ToString().Trim()
                };

                await _schAppRoleTab.CreateAsync(role);
            }

            #endregion

            #region Admin Role
            if (!context.Roles.Any(r => r.Name == ConstantRoles.Admin))
            {
                var role = new IdentityRole()
                {
                    Name = ConstantRoles.Admin.ToString().Trim()
                };

                await _schAppRoleTab.CreateAsync(role);
            }

            #endregion

            #region user Role
            if (!context.Roles.Any(r => r.Name == ConstantRoles.User))
            {
                var role = new IdentityRole()
                {
                    Name = ConstantRoles.User.ToString().Trim()
                };

                await _schAppRoleTab.CreateAsync(role);
            }
            #endregion
            var getsystemadmin = await userManager.FindByEmailAsync("michealmadu73@gmail.com");
            if (getsystemadmin == null)
            {
                var user = new ApplicationUser
                {
                    Email = "michealmadu73@gmail.com",
                    UserName = "michealmadu73@gmail.com",
                    Name = "System Administrator",
                    Age = "21",
                    Gender = "Male",
                    PhoneNumber = "08057012064",
                    Religion = "Christain",
                    //AccountRole = "Admin",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, "mikel123");
                await userManager.AddToRoleAsync(user, ConstantRoles.SystemAdministrator);
            }

            var getAdmin = await userManager.FindByEmailAsync("femisomade@gmail.com");
            if (getAdmin == null)
            {
                var user = new ApplicationUser
                {
                    Email = "femisomade@gmail.com",
                    UserName = "femisomade@gmail.com",
                    Name = "Admin101",
                    Age = "40",
                    Gender= "Male",
                    Religion = "Christain",
                    //AccountRole = "Admin",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, "mikel123");
                await userManager.AddToRoleAsync(user, ConstantRoles.Admin);
            }
            #region Seeding DailyView
            var dailyview = context.DailyViewModels.FirstOrDefault();
            if(dailyview == null)
            {
                var model = new DailyViewModel
                {
                    Body = "Welcome to Community Helpers Network Website"
                };

                 context.DailyViewModels.Add(model);
                 await context.SaveChangesAsync();
            }
            #endregion
        }


    }
}
