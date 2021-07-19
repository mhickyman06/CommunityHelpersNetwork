using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpersNetwork.Data;
using HelpersNetwork.Logging;
using HelpersNetwork.Models;
using HelpersNetwork.Models.SeedRoles;
using HelpersNetwork.Services;
using MailKit;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ReflectionIT.Mvc.Paging;
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
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<HelpersNetworkDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("HelpersNetworkContextConnection")));

            services.AddDbContext<HelpersNetworkIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("HelpersNetworkContextConnection")));

            //services.AddTransient<IHelpersNetworkRepository<EventModel>, HelpersNetworkRepository<EventModel>>();
            services.AddTransient<IHelpersNetworkRepository<NewsModel>, HelpersNetworkRepository<NewsModel>>();
            services.AddTransient<IHelpersNetworkRepository<ProjectGallery>, HelpersNetworkRepository<ProjectGallery>>();
            services.AddTransient<IHelpersNetworkRepository<DailyViewModel>, HelpersNetworkRepository<DailyViewModel>>();
            services.AddTransient<IHelpersNetworkRepository<CommunityLatestProject>, HelpersNetworkRepository<CommunityLatestProject>>();
            services.AddTransient<IHelpersNetworkRepository<HelpersNetworkBranchesTb>, HelpersNetworkRepository<HelpersNetworkBranchesTb>>();
            services.AddTransient<IHelpersNetworkRepository<chnbankdetails>, HelpersNetworkRepository<chnbankdetails>>();

            services.AddTransient<IFileManagerService, FileManagerService>();

            services.AddTransient<Services.IMailService, Services.MailService>();

            services.AddSingleton<ILog, LogNLog>();

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


                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;
                // my Youtube api key<----> AIzaSyAwxnAxSvngDvA5-81Tze8iFHrZstoTsZY  <------->

            })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<HelpersNetworkIdentityDbContext>();

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
            opt.TokenLifespan = TimeSpan.FromMinutes(10));

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/api/Account/Login";
                options.AccessDeniedPath = "/api/Account/AccessDenied";
                options.Cookie.IsEssential = true;
                //options.SlidingExpiration = true;
                //options.ExpireTimeSpan = TimeSpan.FromSeconds(10);
            });          

           

            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPanel", policy => policy.RequireRole("Admin"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILog logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.ConfigureExcetionalHandler(logger);
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
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
            });
        }
    }
}
