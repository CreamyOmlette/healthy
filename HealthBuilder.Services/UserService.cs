using System;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Repositories;
using HealthBuilder.Services.Contracts;
using HealthBuilder.Services.Dtos;

namespace HealthBuilder.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> RegisterUser(UserDto userDto)
        {
            var user = await _userRepository.SingleOrDefaultAsync(e => e.Username.Equals(userDto.Username));
            if (user != null)
            {
                throw new ArgumentException("Username already exists");
            }

            var newUser = new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                Height = userDto.Height,
                Weight = userDto.Weight,
                DoB = userDto.DoB
            };
            var result = await _userRepository.AddAsync(newUser);
            var dto = _mapper.Map<UserDto>(result);
            return dto;
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User Id not found");
            }

            var dto = _mapper.Map<UserDto>(user);
            return dto;
        }
    }
    
}