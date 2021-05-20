using System;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Infrastructure.Exceptions;
using HealthBuilder.Repositories.Contracts;
using HealthBuilder.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace HealthBuilder.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<UserDto> RegisterUser(UserCreationDto userDto)
        {
            var usernameValid = await _userRepository.IfValid(userDto.Username);
            if (!usernameValid)
            {
                _logger.LogInformation("Error while registering a user");
                throw new InvalidUsernameException();
            }
            var result = await _userRepository.CreateUser(userDto);
            return result;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
            {
                _logger.LogInformation("Error while fetching a user");
                throw new Exception("User not found");
            }
            var dto = _mapper.Map<UserDto>(user);
            return dto;
        }

        public async Task<UserDto> UpdatePassword(int id, PasswordDto passwordDto)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
            {
                _logger.LogInformation("Error while updating user password");
                throw new UserNotFoundException();
            }

            var result = await _userRepository.UpdatePassword(id, passwordDto.Password);
            return result;
        }

        public async Task<UserDto> UpdateSpecification(int id, SpecificationDto specificationDto)
        {
            if (specificationDto.Height == null && specificationDto.Weight == null)
            {
                _logger.LogInformation("Error while updating user specification");
                throw new EmptySpecificationException();
            }
            
            var user = await _userRepository.GetUser(id);
            if (user == null)
            {
                _logger.LogInformation("Error while updating user specification");
                throw new UserNotFoundException();
            }

            var result = await _userRepository.UpdateSpecification(id, specificationDto);
            return result;
        }

        public async Task<UserDto> UpdateDateOfBirth(int id, DoBDto dateOfBirthDto)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
            {
                _logger.LogInformation("Error while updating users date of birth");
                throw new UserNotFoundException();
            }

            var result = await _userRepository.UpdateDoB(id, dateOfBirthDto.DoB);
            return result;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
            {
                    _logger.LogInformation("Error while deleting a user");
                    throw new UserNotFoundException();
            }
            
            await _userRepository.DeleteUser(id);
        }
    }
    
}