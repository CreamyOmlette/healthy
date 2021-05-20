using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HealthBuilder.Repositories
{
    public class ScheduledMealRepository : ScheduledActivityRepository<ScheduledMeal>, IScheduledMealRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public ScheduledMealRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ScheduledMealDto>> GetAllScheduledMeals(int userId)
        {
            var meals =await _context
                .ScheduledMeals
                .Where(e => e.UserId == userId)
                .Include(e => e.Meal)
                .ToListAsync();
            var mealsDto = _mapper.Map<IEnumerable<ScheduledMealDto>>(meals);
            return mealsDto;
        }
        
        public async Task<ScheduledMealDto> CreateScheduledMeal(int userId, int mealId, DateTime date)
        {
            var meal = await _context
                .Set<Meal>()
                .FirstOrDefaultAsync(e => e.Id == mealId);
            var scheduledMeal = new ScheduledMeal
            {
                UserId = userId,
                MealId = mealId,
                Date = date
            };
            var addedMeal = await _context
                .ScheduledMeals
                .AddAsync(scheduledMeal);
            await _context.SaveChangesAsync();
            var addedMealDto = _mapper.Map<ScheduledMealDto>(addedMeal.Entity);
            return addedMealDto;
        }

        public async Task<ScheduledMealDto> GetScheduledMeal(int userId, int activityId)
        {
            var meal = await _context.ScheduledMeals.FirstOrDefaultAsync(e => e.Id == activityId);
            if (meal == null)
            {
                return null;
            }
            
            var dto = _mapper.Map<ScheduledMealDto>(meal);
            return dto;
        }
    }
}