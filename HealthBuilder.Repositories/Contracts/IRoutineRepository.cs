using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Repositories.Contracts
{
    public interface IRoutineRepository
    {
        public Task<IEnumerable<RoutineDto>> GetAllRoutines();
        public Task<RoutineDto> GetRoutine(int id);
        public Task<RoutineDto> CreateRoutine(RoutineDto routineDto);
        public Task DeleteRoutine(int routineId);
        public Task<RoutineDto> UpdateRoutine(int routineId, RoutineDto routineDto);
    }
}