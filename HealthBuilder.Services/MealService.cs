using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Repositories.Contracts;
using HealthBuilder.Services.Contracts;

namespace HealthBuilder.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;
        
        public MealService(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MealDto>> GetAll()
        {
            var meals = await _mealRepository.GetAllMeals();
            var dto = _mapper.Map<IEnumerable<MealDto>>(meals);
            return dto;
        }

        public async Task<MealDto> Change(int mealId, MealDto meal) // For Change
        {
            var myMeal = await _mealRepository.GetMeal(mealId);
            if (myMeal == null)
            {
                throw new ArgumentException("Meal doesnt Exist");
            }

            var result = await _mealRepository.ChangeMeal(meal);
            return result;
        }

        public async Task<MealDto> Create(MealDto mealDto)
        {
            var result = await _mealRepository.CreateMeal(mealDto);
            return result;
        }

        public async Task Remove(int mealId)
        {
            var meal = await _mealRepository.GetMeal(mealId);
            if (meal == null)
            {
                throw new ArgumentException("Meal doesnt exist");
            }
            await _mealRepository.DeleteMeal(mealId);
        }

        public async Task<MealDto> GetById(int mealId)
        {
            var meal = await _mealRepository.GetMeal(mealId);
            if (meal == null)
            {
                throw new ArgumentException("Meal doesnt exist");
            }

            var dto = _mapper.Map<MealDto>(meal);
            return dto;
        }
    }
}