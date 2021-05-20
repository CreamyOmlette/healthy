using System.Threading.Tasks;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HealthBuilder.API.Controllers
{
    [ApiController]
    [Route("api/routines")]
    public class RoutineController : ControllerBase
    {
        private readonly IRoutineService _routineService;
        public RoutineController(IRoutineService routineService)
        {
            _routineService = routineService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateRoutine(RoutineDto routine)
        {
            var result = await _routineService.CreateRoutine(routine);
            return Ok(result);
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
            var result = await _routineService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRoutine(int id)
        {
            await _routineService.Remove(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRoutine(int id, RoutineDto routineDto)
        {
            var result = await _routineService.UpdateRoutine(id, routineDto);
            return Ok(result);
        }
    }
}