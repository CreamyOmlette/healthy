using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Repositories.Contracts;
using HealthBuilder.Services.Contracts;

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
            var routines = await _routineRepository.GetAllRoutines();
            var result = _mapper.Map<IEnumerable<RoutineDto>>(routines);
            return result;
        }

        public async Task<RoutineDto> Change(int routineId, RoutineDto routineDto)
        {
            var routine = await _routineRepository.GetRoutine(routineId);
            if (routine == null)
            {
                throw new ArgumentException("Routine not found");
            }

            var result = await _routineRepository.ChangeRoutine(routineId, routineDto);
            return result;
        }

        public async Task<RoutineDto> Create(RoutineDto routineDto)
        { 
            var result = await _routineRepository.CreateRoutine(routineDto);
            return result;
        }

        public async Task Remove(int routineId)
        {
            var entity = await _routineRepository.GetRoutine(routineId);
            if (entity == null)
            {
                throw new ArgumentException("Routine not found");
            }
            await _routineRepository.DeleteRoutine(routineId);
        }

        public async Task<RoutineDto> GetById(int routineId)
        {
            var routine = await _routineRepository.GetRoutine(routineId);
            if (routine == null)
            {
                throw new ArgumentException("Routine not found");
            }

            return routine;
        }
    }
}