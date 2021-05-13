using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.API.Dtos;

namespace HealthBuilder.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Routine, RoutineDto>();
            CreateMap<ScheduledRoutine, ScheduledRoutineDto>();

            CreateMap<Meal, MealDto>();
            CreateMap<ScheduledMeal, ScheduledMealDto>();
        }
    }
}