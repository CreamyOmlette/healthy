using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace HealthBuilder.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private IRepository<User> _userRepository;
        private IMapper _mapper;

        public UserController(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> RegisterUser(string username, string password, int height, int weight, string dob)
        {
            var validator = (await _userRepository.GetAllAsync()).Any(e => e.Username.Equals(username));
            if (!validator)
            {
                var user = new User
                {
                    Username = username,
                    Password = password,
                    Height = height,
                    Weight = weight,
                    DoB = DateTime.ParseExact(dob, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                };
                return Ok();
            }

            return BadRequest("username already exists");
        }
    }
}