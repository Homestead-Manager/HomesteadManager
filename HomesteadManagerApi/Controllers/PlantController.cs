using HomesteadManager.Shared.Models;
using HomesteadManagerApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomesteadManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly PlantContext _context;

        public PlantController(PlantContext context)
        {
            _context = context;
        }

        // GET: api/Plant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plant>>> GetPlants()
        {
            return await _context.Plants.ToListAsync();
        }

        // GET: api/Plant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plant>> GetPlant(string id)
        {
            var Plant = await _context.Plants.FindAsync(id);

            if (Plant == null)
            {
                return NotFound();
            }

            return Plant;
        }

        // PUT: api/Plant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlant(int id, Plant Plant)
        {
            if (id != Plant.PlantID)
            {
                return BadRequest();
            }

            _context.Entry(Plant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(id))
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

        // POST: api/Plant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plant>> PostPlant(Plant Plant)
        {
            _context.Plants.Add(Plant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlantExists(Plant.PlantID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetPlant), new { id = Plant.PlantID }, Plant);
        }

        // DELETE: api/Plant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlant(string id)
        {
            var Plant = await _context.Plants.FindAsync(id);
            if (Plant == null)
            {
                return NotFound();
            }

            _context.Plants.Remove(Plant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantExists(int id)
        {
            return _context.Plants.Any(e => e.PlantID == id);
        }
    }
}
