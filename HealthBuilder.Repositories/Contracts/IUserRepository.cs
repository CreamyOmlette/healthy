using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Repositories.Contracts
{
    public interface IUserRepository
    {
        public Task<UserDto> ChangeUser(int id, string password = null, int height = 0, int weight = 0);
        public Task<UserDto> CreateUser(UserDto userDto);
        public Task<bool> CheckUsername(string username);
        public Task<UserDto> GetUser(int id);
        public Task DeleteUser(int id);
    }
}