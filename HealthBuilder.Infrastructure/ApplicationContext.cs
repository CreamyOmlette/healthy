using System.Reflection;
using HealthBuilder.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthBuilder.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<ScheduledActivity> ScheduledActivities { get; set; }
        
        public DbSet<ScheduledRoutine> ScheduledRoutines { get; set; }
        
        public DbSet<ScheduledMeal> ScheduledMeals { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Muscle> Muscles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<ScheduledMeal>().ToTable("ScheduledMeal");
            builder.Entity<ScheduledRoutine>().ToTable("ScheduledRoutine");
        }
    }
}