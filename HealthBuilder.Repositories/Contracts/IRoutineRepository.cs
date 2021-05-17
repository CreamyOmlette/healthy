using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;

namespace HealthBuilder.Repositories
{
    public interface IRoutineRepository : IRepository<Routine>
    {
        public Task<IEnumerable<Routine>> GetAllWithExercises();
        public Task<Routine> GetWithExercise(int id);
    }
}