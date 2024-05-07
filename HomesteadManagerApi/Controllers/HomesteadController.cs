using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomesteadManagerApi.Data;
using HomesteadManager.Shared.Models;

namespace HomesteadManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesteadController : ControllerBase
    {
        private readonly HomesteadContext _context;

        public HomesteadController(HomesteadContext context)
        {
            _context = context;
        }

        // GET: api/Homestead
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Homestead>>> GetHomesteads()
        {
            return await _context.Homesteads.ToListAsync();
        }

        // GET: api/Homestead/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Homestead>> GetHomestead(string id)
        {
            var homestead = await _context.Homesteads.FindAsync(id);

            if (homestead == null)
            {
                return NotFound();
            }

            return homestead;
        }

        // PUT: api/Homestead/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomestead(string id, Homestead homestead)
        {
            if (id != homestead.Id)
            {
                return BadRequest();
            }

            _context.Entry(homestead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomesteadExists(id))
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

        // POST: api/Homestead
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Homestead>> PostHomestead(Homestead homestead)
        {
            _context.Homesteads.Add(homestead);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HomesteadExists(homestead.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetHomestead), new { id = homestead.Id }, homestead);
        }

        // DELETE: api/Homestead/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomestead(string id)
        {
            var homestead = await _context.Homesteads.FindAsync(id);
            if (homestead == null)
            {
                return NotFound();
            }

            _context.Homesteads.Remove(homestead);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomesteadExists(string id)
        {
            return _context.Homesteads.Any(e => e.Id == id);
        }
    }
}
