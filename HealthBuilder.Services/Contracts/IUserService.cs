using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Services.Contracts
{
    public interface IUserService
    {
        public Task<UserDto> RegisterUser(UserDto userDto);
        public Task<UserDto> GetUserById(int id);
        public Task<UserDto> ChangeUser(int id, string password = null, int height = 0, int weight = 0);
        public Task DeleteUser(int id);
    }
}