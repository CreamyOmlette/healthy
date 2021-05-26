using System;
using System.Threading.Tasks;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Services.Contracts
{
    public interface IUserIdentityService
    {
        public Task<TokenDto> Login(LoginModel model);
        public Task<bool> Registration(RegistrationModel model);
        public Task RegisterAdmin(RegistrationModel model);
    }
}