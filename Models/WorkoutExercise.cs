namespace fitness_tracker_api.Models
{
    public class WorkoutExercise
    {
        public int WorkoutExerciseID { get; set; }
        public int WorkoutID { get; set; }
        public Workout Workout { get; set; }
        public int ExerciseID { get; set; }
        public Exercise Exercise { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int WeightUsed { get; set; }
        public TimeSpan Duration { get; set; }

    }
}
