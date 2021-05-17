using System;
using System.Threading.Tasks;
using HealthBuilder.Infrastructure.Dtos;
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
                if (result == null)
                {
                    throw new ArgumentException("username exists");
                }
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> ChangeUser(int id, string password = null, int height = 0, int weight = 0)
        {
            var result = await _userService.ChangeUser(id, password, height, weight);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                return Ok(user);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
        }
}