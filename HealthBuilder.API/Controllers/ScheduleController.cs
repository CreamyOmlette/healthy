using System;
using System.Diagnostics;
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
            var result = await _schedulingService.ScheduleRoutine(id, routineId, date);
            return Ok(result);
        }

        [HttpPost("meals/{id}")]
        public async Task<IActionResult> ScheduleMeal(int id, int mealId, DateTime date)
        {
            var result = await _schedulingService.ScheduleMeal(id, mealId, date);
            return Ok(result);
        }

        [HttpGet("meals/{id}")]
        public async Task<IActionResult> GetScheduledMeals(int id)
        {
            var result = await _schedulingService.GetAllScheduledMeals(id);
            return Ok(result);
        }

        [HttpGet("routines/{id}")]
        public async Task<IActionResult> GetScheduledRoutines(int id)
        {
            var result = await _schedulingService.GetAllScheduledRoutines(id);
            return Ok(result);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> RemoveScheduledActivity(int userId, int activityId)
        {
            await _schedulingService.RemoveScheduledActivity(userId, activityId);
            return Ok();
        }
        
        [HttpPatch("{userId}")]
        public async Task<IActionResult> UpdateScheduledActivityStatus(int userId, int activityId, bool status)
        {
            var result = await _schedulingService
                .UpdateScheduledActivityStatus(userId, activityId, status);
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetScheduledActivity(int userId, int activityId)
        {
            var result = await _schedulingService.GetScheduledActivity(userId, activityId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}