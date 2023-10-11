using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fitness_tracker_api.Models;
using fitness_tracker_api.Data;

namespace fitness_tracker_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutExerciseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkoutExerciseController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkoutExercise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutExercise>>> GetWorkoutExercises()
        {
            return await _context.WorkoutExercises.ToListAsync();
        }

        // GET: api/WorkoutExercise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutExercise>> GetWorkoutExercise(int id)
        {
            var workoutExercise = await _context.WorkoutExercises.FindAsync(id);

            if (workoutExercise == null)
            {
                return NotFound();
            }

            return workoutExercise;
        }

        // PUT: api/WorkoutExercise/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, WorkoutExercise workoutExercise)
        {
            if (id != workoutExercise.WorkoutExerciseID)
            {
                return BadRequest();
            }

            _context.Entry(workoutExercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExerciseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WorkoutExercise
        [HttpPost]
        public async Task<ActionResult<WorkoutExercise>> PostUser(WorkoutExercise workoutExercise)
        {
            _context.WorkoutExercises.Add(workoutExercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkoutExercises", new { id = workoutExercise.WorkoutExerciseID }, workoutExercise);
        }

        // DELETE: api/WorkoutExercise/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutExercise(int id)
        {
            var workoutExercise = await _context.WorkoutExercises.FindAsync(id);
            if (workoutExercise == null)
            {
                return NotFound();
            }

            _context.WorkoutExercises.Remove(workoutExercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutExerciseExists(int id)
        {
            return _context.WorkoutExercises.Any(e => e.WorkoutExerciseID == id);
        }
    }
}
