namespace fitness_tracker_api.Models
{
    public class Workout 
    {
        public int WorkoutID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
        public DateTime WorkoutDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan TotalWorkoutDuration { get; set; }
        public DateTime CreatedAt { get; set; }


        // STATS: Move to WorkoutStat class
        public int TotalReps { get; set; }
        public int TotalSets { get; set; }
        public int TotalWeightLifted { get; set; }

        public Workout()
        {
            WorkoutExercises = new List<WorkoutExercise>();
            WorkoutDate = DateTime.UtcNow;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
