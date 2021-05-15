using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Repositories;
using HealthBuilder.Services.Contracts;

namespace HealthBuilder.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Meal> _mealRepository;
        private readonly IRepository<Routine> _routineRepository;
        private readonly IScheduledMealRepository _scheduledMealRepository;
        private readonly IScheduledRoutineRepository _scheduledRoutineRepository;
        private readonly IRepository<ScheduledActivity> _scheduledActivityRepository;
        public SchedulingService(IRepository<User> userRepository, IRepository<Meal> mealRepository,
            IRepository<Routine> routineRepository, IScheduledMealRepository scheduledMealRepository,
            IScheduledRoutineRepository scheduledRoutineRepository, IRepository<ScheduledActivity> scheduledActivityRepository)
        {
            _userRepository = userRepository;
            _mealRepository = mealRepository;
            _routineRepository = routineRepository;
            _scheduledMealRepository = scheduledMealRepository;
            _scheduledRoutineRepository = scheduledRoutineRepository;
            _scheduledActivityRepository = scheduledActivityRepository;
        }
        public async Task<ScheduledRoutine> ScheduleRoutine(int userId, int routineId, DateTime date)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found in the Database");
            }

            var routine = await _routineRepository.GetByIdAsync(routineId);
            if (routine == null)
            {
                throw new ArgumentException("Routine not found in the database");
            }

            var scheduledRoutine = new ScheduledRoutine
            {
                UserId = userId, 
                RoutineId = routineId,
                Date = date
            };
            var result = await _scheduledRoutineRepository.AddAsync(scheduledRoutine);
            await _scheduledRoutineRepository.SaveChangesAsync();
            return result;
        }

        public async Task<ScheduledMeal> ScheduleMeal(int userId, int mealId, DateTime date)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found in the Database");
            }

            var meal = await _mealRepository.GetByIdAsync(mealId);
            if (meal == null)
            {
                throw new ArgumentException("Meal not found in the database");
            }
                
            var scheduledMeal = new ScheduledMeal
            {
                UserId = userId,
                MealId = mealId,
                Date = date
            };
            var result = await _scheduledMealRepository.AddAsync(scheduledMeal);
            await _scheduledMealRepository.SaveChangesAsync();
            return result;
        }

        public async Task RemoveScheduledActivity(int userId, int activityId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found in the Database");
            }
            var scheduledActivity =
                await _scheduledActivityRepository.SingleOrDefaultAsync(e => e.Id == activityId && e.UserId == userId);
            if (scheduledActivity == null)
            {
                throw new ArgumentException("The activity doesnt belong to the provided user or it doesnt exist");
            }
            _scheduledActivityRepository.Remove(scheduledActivity);
            await _scheduledActivityRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ScheduledMeal>> GetAllScheduledMeals(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found in the Database");
            }

            var scheduledMeals = await _scheduledMealRepository.GetScheduledMealsAsync(userId);
            return scheduledMeals;

        }

        public async Task<IEnumerable<ScheduledRoutine>> GetAllScheduledRoutines(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found in the Database");
            }
            var scheduledRoutines = (await _scheduledRoutineRepository.GetScheduledRoutinesAsync(userId));
            return scheduledRoutines;
            
        }
    }
}