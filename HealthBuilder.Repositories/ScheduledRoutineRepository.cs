using System;
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
    public class ScheduledRoutineRepository: ScheduledActivityRepository<ScheduledRoutine>, IScheduledRoutineRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public ScheduledRoutineRepository(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ScheduledRoutineDto>> GetAllScheduledRoutines(int userId)
        {
            var routines = await _context
                .ScheduledRoutines
                .Where(e => e.UserId == userId)
                .Include(e => e.Routine)
                .ToListAsync();
            var routinesDto = _mapper.Map<IEnumerable<ScheduledRoutineDto>>(routines);
            return routinesDto;
        }

        public async Task<ScheduledRoutineDto> CreateScheduledRoutine(int userId, int routineId, DateTime activityDate)
        {
            var routine = await _context
                .Routines
                .FirstOrDefaultAsync(e => e.Id == routineId);
            var result = new ScheduledRoutine
            {
                UserId = userId,
                RoutineId = routineId,
                Date = activityDate
            };
            var addedScheduledRoutine = await AddAsync(result);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<ScheduledRoutineDto>(addedScheduledRoutine);
            return dto;
        }

        public async Task<ScheduledRoutineDto> GetScheduledRoutine(int userId, int activityId)
        {
            var routine = await _context.ScheduledRoutines.FirstOrDefaultAsync(e => e.Id == activityId);
                if (routine == null)
                {
                    return null;
                }
                
                var dto = _mapper.Map<ScheduledRoutineDto>(routine);
                return dto;
        }
    }
}