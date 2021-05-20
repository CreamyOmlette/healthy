using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Repositories.Contracts;

namespace HealthBuilder.Repositories
{
    public class ScheduledActivityRepository<TEntity> :
        Repository<TEntity>, IScheduledActivityRepository where TEntity : ScheduledActivity
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public ScheduledActivityRepository(ApplicationContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> IfValid(int userId, int activityId)
        {
            var result = (await GetAllAsync())
                .Any(e => e.UserId == userId && e.Id == activityId);
            return result;
        }

        public async Task RemoveScheduledActivity(int activityId)
        {
            var activity = await GetByIdAsync(activityId);
            if (activity == null)
            {
                return;
            }
            
            _context.ScheduledActivities.Remove(activity);
            await _context.SaveChangesAsync();
        }

        public async Task<ScheduledActivityDto> GetById(int activityId)
        {
            var activity = await GetByIdAsync(activityId);
            var dto = _mapper.Map<ScheduledActivityDto>(activity);
            return dto;
        }

        public async Task<ScheduledActivityDto> UpdateStatus(int activityId, bool status)
        {
            var activity = await GetByIdAsync(activityId);
            activity.Status = status;
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<ScheduledActivityDto>(activity);
            return dto;
        }
    }
}