using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;

namespace HealthBuilder.Repositories
{
    public interface IScheduledMealRepository : IRepository<ScheduledMeal>
    {
        Task<IEnumerable<ScheduledMeal>> GetAllByUserAsync(int userId);
        Task<ScheduledMeal> ScheduleMeal(int userId, int mealId, DateTime date);
        void RemoveScheduledMeal(int userId, int scheduledMealId);
        Task SaveChangesAsync();
    }
}