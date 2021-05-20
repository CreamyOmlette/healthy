using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Repositories.Contracts
{
    public interface IMealRepository
    {
        public Task<MealDto> CreateMeal(MealDto mealDto);
        public Task<MealDto> GetMeal(int mealId);
        public Task<IEnumerable<MealDto>> GetAllMeals();
        public Task DeleteMeal(int mealId);
        public Task<MealDto> UpdateMeal(MealDto mealDto);
    }
}