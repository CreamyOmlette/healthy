using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure;

namespace HealthBuilder.API.Seeds
{
    public partial class Seed
    {
        public static async Task SeedRoutines(ApplicationContext context)
        {
            if (!context.Routines.Any())
            {
                var exercises = context.Exercises.ToList();
                var routines = new List<Routine>
                {
                    new Routine
                    {
                        Name = "Full Body Workout",
                        Difficulty = 8,
                        Description =
                            "A workout that is focusing on main muscles of your body, includes a warm-up to lessen the strain on individual joints during the exercises",
                        Exercises = new List<Exercise>{exercises[0], exercises[4], exercises[5], exercises[8], exercises[9]}
                    },
                    new Routine
                    {
                        Name = "Leg Day",
                        Difficulty = 9,
                        Description =
                            "The most fearsome workout day of the week. Not everybody likes it but its necessary",
                        Exercises = new List<Exercise>{exercises[8], exercises[0], exercises[10], exercises[15]}
                    },
                    new Routine
                    {
                        Name = "Arm Day",
                        Difficulty = 5,
                        Description =
                            "Includes various exercises to increase the performance of your biceps,triceps and make your arms look hell of strong",
                        Exercises = new List<Exercise>{exercises[3], exercises[4], exercises[6], exercises[7]}
                    },
                    new Routine
                    {
                        Name = "High Intensity Training",
                        Difficulty = 9,
                        Description =
                            "The training that's not going to leave you with more than 30 seconds of spare time, take a bucket because even the most experienced people are going to want to throw up",
                        Exercises = new List<Exercise>{exercises[0], exercises[3], exercises[4], exercises[14]}
                    },
                    new Routine{
                       Name = "Normal Swimming Session",
                       Difficulty = 7,
                       Description = "Normal swimmer workout, recommended distance 2km",
                       Exercises = new List<Exercise>{exercises[11], exercises[12], exercises[11]}
                }
                };
                await context.Routines.AddRangeAsync(routines);
                await context.SaveChangesAsync();
            }
        }
    }
}