using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Repositories.Contracts
{
    public interface IScheduledMealRepository
    {
        Task<IEnumerable<ScheduledMealDto>> GetScheduledMealsAsync(int userId);
        Task<ScheduledMealDto> ScheduleMeal(int userId, int mealId, DateTime date);
        Task RemoveScheduledMeal(int userId, int scheduledMealId);
    }
}