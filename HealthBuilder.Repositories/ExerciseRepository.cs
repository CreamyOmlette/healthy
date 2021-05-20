using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure;
using HealthBuilder.Infrastructure.Dtos;
using HealthBuilder.Repositories.Contracts;

namespace HealthBuilder.Repositories
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public ExerciseRepository(ApplicationContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<int>> GetValidIds()
        {
            var ids = (await GetAllAsync()).Select(e => e.Id);
            return ids;
        }

        public async Task<ExerciseDto> CreateExercise(ExerciseDto exerciseDto)
        {
            var exercise = _mapper.Map<Exercise>(exerciseDto);
            var result = await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<ExerciseDto>(exercise);
            return dto;
        }

        public async Task<ExerciseDto> UpdateExercise(int id, ExerciseDto exerciseDto)
        {
            var exercise = await GetByIdAsync(id);
            if (exercise == null)
            {
                return null;
            }

            exerciseDto.Id = id;
            exercise = _mapper.Map<Exercise>(exerciseDto);
            _context.Exercises.Update(exercise);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<ExerciseDto>(exercise);
            return dto;
        }

        public async Task DeleteExercise(int id)
        {
            var exercise = await GetByIdAsync(id);
            if (exercise == null)
            {
                return;
            }

            _context.Exercises.Remove(exercise);
        }
    }
}