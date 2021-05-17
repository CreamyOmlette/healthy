using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBuilder.Infrastructure.Dtos;

namespace HealthBuilder.Services.Contracts
{
    public interface IRoutineService
    {
        public Task<IEnumerable<RoutineDto>> GetAll();
        public Task<RoutineDto> Change(int routineId, RoutineDto routine);
        public Task<RoutineDto> Create(RoutineDto routineDto);
        public Task Remove(int routineId);
        public Task<RoutineDto> GetById(int routineId);
    }
}