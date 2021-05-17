using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Services.Contracts;
using HealthBuilder.Services.Dtos;
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
            try
            {
                var result = await _mealService.GetAll();
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeal(MealDto mealDto)
        {
            try
            {
                var result = await _mealService.Create(mealDto);
                return Ok(result);
            }
            catch(ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMeal(int id)
        {
            try
            {
                await _mealService.Remove(id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}