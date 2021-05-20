using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Services.Contracts
{
    public interface IMealService
    {
        public Task<IEnumerable<MealDto>> GetAll();
        public Task<MealDto> UpdateMeal(int mealId, MealDto meal);
        public Task<MealDto> CreateMeal(MealDto mealDto);
        public Task RemoveMeal(int mealId);
        public Task<MealDto> GetById(int mealId);
    }
}