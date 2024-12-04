using Fitness_Tracker_00016171.Models;
using Microsoft.EntityFrameworkCore;

namespace Fitness_Tracker_00016171.Data
{
    public class FitnessContext:DbContext
    {
        public FitnessContext(DbContextOptions<FitnessContext> options): base(options) 
        { }

        public DbSet<Activity> Activity { get; set; }
        public DbSet<User> User { get; set; }

    }
}
