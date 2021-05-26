using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Infrastructure.Exceptions;
using HealthBuilder.Infrastructure.UserRoles;
using HealthBuilder.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


namespace HealthBuilder.Services
{
    public class UserIdentitySevice : IUserIdentityService
    {
        private readonly UserManager<UserIdentity> _userManager;  
        private readonly RoleManager<IdentityRole> _roleManager;  
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        
        public UserIdentitySevice(
            UserManager<UserIdentity> userManager, 
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IMapper mapper,
            ILogger<UserIdentitySevice> logger
            )  
        {  
            _userManager = userManager;  
            _roleManager = roleManager;  
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TokenDto> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return new TokenDto
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
            }

            return null;
        }

        public async Task<bool> Registration(RegistrationModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                throw new InvalidUsernameException();
            }

            UserIdentity user = new UserIdentity()  
            {  
                Email = model.Email,  
                SecurityStamp = Guid.NewGuid().ToString(),  
                UserName = model.Username,
            };  
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new ApplicationException(); // make meaningful
            return true;
        }

        public async Task RegisterAdmin(RegistrationModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                throw new InvalidUsernameException();  
  
            UserIdentity user = new UserIdentity()  
            {  
                Email = model.Email,  
                SecurityStamp = Guid.NewGuid().ToString(),  
                UserName = model.Username  
            };  
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new ApplicationException(); 
  
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))  
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));  
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))  
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));  
  
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))  
            {  
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);  
            }
        }
    }
}