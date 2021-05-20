using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Repositories.Contracts
{
    public interface IScheduledRoutineRepository : IScheduledActivityRepository
    {
        Task<IEnumerable<ScheduledRoutineDto>> GetAllScheduledRoutines(int userId);
        Task<ScheduledRoutineDto> CreateScheduledRoutine(int userId, int routineId, DateTime date);
        Task<ScheduledRoutineDto> GetScheduledRoutine(int userId, int activityId);
    }
}