using fitness_tracker_api.Models;

namespace fitness_tracker_api.Services
{
    public interface IWorkoutService
    {
        Task<IEnumerable<Workout>> GetWorkouts();
        Task<Workout> GetWorkoutById(int id);
        Task<bool> AddWorkout(Workout workout);
        Task<bool> UpdateWorkout(Workout workout);
        Task<bool> DeleteWorkout(int id);
        // ... any other methods related to workout operations
    }
}
