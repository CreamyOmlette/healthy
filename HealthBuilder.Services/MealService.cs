using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Infrastructure.Exceptions;
using HealthBuilder.Repositories.Contracts;
using HealthBuilder.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace HealthBuilder.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MealService> _logger;

        public MealService(IMealRepository mealRepository, IMapper mapper, ILogger<MealService> logger)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<MealDto>> GetAll()
        {
            var meals = await _mealRepository.GetAllMeals();
            var dto = _mapper.Map<IEnumerable<MealDto>>(meals);
            return dto;
        }

        public async Task<MealDto> UpdateMeal(int mealId, MealDto meal)
        {
            var myMeal = await _mealRepository.GetMeal(mealId);
            if (myMeal == null)
            {
                _logger.LogInformation("Error while changing a meal");
                throw new MealNotFoundException();
            }
            var result = await _mealRepository.UpdateMeal(meal);
            return result;
        }

        public async Task<MealDto> CreateMeal(MealDto mealDto)
        {
            var result = await _mealRepository.CreateMeal(mealDto);
            return result;
        }

        public async Task RemoveMeal(int mealId)
        {
            var meal = await _mealRepository.GetMeal(mealId);
            if (meal == null)
            {
                _logger.LogInformation("Error while deleting a meal");
                throw new MealNotFoundException();
            }
            await _mealRepository.DeleteMeal(mealId);
        }

        public async Task<MealDto> GetById(int mealId)
        {
            var meal = await _mealRepository.GetMeal(mealId);
            return meal;
        }
    }
}