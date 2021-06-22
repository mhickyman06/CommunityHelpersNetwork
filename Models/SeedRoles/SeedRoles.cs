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
        private readonly RoleManager<IdentityRole> _schAppRoleTab;
        public RolesSeeder(HelpersNetworkIdentityDbContext context,
            RoleManager<IdentityRole> schAppRoleTab,
            UserManager<ApplicationUser> _usermanager)
        {
            this.userManager = _usermanager;
            this.context = context;
            _schAppRoleTab = schAppRoleTab;
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
                    UserName = "SystemAdmin101",
                    Name = "System Administrator",
                    Age = "21",
                    Gender = "Male",
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
                    UserName = "Admin",
                    Name = "Admin101",
                    Age = "40",
                    Gender= "Male",
                    //AccountRole = "Admin",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, "mikel123");
                await userManager.AddToRoleAsync(user, ConstantRoles.Admin);
            }
        }
    }
}
