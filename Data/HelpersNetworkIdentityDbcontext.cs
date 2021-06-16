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
    }
}
