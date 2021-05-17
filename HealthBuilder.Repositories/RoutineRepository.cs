using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthBuilder.Repositories
{
    public class RoutineRepository : Repository<Routine>, IRoutineRepository
    {
        private readonly DbContext _context;
        
        public RoutineRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Routine>> GetAllWithExercises()
        {
            return await _context.Set<Routine>().Include(e => e.Exercises).ToListAsync();
        }

        public async Task<Routine> GetWithExercise(int id)
        {
            return await _context.Set<Routine>().Include(e => e.Exercises).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}