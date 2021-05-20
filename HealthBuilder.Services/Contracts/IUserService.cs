using System.Threading.Tasks;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Services.Contracts
{
    public interface IUserService
    {
        public Task<UserDto> RegisterUser(UserCreationDto userDto);
        public Task<UserDto> GetUserById(int id);
        public Task<UserDto> UpdatePassword(int id, PasswordDto passwordDto);
        public Task<UserDto> UpdateSpecification(int id, SpecificationDto specificationDto);
        public Task<UserDto> UpdateDateOfBirth(int id, DoBDto dateOfBirth);
        public Task DeleteUser(int id);
    }
}