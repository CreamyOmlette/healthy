using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;

namespace HealthBuilder.Services.Contracts
{
    public interface ISchedulingService
    {
        public Task<ScheduledRoutine> ScheduleRoutine(int userId, int routineId, DateTime date);
        public Task<ScheduledMeal> ScheduleMeal(int userId, int mealId, DateTime date);
        public Task RemoveScheduledActivity(int userId, int activityId);
        public Task<IEnumerable<ScheduledMeal>> GetAllScheduledMeals(int userId);
        public Task<IEnumerable<ScheduledRoutine>> GetAllScheduledRoutines(int userId);

    }
}