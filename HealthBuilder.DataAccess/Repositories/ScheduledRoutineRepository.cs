using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ScheduledRoutineRepository: Repository<ScheduledRoutine>, IScheduledRoutineRepository
    {
        private readonly DbSet<ScheduledRoutine> _set;
        private readonly DbContext _context;
        public ScheduledRoutineRepository(DbContext context) : base(context)
        {
            _context = context;
            _set = context.Set<ScheduledRoutine>();
        }

        public async Task<IEnumerable<ScheduledRoutine>> GetScheduledRoutinesAsync(int userId)
        {
            return await _set.Where(e => e.Id == userId).Include(e => e.Routine).ToListAsync();
        }

        public async Task<ScheduledRoutine> ScheduleRoutineAsync(int userId, int routineId, DateTime date)
        {
            var routine = await _context.Set<Routine>().FirstOrDefaultAsync(e => e.Id == routineId);
            var result = new ScheduledRoutine
            {
                UserId = userId,
                RoutineId = routineId,
                Date = date
            };
            await _set.AddAsync(result);
            return result;
        }

        public void RemoveScheduledRoutine(int scheduledRoutineId)
        {
            var routine = _set.FirstOrDefault(e => e.Id == scheduledRoutineId);
            if (routine != null)
            {
                _set.Remove(routine);
            }
        }

        public new async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}