using System;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Services.Dtos;
using HealthBuilder.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HealthBuilder.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> RegisterUser(UserDto userDto)
        {
            try
            {
                var result = await _userService.RegisterUser(userDto);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}