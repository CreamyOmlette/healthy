using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Repositories.Contracts
{
    public interface IScheduledRoutineRepository
    {
        Task<IEnumerable<ScheduledRoutineDto>> GetScheduledRoutinesAsync(int userId);
        Task<ScheduledRoutineDto> ScheduleRoutineAsync(int userId, int routineId, DateTime date);
        Task RemoveScheduledRoutine(int scheduledRoutineId);
    }
}