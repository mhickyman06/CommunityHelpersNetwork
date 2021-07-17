using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentProject.Models.SeedRoles;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelpersNetwork.Models.SeedRoles
{
    public class SetupIdentityDataSeeder : IHostedService
    {
        private readonly IServiceProvider serviceProvider;

        public SetupIdentityDataSeeder(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<RolesSeeder>();
                await seeder.SeedRole();
                seeder.SeedNews();
                seeder.SeedYoutubeVideo();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    }
}
