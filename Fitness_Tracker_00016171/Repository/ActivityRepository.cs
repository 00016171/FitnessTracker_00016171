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

        // Add or create a new activity
        public async Task AddAsync(Activity activity)
        {
            await _context.Activity.AddAsync(activity);
            await _context.SaveChangesAsync();
        }

        // Delete an activity by ID
        public async Task DeleteAsync(int id)
        {
            var activity = await _context.Activity.FindAsync(id);
            if (activity != null)
            {
                _context.Activity.Remove(activity);
                await _context.SaveChangesAsync();
            }
        }

        // Retrieve all activities
        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _context.Activity.Include(a => a.User).ToListAsync();
        }

        // Retrieve a specific activity by ID
        public async Task<Activity> GetByIDAsync(int id)
        {
            return await _context.Activity.Include(a => a.User).FirstOrDefaultAsync(a => a.Id == id);
        }

        // Update an existing activity
        public async Task UpdateAsync(Activity activity)
        {
            _context.Entry(activity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
