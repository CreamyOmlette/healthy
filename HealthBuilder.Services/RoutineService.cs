using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Infrastructure.Exceptions;
using HealthBuilder.Repositories.Contracts;
using HealthBuilder.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace HealthBuilder.Services
{
    public class RoutineService : IRoutineService
    {
        private readonly IRoutineRepository _routineRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RoutineService> _logger;
        private readonly IExerciseRepository _exerciseRepository;
        public RoutineService(IRoutineRepository routineRepository,
            IExerciseRepository exerciseRepository, IMapper mapper, ILogger<RoutineService> logger)
        {
            _routineRepository = routineRepository;
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<RoutineDto>> GetAll()
        {
            var routines = await _routineRepository.GetAllRoutines();
            var result = _mapper.Map<IEnumerable<RoutineDto>>(routines);
            return result;
        }

        public async Task<RoutineDto> UpdateRoutine(int routineId, RoutineDto routineDto)
        {
            var routine = await _routineRepository.GetRoutine(routineId);
            if (routine == null)
            {
                _logger.LogInformation("Error while changing a Routine");
                throw new Exception("Routine not found");
            }

            var result = await _routineRepository.UpdateRoutine(routineId, routineDto);
            return result;
        }

        public async Task<RoutineDto> CreateRoutine(RoutineDto routineDto)
        {
            var exercises = routineDto.Exercises;
            var validIds = (await _exerciseRepository.GetValidIds()).ToList();
            foreach (var exercise in exercises)
            {
                if (!validIds.Contains(exercise.Id))
                {
                    _logger.LogInformation("Error while creating a Routine");
                    throw new ExerciseNotFoundException();
                }
            }
            var result = await _routineRepository.CreateRoutine(routineDto);
            return result;
        }

        public async Task Remove(int routineId)
        {
            var entity = await _routineRepository.GetRoutine(routineId);
            if (entity == null)
            {
                _logger.LogInformation("Error while deleting a Routine");
                throw new RoutineNotFoundException();
            }
            await _routineRepository.DeleteRoutine(routineId);
        }

        public async Task<RoutineDto> GetById(int routineId)
        {
            var routine = await _routineRepository.GetRoutine(routineId);
            return routine;
        }
    }
}