using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Services.Dtos;

namespace HealthBuilder.Services.Contracts
{
    public interface ISchedulingService
    {
        public Task<ScheduledRoutineDto> ScheduleRoutine(int userId, int routineId, DateTime date);
        public Task<ScheduledMealDto> ScheduleMeal(int userId, int mealId, DateTime date);
        public Task RemoveScheduledActivity(int userId, int activityId);
        public Task<IEnumerable<ScheduledMealDto>> GetAllScheduledMeals(int userId);
        public Task<IEnumerable<ScheduledRoutineDto>> GetAllScheduledRoutines(int userId);

    }
}