using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HealthBuilder.API.Dtos;
using HealthBuilder.Repositories;
using HealthBuilder.Services.Contracts;

namespace HealthBuilder.API.Controllers
{
    [Route("api/schedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ISchedulingService _schedulingService;
        private readonly IMapper _mapper;

        public ScheduleController(ISchedulingService schedulingService, IMapper mapper)
        {
            _schedulingService = schedulingService;
            _mapper = mapper;
        }

        [HttpPost("routines/{id}")]
        public async Task<IActionResult> ScheduleRoutine(int id, int routineId, DateTime date)
        {
            try
            {
                var result = await _schedulingService.ScheduleRoutine(id, routineId, date);
                var scheduledRoutineDto =
                    _mapper.Map<ScheduledRoutine, ScheduledRoutineDto>(result);
                return Ok(scheduledRoutineDto);
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
                var scheduledMealDto =
                    _mapper.Map<ScheduledMeal, ScheduledMealDto>(result);
                return Ok(scheduledMealDto);
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
                var scheduledMeals = await _schedulingService.GetAllScheduledMeals(id);
                var scheduledMealsDto =
                    _mapper.Map<IEnumerable<ScheduledMeal>, IEnumerable<ScheduledMealDto>>(scheduledMeals);
                return Ok(scheduledMealsDto);
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
                var scheduledRoutines = await _schedulingService.GetAllScheduledRoutines(id);
                var scheduledRoutinesDto =
                    _mapper.Map<IEnumerable<ScheduledRoutine>, IEnumerable<ScheduledRoutineDto>>(scheduledRoutines);
                return Ok(scheduledRoutinesDto);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("schedules/{userId}")]
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