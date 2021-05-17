using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Services.Dtos;

namespace HealthBuilder.Services.Contracts
{
    public interface IUserService
    {
        public Task<UserDto> RegisterUser(UserDto userDto);
        public Task<UserDto> GetUserById(int userId);
    }
}