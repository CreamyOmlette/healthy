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
        public async Task<IActionResult> RegisterUser(UserCreationDto userDto)
        {
             var result = await _userService.RegisterUser(userDto);
             return Ok(result);
        }

        [HttpPatch("{id}/dob")]
        public async Task<IActionResult> UpdateUsersDateOfBirth(int id, DoBDto dateOfBirthDto)
        {
            var result = await _userService.UpdateDateOfBirth(id, dateOfBirthDto);
            return Ok(result);
        }
        
        [HttpPatch("{id}/specification")]
        public async Task<IActionResult> UpdateUsersDateOfBirth(int id, SpecificationDto specificationDto)
        {
            var result = await _userService.UpdateSpecification(id, specificationDto);
            return Ok(result);
        }
        
        [HttpPatch("{id}/password")]
        public async Task<IActionResult> UpdateUsersDateOfBirth(int id, PasswordDto passwordDto)
        {
            var result = await _userService.UpdatePassword(id, passwordDto);
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
            var user = await _userService.GetUserById(id); 
            return Ok(user);
        }
    }
}