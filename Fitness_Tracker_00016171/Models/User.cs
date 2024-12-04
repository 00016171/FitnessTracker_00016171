using System.Diagnostics;

namespace Fitness_Tracker_00016171.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public List<Activity> Activities { get; set; } 
    }
}
