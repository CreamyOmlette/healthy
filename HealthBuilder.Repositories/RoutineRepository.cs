using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            if (routine == null)
            {
                return null;
            }
            var routineDto = _mapper.Map<RoutineDto>(routine);
            return routineDto;
        }

        public async Task<RoutineDto> CreateRoutine(RoutineDto routineDto)
        {
            var routine = _mapper.Map<Routine>(routineDto);
            routine.Exercises = new List<Exercise>();
            var ids = routineDto.Exercises.Select(e => e.Id);
            var exerciseDb = _context.Exercises.Select(e => e.Id).ToList();
            foreach (var id in ids)
            {
                if(exerciseDb.Contains(id))
                    routine.Exercises.Add(await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id));
            }

            await _context.Routines.AddAsync(routine);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<RoutineDto>(routine);
            return dto;
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

        public async Task<RoutineDto> UpdateRoutine(int routineId, RoutineDto routineDto)
        {
            var routine = await GetByIdAsync(routineId);
            routine.Name = routineDto.Name;
            routine.Description = routineDto.Description;
            routine.Difficulty = routineDto.Difficulty;
            routine.Exercises = new List<Exercise>();
            var ids = routineDto.Exercises.Select(e => e.Id);
            var exerciseDb = _context.Exercises.Select(e => e.Id).ToList();
            foreach (var id in ids)
            {
                if(exerciseDb.Contains(id))
                    routine.Exercises.Add(await _context.Exercises.FirstOrDefaultAsync(e => e.Id == id));
            }

            _context.Routines.Update(routine);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<RoutineDto>(routine);
            return dto;
        }
    }
}