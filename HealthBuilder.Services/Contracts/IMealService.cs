using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Services.Dtos;

namespace HealthBuilder.Services.Contracts
{
    public interface IMealService
    {
        public Task<IEnumerable<MealDto>> GetAll();
        public Task<MealDto> Change(int mealId, MealDto meal);
        public Task<MealDto> Create(MealDto mealDto);
        public Task Remove(int mealId);
        public Task<MealDto> GetById(int mealId);
    }
}