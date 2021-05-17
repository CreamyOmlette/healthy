using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Repositories;
using HealthBuilder.Services.Contracts;
using HealthBuilder.Services.Dtos;

namespace HealthBuilder.Services
{
    public class MealService : IMealService
    {
        private readonly IRepository<Meal> _mealRepository;
        private readonly IMapper _mapper;
        
        public MealService(IRepository<Meal> mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MealDto>> GetAll()
        {
            var meals = await _mealRepository.GetAllAsync();
            var dto = _mapper.Map<IEnumerable<MealDto>>(meals);
            return dto;
        }

        public async Task<MealDto> Change(int mealId, MealDto meal)
        {
            var myMeal = await _mealRepository.GetByIdAsync(mealId);
            myMeal.Name = meal.Name;
            myMeal.Description = meal.Description;
            myMeal.Calories = meal.Calories;
            myMeal.Carbohydrates = meal.Carbohydrates;
            myMeal.Fats = meal.Fats;
            myMeal.Mass = meal.Mass;
            myMeal.ImgSrc = meal.ImgSrc;
            myMeal.Proteins = meal.Proteins;
            await _mealRepository.SaveChangesAsync();
            var dto = _mapper.Map<MealDto>(myMeal);
            return dto;
        }

        public async Task<MealDto> Create(MealDto mealDto)
        {
            var meal = new Meal
            {
                Name = mealDto.Name,
                Description = mealDto.Description,
                Calories = mealDto.Calories,
                Carbohydrates = mealDto.Carbohydrates,
                Fats = mealDto.Fats,
                Mass = mealDto.Mass,
                ImgSrc = mealDto.ImgSrc,
                Proteins = mealDto.Proteins
            };
            var result = await _mealRepository.AddAsync(meal);
            var dto = _mapper.Map<MealDto>(result);
            return dto;
        }

        public async Task Remove(int mealId)
        {
            var meal = await _mealRepository.SingleOrDefaultAsync(e => e.Id == mealId);
            if (meal == null)
            {
                throw new ArgumentException("Meal doesnt exist");
            }

            _mealRepository.Remove(meal);
        }

        public async Task<MealDto> GetById(int mealId)
        {
            var meal = await _mealRepository.SingleOrDefaultAsync(e => e.Id == mealId);
            if (meal == null)
            {
                throw new ArgumentException("Meal doesnt exist");
            }

            var dto = _mapper.Map<MealDto>(meal);
            return dto;
        }
    }
}