namespace fitness_tracker_api.Models
{
    public class Exercise
    {
        public int ExerciseID { get; set; }
        public string Name { get; set; }
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }

        public Exercise()
        {
            WorkoutExercises = new List<WorkoutExercise>();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
