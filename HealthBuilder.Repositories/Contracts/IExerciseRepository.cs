using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Repositories.Contracts
{
    public interface IExerciseRepository
    {
        public Task<IEnumerable<int>> GetValidIds();
        public Task<ExerciseDto> CreateExercise(ExerciseDto exerciseDto);
        public Task<ExerciseDto> UpdateExercise(int id, ExerciseDto exerciseDto);
        public Task DeleteExercise(int id);
    }
}