using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ScheduledMealRepository : Repository<ScheduledMeal>, IScheduledMealRepository
    {
        private readonly DbSet<ScheduledMeal> _set;
        private readonly DbContext _context;
        public ScheduledMealRepository(DbContext context) : base(context)
        {
            _context = context;
            _set = context.Set<ScheduledMeal>();
        }
        
        public async Task<IEnumerable<ScheduledMeal>> GetAllByUserAsync(int userId)
        {
            var result = _set.Where(e => e.UserId == userId).Include(e => e.Meal).ToListAsync();
            return await result;
        }

        public async Task<ScheduledMeal> ScheduleMeal(int userId, int mealId, DateTime date)
        {
            var meal = await _context.Set<Meal>().FirstOrDefaultAsync(e => e.Id == mealId);
            var scheduledMeal = new ScheduledMeal
            {
                UserId = userId,
                MealId = mealId,
                Date = date
            };
            await _set.AddAsync(scheduledMeal);
            return scheduledMeal;
        }

        public void RemoveScheduledMeal(int userId, int scheduledMealId)
        {
            var meal = _set.FirstOrDefault(e => e.Id == scheduledMealId);
            if (meal != null)
            {
                _set.Remove(meal);
            }
        }

        public new async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}