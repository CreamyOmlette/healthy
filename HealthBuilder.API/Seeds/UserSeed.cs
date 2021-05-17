using System;
using System.Linq;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure;

namespace HealthBuilder.API.Seeds
{
    public partial class Seed
    {
        public static async Task SeedUsers(ApplicationContext context)
        {
            if (!context.Users.Any())
            {
                var routines = context.Routines.ToList();
                var meals = context.Meals.ToList();
                var user = new User
                {
                    Username = "CreamyOmlette",
                    Height = 186,
                    Weight = 83,
                    Password = "022746598$Aa",
                    DoB = new DateTime(1999,6,18),
                };
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }
    }
}