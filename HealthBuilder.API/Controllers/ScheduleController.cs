using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthBuilder.Services.Contracts;

namespace HealthBuilder.API.Controllers
{
    [Route("api/schedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ISchedulingService _schedulingService;

        public ScheduleController(ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;
        }

        [HttpPost("routines/{id}")]
        public async Task<IActionResult> ScheduleRoutine(int id, int routineId, DateTime date)
        {
            try
            {
                var result = await _schedulingService.ScheduleRoutine(id, routineId, date);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpPost("meals/{id}")]
        public async Task<IActionResult> ScheduleMeal(int id, int mealId, DateTime date)
        {
            try
            {
                var result = await _schedulingService.ScheduleMeal(id, mealId, date);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("meals/{id}")]
        public async Task<IActionResult> GetScheduledMeals(int id)
        {
            try
            {
                var result = await _schedulingService.GetAllScheduledMeals(id);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("routines/{id}")]
        public async Task<IActionResult> GetScheduledRoutines(int id)
        {
            try
            {
                var result = await _schedulingService.GetAllScheduledRoutines(id);
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{userId}/{activityId}")]
        public async Task<IActionResult> RemoveScheduledActivity(int userId, int activityId)
        {
            try
            {
                await _schedulingService.RemoveScheduledActivity(userId, activityId);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}