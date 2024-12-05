using Fitness_Tracker_00016171.Data;
using Fitness_Tracker_00016171.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fitness_Tracker_00016171.Repository
{
    public class ActivityRepository : IRepository<Activity>
    {
        private readonly FitnessContext _context;

        public ActivityRepository(FitnessContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Activity activity)
        {
            await _context.Activity.AddAsync(activity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var activity = await _context.Activity.FindAsync(id);
            if (activity != null)
            {
                _context.Activity.Remove(activity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _context.Activity.ToListAsync();
        }

        public async Task<Activity> GetByIDAsync(int id)
        {
            return await _context.Activity.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Activity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
