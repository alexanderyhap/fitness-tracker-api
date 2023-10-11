using fitness_tracker_api.Data;
using fitness_tracker_api.Models;
using Microsoft.EntityFrameworkCore;

namespace fitness_tracker_api.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly AppDbContext _context;

        public WorkoutService(AppDbContext context)
        {
            _context = context;
        }

        public Task<bool> AddWorkout(Workout workout)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteWorkout(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Workout> GetWorkoutById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Workout>> GetWorkouts()
        {
            return await _context.Workouts.ToListAsync();
        }

        public Task<bool> UpdateWorkout(Workout workout)
        {
            throw new NotImplementedException();
        }

        // ... implement other methods from the interface
    }
}
