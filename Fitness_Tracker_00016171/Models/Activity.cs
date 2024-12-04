namespace Fitness_Tracker_00016171.Models
{
    public class Activity
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public DateTime ActivityDate { get; set; }
        public string ActivityType { get; set; } 
        public double Duration { get; set; } 
        public double Distance { get; set; } 

        public User User { get; set; }
    }
}
