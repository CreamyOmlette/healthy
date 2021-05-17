using System;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure;
using HealthBuilder.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HealthBuilder.Repositories
{
    public class ScheduledActivityRepository : Repository<ScheduledActivity>, IScheduledActivityRepository
    {
        private readonly ApplicationContext _context;
        public ScheduledActivityRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> ifExists(int userId, int activityId)
        {
            var result = await _context
                .ScheduledActivities
                .AnyAsync(e => e.UserId == userId && e.Id == activityId);
            return result;
        }

        public async Task Remove(int activityId)
        {
            var activity = await _context
                .ScheduledActivities
                .FirstOrDefaultAsync(e => e.Id == activityId);
            if (activity == null)
            {
                throw new ArithmeticException("Activity not found");
            }
            _context.ScheduledActivities.Remove(activity);
            await _context.SaveChangesAsync();
        }
    }
}