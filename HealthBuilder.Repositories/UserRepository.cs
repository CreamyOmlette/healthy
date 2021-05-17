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

        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var addedUser = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<UserDto>(addedUser.Entity);
            return dto;
        }

        public async Task<UserDto> ChangeUser(int id, string password = null, int height = 0, int weight = 0)
        {
            var user = await GetByIdAsync(id);
            if (password != null)
            {
                user.Password = password;
            }
            if (height != 0)
            {
                user.Height = height;
            }
            if (weight != 0)
            {
                user.Weight = weight;
            }
            
            var userDto = _mapper.Map<UserDto>(user);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return userDto;
        }

        public async Task<bool> CheckUsername(string username)
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