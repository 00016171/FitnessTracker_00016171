using Fitness_Tracker_00016171.Data;
using Fitness_Tracker_00016171.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fitness_Tracker_00016171.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly FitnessContext _context;

        public UserRepository(FitnessContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.User.Include(u => u.Activities).ToListAsync();
        }

        public async Task<User> GetByIDAsync(int id)
        {
            return await _context.User.Include(u => u.Activities).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
