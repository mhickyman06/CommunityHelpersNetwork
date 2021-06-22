using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpersNetwork.Data;
using HelpersNetwork.Models;
using HelpersNetwork.Models.SeedRoles;
using HelpersNetwork.Services;
using MailKit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using StudentProject.Models.SeedRoles;

namespace HelpersNetwork
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<HelpersNetworkDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("HelpersNetworkContextConnection")));

            services.AddDbContext<HelpersNetworkIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("HelpersNetworkContextConnection")));

            services.AddTransient<IHelpersNetworkRepository<EventModel>, HelpersNetworkRepository<EventModel>>();
            services.AddTransient<IHelpersNetworkRepository<News>, HelpersNetworkRepository<News>>();
            services.AddTransient<IHelpersNetworkRepository<ProjectGallery>, HelpersNetworkRepository<ProjectGallery>>();

            services.AddTransient<IFileManagerService, FileManagerService>();

            services.AddTransient<Services.IMailService, Services.MailService>();

            services.AddTransient<RolesSeeder>();

            services.AddHostedService<SetupIdentityDataSeeder>();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<HelpersNetworkIdentityDbContext>();

            //services.AddDefaultIdentity<HelpersNetworkUser>(options =>
            //{
            //    options.SignIn.RequireConfirmedAccount = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequiredUniqueChars = 0;

            //})
            //.AddEntityFrameworkStores<HelpersNetworkContext>();


            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPanel", policy => policy.RequireRole("Admin"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
