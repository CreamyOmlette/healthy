using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Repositories.Contracts;

namespace HealthBuilder.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        
        public UserRepository(ApplicationContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> UpdatePassword(int id, string password)
        {
            var user = await GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            
            user.Password = password;
            _context.Update(user);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<UserDto>(user);
            return dto;
        }

        public async Task<UserDto> UpdateSpecification(int id, SpecificationDto specificationDto)
        {
            var user = await GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            if (specificationDto.Height != null)
            {
                user.Height = (int)specificationDto.Height;
            }

            if (specificationDto.Weight != null)
            {
                user.Weight = (int)specificationDto.Weight;
            }

            _context.Update(user);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<UserDto>(user);
            return dto;
        }

        public async Task<UserDto> UpdateDoB(int id, DateTime dateOfBirth)
        {
            var user = await GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            user.DoB = dateOfBirth;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UserDto> CreateUser(UserCreationDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var addedUser = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<UserDto>(addedUser.Entity);
            return dto;
        }

        public async Task<bool> IfValid(string username)
        {
            var valid = !(await GetAllAsync()).Any(e => e.Username.Equals(username));
            return valid;
        }

        public async Task<UserDto> GetUser(int id)
        {
            var user = await GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            
            var dto = _mapper.Map<UserDto>(user);
            return dto;
        }

        public async Task DeleteUser(int id)
        {
            var user = await GetByIdAsync(id);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}