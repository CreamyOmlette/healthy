using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;

namespace HealthBuilder.Core.Repositories
{
    public interface IScheduledRoutineRepository : IRepository<ScheduledRoutine>
    {
        Task<IEnumerable<ScheduledRoutine>> GetScheduledRoutinesAsync(int userId);
        Task<ScheduledRoutine> ScheduleRoutineAsync(int userId, int routineId, DateTime date);
        void RemoveScheduledRoutine(int scheduledRoutineId);
        Task SaveChangesAsync();
    }
}