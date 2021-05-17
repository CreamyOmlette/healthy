using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Services.Dtos;

namespace HealthBuilder.Services.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Routine, RoutineDto>();
            CreateMap<ScheduledRoutine, ScheduledRoutineDto>();

            CreateMap<Meal, MealDto>();
            CreateMap<ScheduledMeal, ScheduledMealDto>();

            CreateMap<Exercise, ExerciseDto>();
            CreateMap<ExerciseDto, Exercise>();
        }
    }
}