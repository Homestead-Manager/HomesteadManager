using HomesteadManager.Shared.Models;
using HomesteadManagerApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomesteadManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class BedController : ControllerBase
    {
        private readonly BedContext _context;

        public BedController(BedContext context)
        {
            _context = context;
        }

        // GET: api/Bed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bed>>> GetBeds()
        {
            return await _context.Beds.ToListAsync();
        }

        // GET: api/Bed/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bed>> GetBed(string id)
        {
            var Bed = await _context.Beds.FindAsync(id);

            if (Bed == null)
            {
                return NotFound();
            }

            return Bed;
        }

        // PUT: api/Bed/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBed(int id, Bed Bed)
        {
            if (id != Bed.BedID)
            {
                return BadRequest();
            }

            _context.Entry(Bed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BedExists(id))
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

        // POST: api/Bed
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bed>> PostBed(Bed Bed)
        {
            _context.Beds.Add(Bed);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BedExists(Bed.BedID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetBed), new { id = Bed.BedID }, Bed);
        }

        // DELETE: api/Bed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBed(string id)
        {
            var Bed = await _context.Beds.FindAsync(id);
            if (Bed == null)
            {
                return NotFound();
            }

            _context.Beds.Remove(Bed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BedExists(int id)
        {
            return _context.Beds.Any(e => e.BedID == id);
        }
    }
}
