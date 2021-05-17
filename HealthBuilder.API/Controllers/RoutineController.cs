using System;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Services.Contracts;
using HealthBuilder.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HealthBuilder.API.Controllers
{
    [ApiController]
    [Route("api/routines")]
    public class RoutineController : ControllerBase
    {
        private readonly IRoutineService _routineService;
        private readonly IMapper _mapper;
        public RoutineController(IRoutineService routineService, IMapper mapper)
        {
            _routineService = routineService;
            _mapper = mapper;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateRoutine(RoutineDto routine)
        {
            try
            {
                var result = await _routineService.Create(routine);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllRoutines()
        {
            var result = await _routineService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _routineService.GetById(id);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRoutine(int id)
        {
            try
            {
                await _routineService.Remove(id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}