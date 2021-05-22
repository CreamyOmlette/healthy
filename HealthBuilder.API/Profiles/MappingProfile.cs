using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Services.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Resource
            CreateMap<Routine, RoutineDto>();
            CreateMap<Meal, MealDto>();
            CreateMap<ScheduledRoutine, ScheduledRoutineDto>();
            CreateMap<ScheduledMeal, ScheduledMealDto>();
            CreateMap<Exercise, ExerciseDto>();
            CreateMap<User, UserDto>();
            CreateMap<ScheduledActivity, ScheduledActivityDto>();
            
            //Resource to Domain
            CreateMap<RoutineDto,Routine>();
            CreateMap<MealDto, Meal>();
            CreateMap<ScheduledRoutineDto, ScheduledRoutine>();
            CreateMap<ScheduledMealDto, ScheduledMeal>();
            CreateMap<ExerciseDto, Exercise>();
            CreateMap<UserDto, User>();
            CreateMap<ScheduledActivityDto, ScheduledActivity>();
        }
    }
}