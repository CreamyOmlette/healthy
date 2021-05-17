using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HealthBuilder.Repositories
{
    public class RoutineRepository : Repository<Routine>, IRoutineRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public RoutineRepository(ApplicationContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoutineDto>> GetAllRoutines()
        {
            var routines = await _context
                .Routines
                .Include(e => e.Exercises)
                .ToListAsync();
            var routineDto = _mapper.Map<IEnumerable<RoutineDto>>(routines);
            return routineDto;
        }

        public async Task<RoutineDto> GetRoutine(int id)
        {
            var routine = await _context
                .Routines
                .Include(e => e.Exercises)
                .FirstOrDefaultAsync(e => e.Id == id);
            var routineDto = _mapper.Map<RoutineDto>(routine);
            return routineDto;
        }

        public async Task<RoutineDto> CreateRoutine(RoutineDto routineDto)
        {
            var routine = _mapper.Map<Routine>(routineDto);
            var ids = routineDto.Exercises.Select(e => e.Id).ToList();
            routine.Exercises = new List<Exercise>();
            var exercises = _context.Exercises.Where(e => ids.Contains(e.Id));
            foreach (var exercise in exercises)
            {
                routine.Exercises.Add(exercise);
            }
            var result = await AddAsync(routine);
            await _context.SaveChangesAsync();
            var resultDto = _mapper.Map<RoutineDto>(result);
            return resultDto;
        }

        public async Task DeleteRoutine(int routineId)
        {
            var routine = await _context
                .Routines
                .FirstOrDefaultAsync(e => e.Id == routineId);
            if (routine != null)
            {
                _context.Routines.Remove(routine);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<RoutineDto> ChangeRoutine(int routineId, RoutineDto routineDto)
        {
            var routine = _mapper.Map<Routine>(routineDto);
            routine.Id = routineId;
            _context.Remove(routine);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<RoutineDto>(routine);
            return dto;
        }
    }
}