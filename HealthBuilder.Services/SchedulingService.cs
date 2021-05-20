using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Infrastructure.Exceptions;
using HealthBuilder.Repositories;
using HealthBuilder.Repositories.Contracts;
using HealthBuilder.Services.Contracts;
using Microsoft.Extensions.Logging;

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
        private readonly ILogger<SchedulingService> _logger;
        public SchedulingService(IUserRepository userRepository, IMealRepository mealRepository,
            IRoutineRepository routineRepository, IScheduledMealRepository scheduledMealRepository,
            IScheduledRoutineRepository scheduledRoutineRepository, 
            IScheduledActivityRepository scheduledActivityRepository, IMapper mapper, ILogger<SchedulingService> logger)
        {
            _userRepository = userRepository;
            _mealRepository = mealRepository;
            _routineRepository = routineRepository;
            _scheduledMealRepository = scheduledMealRepository;
            _scheduledRoutineRepository = scheduledRoutineRepository;
            _scheduledActivityRepository = scheduledActivityRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ScheduledRoutineDto> ScheduleRoutine(int userId, int routineId, DateTime activityDate)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                _logger.LogInformation("Error while scheduling a routine");
                throw new UserNotFoundException();
            }
            var routine = await _routineRepository.GetRoutine(routineId);
            if (routine == null)
            {
                _logger.LogInformation("Error while scheduling a routine");
                throw new RoutineNotFoundException();
            }
            var result = 
                await _scheduledRoutineRepository.CreateScheduledRoutine(userId, routineId, activityDate);
            return result;
        }

        public async Task<ScheduledMealDto> ScheduleMeal(int userId, int mealId, DateTime date)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                _logger.LogInformation("Error while scheduling a meal");
                throw new UserNotFoundException();
            }

            var meal = await _mealRepository.GetMeal(mealId);
            if (meal == null)
            {
                _logger.LogInformation("Error while scheduling a meal");
                throw new MealNotFoundException();
            }
            var result = await _scheduledMealRepository.CreateScheduledMeal(userId, mealId, date);
            return result;
        }

        public async Task RemoveScheduledActivity(int userId, int activityId)
        {
            var valid = await _scheduledActivityRepository.IfValid(userId, activityId);
            if (!valid)
            {
                _logger.LogInformation("Error while deleting a scheduled activity");
                throw new ScheduledActivityNotFoundException();
            }
            await _scheduledActivityRepository.RemoveScheduledActivity(activityId);
        }

        public async Task<IEnumerable<ScheduledMealDto>> GetAllScheduledMeals(int userId)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                _logger.LogInformation("Error while fetching scheduled meals");
                throw new UserNotFoundException();
            }

            var scheduledMeals = await _scheduledMealRepository.GetAllScheduledMeals(userId);
            var dto = _mapper.Map<IEnumerable<ScheduledMealDto>>(scheduledMeals);
            return dto;
        }

        public async Task<IEnumerable<ScheduledRoutineDto>> GetAllScheduledRoutines(int userId)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                _logger.LogInformation("Error while fetching scheduled routines");
                throw new UserNotFoundException();
            }
            var scheduledRoutines = await _scheduledRoutineRepository.GetAllScheduledRoutines(userId);
            var dto = _mapper.Map<IEnumerable<ScheduledRoutineDto>>(scheduledRoutines);
            return dto;
        }

        public async Task<ScheduledActivityDto> GetScheduledActivity(int userId, int activityId)
        {
            var valid = await _scheduledActivityRepository.IfValid(userId, activityId);
            if (!valid)
            {
                _logger.LogInformation("Error while fetching scheduled activity");
                return null;
            }

            var activity = await _scheduledActivityRepository.GetById(activityId);
            return activity;
        }

        public async Task<ScheduledActivityDto> UpdateScheduledActivityStatus(int userId, int activityId, bool status)
        {
            var valid = await _scheduledActivityRepository.IfValid(userId, activityId);
            if (!valid)
            {
                _logger.LogInformation("Error while fetching scheduled activity");
                throw new ScheduledActivityNotFoundException();
            }

            var activity = await _scheduledActivityRepository.UpdateStatus(activityId, status);
            return activity;
        }
    }
}