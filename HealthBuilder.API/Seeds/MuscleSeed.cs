using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure;

namespace HealthBuilder.API.Seeds
{
    public partial class Seed
    {
        public static async Task SeedMuscles(ApplicationContext context)
        {
            if (!context.Muscles.Any())
            {
                var muscles = new List<Muscle>
                {
                    new Muscle()
                    {
                        Name = "Lower Back",
                        Description =
                            "A set of muscles located on your lower back, are targeted when you are lifting something from the ground"
                    },
                    new Muscle()
                    {
                        Name = "Upper Back",
                        Description = "A set of muscles located on your upper back, are targeted when you lift yourself"
                    },
                    new Muscle()
                    {
                        Name = "Arm Biceps",
                        Description = "Muscle on your upper arm, is targeted when you make a negative motion"
                    },
                    new Muscle()
                    {
                        Name = "Arm Triceps",
                        Description = "Muscle on your upper arm, is target when you make a positive motion"
                    },
                    new Muscle()
                    {
                        Name = "forearm",
                        Description = "Muscle that's mainly responsible for gripping"
                    },
                    new Muscle()
                    {
                        Name = "Leg Biceps",
                        Description =
                            "Muscle on your upper leg, is targeted when you attempt negative motion with your legs"
                    },
                    new Muscle()
                    {
                        Name = "Leg Triceps",
                        Description =
                            "Muscle on your lower leg, is targeted when you attempt positive motion with your legs"
                    },
                    new Muscle()
                    {
                        Name = "Calves",
                        Description =
                            "Muscle on your lower leg, is responsible for stability and is targeted during such activities as running and jumping"
                    },
                    new Muscle()
                    {
                        Name = "Upper Pictorial",
                        Description =
                            "Pictorial muscles that are targeted when you lift something with a +45 degrees from your normal"
                    },
                    new Muscle()
                    {
                        Name = "Lower Pictorial",
                        Description =
                            "Pictorial muscles that are targeted when you lift something with a -45 degrees from your normal"
                    },
                    new Muscle()
                    {
                        Name = "Pictorial",
                        Description =
                            "Pictorial muscles that are targeted when you lift something with a 0 degrees from your normal"
                    },
                    new Muscle()
                    {
                        Name = "Abdominal",
                        Description = "Abdominal muscles are located in the core of your body"
                    }
                };
                await context.Muscles.AddRangeAsync(muscles);
                await context.SaveChangesAsync();
            }
        }
    }
}