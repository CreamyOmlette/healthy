using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure;

namespace HealthBuilder.API.Seeds
{
    public partial class Seed
    {
        public static async Task SeedExercises(ApplicationContext context)
        {
            if (!context.Exercises.Any())
            {
                var muscles = context.Muscles.ToList();
                var exercises1 = new List<Exercise>
                {
                    new Exercise()
                    {
                        Name = "Warmup Run",
                        Intensity = 6,
                        Time = 60 * 15,
                        Description = "Run usually done to pump your heart before the actual action",
                        Muscles = new List<Muscle>{muscles[7], muscles[11]}
                    },
                    new Exercise()
                    {
                        Name = "Light Run",
                        Intensity = 4,
                        Time = 60 * 30,
                        Description = "Run that can that gets you calories burned and blood pumping",
                        Muscles = new List<Muscle>{muscles[7], muscles[11]}
                    },
                    new Exercise()
                    {
                        Name = "Sprint Run",
                        Intensity = 9,
                        Time = 60 * 10,
                        Description = "Running in short but fast bursts with 45 second duration",
                        Muscles = new List<Muscle>{muscles[7], muscles[11]}
                    },
                    new Exercise()
                    {
                        Name = "Crunches",
                        Intensity = 6,
                        Reps = 30,
                        Sets = 5,
                        Description =
                            "Ideal exercise to train your abs, lie on your back bring your calves to your butt and start raising your upper body",
                        Muscles = new List<Muscle>{muscles[11]}
                    },
                    new Exercise()
                    {
                        Name = "Push Up",
                        Intensity = 7,
                        Reps = 20,
                        Sets = 4,
                        Description =
                            "lie on the floor, then push your body up with your hands so that the only pivots connecting you to ground are your hands and your legs, ensure that you are in a correct position without any bends and start moving your body up and down",
                        Muscles = new List<Muscle>{muscles[8], muscles[9], muscles[10], muscles[2]}
                    },
                    new Exercise()
                    {
                        Name = "Pull Up",
                        Intensity = 8,
                        Reps = 8,
                        Sets = 4,
                        Description =
                            "hanging from the pull-up bar start pulling yourself up, endure that your elbows dont escape the 2d plane of the pull-up bar",
                        Muscles = new List<Muscle>{muscles[1], muscles[11], muscles[2]}
                    },
                    new Exercise()
                    {
                        Name = "Biceps Crunch",
                        Intensity = 4,
                        Reps = 10,
                        Sets = 4,
                        Description =
                            "take a dumbbell of your preferred mass and start doing crunches with your hands, ensure that you dont have complete rest during this exercise",
                        Muscles = new List<Muscle>{muscles[7], muscles[11]}
                    },
                    new Exercise()
                    {
                        Name = "Diamond Push Ups",
                        Intensity = 7,
                        Reps = 20,
                        Sets = 4,
                        Description =
                            "Same as normal push-up but you should position your hands as close to each other as possible",
                        Muscles = new List<Muscle>{muscles[2]}
                    },
                    new Exercise()
                    {
                        Name = "Squats",
                        Intensity = 6,
                        Reps = 20,
                        Sets = 4,
                        Description =
                            "Straighten your back and start moving your butt downwards while maintaining a straight position until you form 90 degree angle with your knees",
                        Muscles = new List<Muscle>{muscles[5], muscles[11], muscles[6]}
                    },
                    new Exercise()
                    {
                        Name = "Bench Press",
                        Intensity = 7,
                        Reps = 15,
                        Sets = 4,
                        Description =
                            "Choose a desired mass to put on your press, lie down and start slowly pushing the press up, maintain the form during this exercise",
                        Muscles = new List<Muscle>{muscles[8], muscles[10], muscles[9], muscles[3]}
                    },
                    new Exercise()
                    {
                        Name = "DeadLift",
                        Intensity = 6,
                        Reps = 10,
                        Sets = 4,
                        Description =
                            "Arguably the most traumatic exercise, put the barbell down, grab it with your hands, lift it with a straight back, put it down, repeat",
                        Muscles = new List<Muscle>{muscles[1], muscles[2], muscles[5], muscles[6]}
                    },
                    new Exercise()
                    {
                        Name = "Crawl Swimming",
                        Intensity = 7,
                        Time = 60 * 20,
                        Muscles = muscles
                    },
                    new Exercise()
                    {
                        Name = "Brass Swimming",
                        Intensity = 4,
                        Time = 60 * 20,
                        Muscles = muscles
                    },
                    new Exercise()
                    {
                        Name = "Butterfly Swimming",
                        Intensity = 8,
                        Time = 60 * 20,
                        Muscles = muscles
                    },
                    new Exercise()
                    {
                        Name = "Plank",
                        Intensity = 5,
                        Time = 2 * 60,
                        Muscles = new List<Muscle>{muscles[11]}
                    },
                    new Exercise()
                    {
                        Name = "Leg Lifting",
                        Intensity = 5,
                        Reps = 15,
                        Sets = 4,
                        Muscles = new List<Muscle>{muscles[11]}
                    },
                };
                await context.Exercises.AddRangeAsync(exercises1);
                await context.SaveChangesAsync();
                // var exercises = context.Exercises.ToList();
                // exercises[0].Muscles.AddRange(new List<Muscle>{muscles[7], muscles[11]});
                // exercises[1].Muscles.AddRange(new List<Muscle>{muscles[7], muscles[11]});
                // exercises[2].Muscles.AddRange(new List<Muscle>{muscles[7], muscles[11]});
                // exercises[3].Muscles.AddRange(new List<Muscle>{muscles[11]});
                // exercises[4].Muscles.AddRange(new List<Muscle>{muscles[8], muscles[9], muscles[10], muscles[2]});
                // exercises[5].Muscles.AddRange(new List<Muscle>{muscles[1], muscles[11], muscles[2]});
                // exercises[6].Muscles.AddRange(new List<Muscle>{muscles[7], muscles[11]});
                // exercises[7].Muscles.AddRange(new List<Muscle>{muscles[2]});
                // exercises[8].Muscles.AddRange(new List<Muscle>{muscles[3], muscles[9]});
                // exercises[9].Muscles.AddRange(new List<Muscle>{muscles[5], muscles[11], muscles[6]});
                // exercises[10].Muscles.AddRange(new List<Muscle>{muscles[8], muscles[10], muscles[9], muscles[3]});
                // exercises[11].Muscles.AddRange(new List<Muscle>{muscles[1], muscles[2], muscles[5], muscles[6]});
                // exercises[12].Muscles.AddRange(muscles);
                // exercises[13].Muscles.AddRange(muscles);
                // exercises[14].Muscles.AddRange(muscles);
                // exercises[15].Muscles.Add(muscles[11]);
                
            }
        }
    }
}