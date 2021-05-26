using Microsoft.AspNetCore.Http;  
using Microsoft.AspNetCore.Identity;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.Extensions.Configuration;  
using Microsoft.IdentityModel.Tokens;  
using System;  
using System.Collections.Generic;  
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;  
using System.Text;  
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Infrastructure.UserRoles;
using HealthBuilder.Services.Contracts;

namespace HealthBuilder.API
{  
    [Route("api/[controller]")]  
    [ApiController]  
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserIdentityService _identityService;
  
        public AuthenticateController(IUserIdentityService identityService)
        {
            _identityService = identityService;
        }  
  
        [HttpPost]  
        [Route("login")]  
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var token = await _identityService.Login(model);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }  
  
        [HttpPost]  
        [Route("register")]  
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            var result = await _identityService.Registration(model);
            if (result)
            {
                return Ok("Registration Successful");
            }

            return BadRequest();
        }  
  
        [HttpPost]  
        [Route("register-admin")]  
        public async Task<IActionResult> RegisterAdmin([FromBody] RegistrationModel model)
        {
            await _identityService.RegisterAdmin(model);
            return Ok();
        }  
    }  
}