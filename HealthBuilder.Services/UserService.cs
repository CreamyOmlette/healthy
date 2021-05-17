using System;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Repositories.Contracts;
using HealthBuilder.Services.Contracts;

namespace HealthBuilder.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> RegisterUser(UserDto userDto)
        {
            var usernameValid = await _userRepository.CheckUsername(userDto.Username);
            if (!usernameValid)
            {
                return null;
            }
            var result = await _userRepository.CreateUser(userDto);
            return result;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
            {
                throw new ArgumentException("User Id not found");
            }
            var dto = _mapper.Map<UserDto>(user);
            return dto;
        }

        public async Task<UserDto> ChangeUser(int id, string password = null, int height = 0, int weight = 0)
        {
            var result = await _userRepository.ChangeUser(id, password, height, weight);
            return result;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            await _userRepository.DeleteUser(id);
        }
    }
    
}