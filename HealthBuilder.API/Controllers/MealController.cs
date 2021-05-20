using System;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HealthBuilder.API.Controllers
{
    [ApiController]
    [Route("api/meals")]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;
        private readonly IMapper _mapper;

        public MealController(IMealService mealService, IMapper mapper)
        {
            _mealService = mealService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllMeals()
        { 
            var result = await _mealService.GetAll();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealById(int id)
        { 
            var result = await _mealService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeal(MealDto mealDto)
        {
            var result = await _mealService.CreateMeal(mealDto); 
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMeal(int id)
        {
           await _mealService.RemoveMeal(id);
           return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateMeal(int id, MealDto mealDto)
        {
            var result = await _mealService.UpdateMeal(id, mealDto);
            return Ok();
        }
    }
}