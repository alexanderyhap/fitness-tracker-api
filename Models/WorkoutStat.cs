namespace fitness_tracker_api.Models
{
    public class WorkoutStat
    {
        public int WorkoutStatID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int StatType { get; set; }
        public int Value { get; set; }
        public DateTime CreatedAt { get; set; }

        public WorkoutStat()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
