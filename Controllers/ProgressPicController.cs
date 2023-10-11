using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fitness_tracker_api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fitness_tracker_api.Data;

namespace fitness_tracker_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressPicController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProgressPicController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProgressPic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgressPic>>> GetProgressPics()
        {
            return await _context.ProgressPics.ToListAsync();
        }

        // GET: api/ProgressPic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgressPic>> GetProgressPic(int id)
        {
            var progressPic = await _context.ProgressPics.FindAsync(id);

            if (progressPic == null)
            {
                return NotFound();
            }

            return progressPic;
        }

        // PUT: api/ProgressPic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgressPic(int id, ProgressPic progressPic)
        {
            if (id != progressPic.UserID)
            {
                return BadRequest();
            }

            _context.Entry(progressPic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgressPicExists(id))
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

        // POST: api/ProgressPic
        [HttpPost]
        public async Task<ActionResult<ProgressPic>> PostUser(ProgressPic progressPic)
        {
            _context.ProgressPics.Add(progressPic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgressPic", new { id = progressPic.PicID }, progressPic);
        }

        // DELETE: api/ProgressPic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgressPic(int id)
        {
            var progressPic = await _context.ProgressPics.FindAsync(id);
            if (progressPic == null)
            {
                return NotFound();
            }

            _context.ProgressPics.Remove(progressPic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgressPicExists(int id)
        {
            return _context.ProgressPics.Any(e => e.PicID == id);
        }
    }
}
