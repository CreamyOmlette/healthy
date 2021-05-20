using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Repositories.Contracts
{
    public interface IScheduledActivityRepository
    {
        public Task<bool> IfValid(int userId, int activityId);
        public Task RemoveScheduledActivity(int activityId);
        public Task<ScheduledActivityDto> GetById(int activityId);
        public Task<ScheduledActivityDto> UpdateStatus(int activityId, bool status);
    }
}