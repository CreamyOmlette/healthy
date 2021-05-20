using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Repositories.Contracts
{
    public interface IScheduledMealRepository : IScheduledActivityRepository
    {
        Task<IEnumerable<ScheduledMealDto>> GetAllScheduledMeals(int userId);
        Task<ScheduledMealDto> CreateScheduledMeal(int userId, int mealId, DateTime date);
        Task<ScheduledMealDto> GetScheduledMeal(int userId, int activityId);
    }
}