//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using HelpersNetwork.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using HelpersNetwork.Models.SeedRoles;
//using HelpersNetwork.Models;

//namespace StudentProject.Models.SeedRoles
//{
//    public class RolesSeeder
//    {
//        private HelpersNetworkIdentityDbContext context;
//        private readonly UserManager<ApplicationUser> userManager;
//        private readonly HelpersNetworkIdentityDbContext schAppContext;
//        private readonly RoleManager<IdentityRole> _schAppRoleTab;
//        public RolesSeeder(HelpersNetworkIdentityDbContext schAppContext,
//            RoleManager<IdentityRole> schAppRoleTab,
//            UserManager<ApplicationUser> schAppUserManager)
//        {
//            this.context = schAppContext;
//            this.schAppContext = schAppContext;
//            _schAppRoleTab = schAppRoleTab;
//        }
//        public async Task SeedRole()
//        {
//            var roleStore = new RoleStore<IdentityRole>(context);
//            #region Admin Role
//            if (!context.Roles.Any(r => r.Name == ConstantRoles.Admin))
//            {
//                var role = new IdentityRole()
//                {
//                    Id = "Admin001",
//                    Name = ConstantRoles.Admin.ToString().Trim()
//                };

//                await _schAppRoleTab.CreateAsync(role);
//            }

//            #endregion

//            #region Spellers
//            if (!context.Roles.Any(r => r.Name == ConstantRoles.User))
//            {
//                var role = new IdentityRole()
//                {
//                    Id = "Spellers01",
//                    Name = ConstantRoles.User.ToString().Trim()
//                };
//                await _schAppRoleTab.CreateAsync(role);
//            }
//            #endregion


//            var getAdmin = await userManager.FindByEmailAsync("michealmadu73@gmail.com");
//            if (getAdmin == null)
//            {
//                var user = new ApplicationUser
//                {
//                    Id = "SystemAdmin101",
//                    Email = "michealmadu73@gmail.com",
//                    UserName = "Admin",
//                    Name = "System Administrator",
//                    //AccountRole = "Admin",
//                    EmailConfirmed = true
//                };
//                await userManager.CreateAsync(user, "Oj5!%hs17");
//                await userManager.AddToRoleAsync(user, ConstantRoles.Admin);
//            }
//        }
//    }
//}
