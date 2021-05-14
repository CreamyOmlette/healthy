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

namespace HealthBuilder.API.Controllers
{
    [Route("api/schedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduledMealRepository _scheduledMealRepository;
        private readonly IScheduledRoutineRepository _scheduledRoutineRepository;
        private readonly IRepository<Routine> _routineRepository;
        private readonly IRepository<Meal> _mealRepository;
        private readonly IRepository<ScheduledActivity> _scheduleRepository;
        private readonly IMapper _mapper;
        public ScheduleController
        (
            IScheduledMealRepository scheduledMealRepository,
            IScheduledRoutineRepository scheduledRoutineRepository,
            IRepository<Routine> routineRepository,
            IRepository<Meal> mealRepository,
            IRepository<ScheduledActivity> scheduleRepository,
            IMapper mapper
            )
        {
            _scheduledMealRepository = scheduledMealRepository;
            _scheduledRoutineRepository = scheduledRoutineRepository;
            _mealRepository = mealRepository;
            _routineRepository = routineRepository;
            _mapper = mapper;
            _scheduleRepository = scheduleRepository;
        }

        [HttpPost("routines/{id}")]
        public async Task<IActionResult> ScheduleRoutine(int id, int routineId, string dateStr)
        {
            var date = DateTime.ParseExact(dateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var routine = await _routineRepository.GetByIdAsync(routineId);
            if (routine != null)
            {
                var item = new ScheduledRoutine
                {
                    UserId = id,
                    RoutineId = routineId,
                    Date = date
                };
                await _scheduledRoutineRepository.ScheduleRoutineAsync(id, routineId, date);
                await _scheduledRoutineRepository.SaveChangesAsync();
                return Ok(item);
            }

            return NotFound();
        }
        
        [HttpPost("meals/{id}")]
        public async Task<IActionResult> ScheduleMeal(int id, int mealId, string dateStr)
        {
            var date = DateTime.ParseExact(dateStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var meal = await _mealRepository.GetByIdAsync(mealId);
            if (meal != null)
            {
                var item = new ScheduledMeal
                {
                    UserId = id,
                    MealId = mealId,
                    Date = date
                };
                await _scheduledMealRepository.ScheduleMeal(id, mealId, date);
                await _scheduledMealRepository.SaveChangesAsync();
                return Ok(item);
            }

            return NotFound();
        }

        [HttpGet("meals/{id}")]
        public async Task<IActionResult> GetScheduledMeals(int id)
        {
            var scheduledMeals = await _scheduledMealRepository.GetAllByUserAsync(id);
            var scheduledMealsDto =
                _mapper.Map<IEnumerable<ScheduledMeal>, IEnumerable<ScheduledMealDto>>(scheduledMeals);
            return Ok(scheduledMealsDto);
        }

        [HttpGet("routines/{id}")]
        public async Task<IActionResult> GetScheduledRoutines(int id)
        {
            var scheduledRoutines = await _scheduledRoutineRepository.GetScheduledRoutinesAsync(id);
            var scheduledRoutinesDto = 
                _mapper.Map<IEnumerable<ScheduledRoutine>, IEnumerable<ScheduledRoutineDto>>(scheduledRoutines);
            return Ok(scheduledRoutinesDto);
        }

        [HttpDelete("schedules/{userId}")]
        public async Task<IActionResult> RemoveScheduledItem(int userId, int activityId)
        {
            var scheduledItem = (await _scheduleRepository.GetAllAsync())
                .FirstOrDefault(e => e.UserId == userId && e.Id == activityId);
            if (scheduledItem != null)
            {
                _scheduleRepository.Remove(scheduledItem);
                await _scheduleRepository.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}