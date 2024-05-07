using HomesteadManager.Shared.Models;
using HomesteadManagerApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomesteadManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardenController : ControllerBase
    {
        private readonly GardenContext _context;

        public GardenController(GardenContext context)
        {
            _context = context;
        }

        // GET: api/Garden
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garden>>> GetGardens()
        {
            return await _context.Gardens.ToListAsync();
        }

        // GET: api/Garden/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Garden>> GetGarden(string id)
        {
            var Garden = await _context.Gardens.FindAsync(id);

            if (Garden == null)
            {
                return NotFound();
            }

            return Garden;
        }

        // PUT: api/Garden/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarden(int id, Garden Garden)
        {
            if (id != Garden.GardenID)
            {
                return BadRequest();
            }

            _context.Entry(Garden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GardenExists(id))
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

        // POST: api/Garden
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Garden>> PostGarden(Garden Garden)
        {
            _context.Gardens.Add(Garden);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GardenExists(Garden.GardenID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetGarden), new { id = Garden.GardenID }, Garden);
        }

        // DELETE: api/Garden/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGarden(string id)
        {
            var Garden = await _context.Gardens.FindAsync(id);
            if (Garden == null)
            {
                return NotFound();
            }

            _context.Gardens.Remove(Garden);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GardenExists(int id)
        {
            return _context.Gardens.Any(e => e.GardenID == id);
        }
    }
}
