using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Repositories;
using HealthBuilder.Services.Contracts;
using HealthBuilder.Services.Dtos;

namespace HealthBuilder.Services
{
    public class RoutineService : IRoutineService
    {
        private readonly IRoutineRepository _routineRepository;
        private readonly IMapper _mapper;
        public RoutineService(IRoutineRepository routineRepository, IMapper mapper)
        {
            _routineRepository = routineRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoutineDto>> GetAll()
        {
            var routines = await _routineRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<RoutineDto>>(routines);
            return result;
        }

        public async Task<RoutineDto> Change(int routineId, RoutineDto routine)
        {
            var entity = await _routineRepository.GetByIdAsync(routineId);
            if (entity == null)
            {
                throw new ArgumentException("Routine not found");
            }
            entity.Name = routine.Name;
            entity.Description = routine.Description;
            entity.Difficulty = routine.Difficulty;
            await _routineRepository.SaveChangesAsync();
            var result = _mapper.Map<RoutineDto>(entity);
            return result;
        }

        public async Task<RoutineDto> Create(RoutineDto routineDto)
        {
            var routine = new Routine
            {
                Name = routineDto.Name,
                Description = routineDto.Description,
                Difficulty = routineDto.Difficulty,
                Exercises = _mapper.Map<List<Exercise>>(routineDto.Exercises)
            };
           var result = await _routineRepository.AddAsync(routine);
           var dto = _mapper.Map<RoutineDto>(result);
           return dto;
        }

        public async Task Remove(int routineId)
        {
            var entity = await _routineRepository.GetByIdAsync(routineId);
            if (entity == null)
            {
                throw new ArgumentException("Routine not found");
            }
            _routineRepository.Remove(entity);
        }

        public async Task<RoutineDto> GetById(int routineId)
        {
            var entity = await _routineRepository.GetWithExercise(routineId);
            if (entity == null)
            {
                throw new ArgumentException("Routine not found");
            }

            return _mapper.Map<RoutineDto>(entity);
        }
    }
}