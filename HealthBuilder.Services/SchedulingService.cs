using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Repositories;
using HealthBuilder.Repositories.Contracts;
using HealthBuilder.Services.Contracts;

namespace HealthBuilder.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMealRepository _mealRepository;
        private readonly IRoutineRepository _routineRepository;
        private readonly IScheduledMealRepository _scheduledMealRepository;
        private readonly IScheduledRoutineRepository _scheduledRoutineRepository;
        private readonly IScheduledActivityRepository _scheduledActivityRepository;
        private readonly IMapper _mapper;
        public SchedulingService(IUserRepository userRepository, IMealRepository mealRepository,
            IRoutineRepository routineRepository, IScheduledMealRepository scheduledMealRepository,
            IScheduledRoutineRepository scheduledRoutineRepository, IScheduledActivityRepository scheduledActivityRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mealRepository = mealRepository;
            _routineRepository = routineRepository;
            _scheduledMealRepository = scheduledMealRepository;
            _scheduledRoutineRepository = scheduledRoutineRepository;
            _scheduledActivityRepository = scheduledActivityRepository;
            _mapper = mapper;
        }
        public async Task<ScheduledRoutineDto> ScheduleRoutine(int userId, int routineId, DateTime date)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found in the Database");
            }
            var routine = await _routineRepository.GetRoutine(routineId);
            if (routine == null)
            {
                throw new ArgumentException("Routine not found in the database");
            }
            var result = 
                await _scheduledRoutineRepository.ScheduleRoutineAsync(userId, routineId, date);
            return result;
        }

        public async Task<ScheduledMealDto> ScheduleMeal(int userId, int mealId, DateTime date)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found in the Database");
            }

            var meal = await _mealRepository.GetMeal(mealId);
            if (meal == null)
            {
                throw new ArgumentException("Meal not found in the database");
            }
            var result = await _scheduledMealRepository.ScheduleMeal(userId, mealId, date);
            return result;
        }

        public async Task RemoveScheduledActivity(int userId, int activityId)
        {
            var valid = await _scheduledActivityRepository.ifExists(userId, activityId);
            if (!valid)
            {
                throw new ArgumentException("The activity doesn't exist");
            }
            await _scheduledActivityRepository.Remove(activityId);
        }

        public async Task<IEnumerable<ScheduledMealDto>> GetAllScheduledMeals(int userId)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found in the Database");
            }

            var scheduledMeals = await _scheduledMealRepository.GetScheduledMealsAsync(userId);
            var dto = _mapper.Map<IEnumerable<ScheduledMealDto>>(scheduledMeals);
            return dto;

        }

        public async Task<IEnumerable<ScheduledRoutineDto>> GetAllScheduledRoutines(int userId)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found in the Database");
            }
            var scheduledRoutines = (await _scheduledRoutineRepository.GetScheduledRoutinesAsync(userId));
            var dto = _mapper.Map<IEnumerable<ScheduledRoutineDto>>(scheduledRoutines);
            return dto;
            
        }
    }
}