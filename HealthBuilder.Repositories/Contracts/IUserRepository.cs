using System;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Repositories.Contracts
{
    public interface IUserRepository
    {
        public Task<UserDto> UpdatePassword(int id, string password);
        public Task<UserDto> UpdateSpecification(int id, SpecificationDto specificationDto);
        public Task<UserDto> UpdateDoB(int id, DateTime dateOfBirth);
        public Task<UserDto> CreateUser(UserCreationDto userLiteDto);
        public Task<bool> IfValid(string username);
        public Task<UserDto> GetUser(int id);
        public Task DeleteUser(int id);
    }
}