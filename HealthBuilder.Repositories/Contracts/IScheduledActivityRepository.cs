using System.Threading.Tasks;
using HealthBuilder.Core.Entities;

namespace HealthBuilder.Repositories.Contracts
{
    public interface IScheduledActivityRepository 
    {
        public Task<bool> ifExists(int userId, int activityId);
        public Task Remove(int activityId);
    }
}