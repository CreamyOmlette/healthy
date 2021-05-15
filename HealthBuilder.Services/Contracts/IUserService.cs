using System.Threading.Tasks;
using HealthBuilder.Core.Entities;

namespace HealthBuilder.Services.Contracts
{
    public interface IUserService
    {
        public Task<User> RegisterUser();
        public Task<User> GetUserById();
    }
}