using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HealthBuilder.Repositories
{
    public class MealRepository : Repository<Meal>, IMealRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public MealRepository(ApplicationContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MealDto> CreateMeal(MealDto mealDto)
        {
            var meal = _mapper.Map<Meal>(mealDto);
            var result = await AddAsync(meal);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<MealDto>(result);
            return dto;
        }

        public async Task<MealDto> GetMeal(int mealId)
        {
            var meal = await _context.Meals.FirstOrDefaultAsync(e => e.Id == mealId);
            if (meal == null)
            {
                return null;
            }
            var dto = _mapper.Map<MealDto>(meal);
            return dto;
        }

        public async Task<IEnumerable<MealDto>> GetAllMeals()
        {
            var meals = await _context.Meals.ToListAsync();
            var dto = _mapper.Map<IEnumerable<MealDto>>(meals);
            return dto;
        }

        public async Task DeleteMeal(int mealId)
        {
            var meal = await _context.Meals.FirstOrDefaultAsync(e => e.Id == mealId);
            if (meal == null)
            {
                throw new ArgumentException("meal not found in the repository");
            }
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
        }

        public async Task<MealDto> UpdateMeal(MealDto mealDto)
        {
            var meal = _mapper.Map<Meal>(mealDto);
            var result = await Task.Run(() => _context.Update(meal));
            var dto = _mapper.Map<MealDto>(result.Entity);
            return dto;
        }
    }
}