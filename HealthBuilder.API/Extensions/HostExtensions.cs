using System;
using System.Threading.Tasks;
using HealthBuilder.API.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HealthBuilder.Infrastructure;

namespace HealthBuilder.API.Extensions
{
    public static class HostExtensions
    {
        public static async Task SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationContext>();
                    context.Database.Migrate();
                    await Seed.SeedMuscles(context);
                    await Seed.SeedMeals(context);
                    await Seed.SeedExercises(context);
                    await Seed.SeedRoutines(context);
                    await Seed.SeedUsers(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }
        }
    }
}