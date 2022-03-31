#nullable disable
using Microsoft.AspNetCore.Mvc;
namespace MeroFutsal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutsalsController : ControllerBase
    {
        private readonly DataContext _context;

        public FutsalsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Futsals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Futsal>>> Getfutsal()
        {
            return await _context.Futsals.ToListAsync();
        }

        // GET: api/Futsals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Futsal>> GetFutsal(int id)
        {
            var futsal = await _context.Futsals.FindAsync(id);

            if (futsal == null)
            {
                return NotFound();
            }

            return futsal;
        }

        // PUT: api/Futsals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFutsal(int id, Futsal futsal)
        {
            if (id != futsal.Futsalid)
            {
                return BadRequest();
            }

            _context.Entry(futsal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FutsalExists(id))
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

        // POST: api/Futsals
        [HttpPost]
        public async Task<ActionResult<Futsal>> PostFutsal(Futsal futsal)
        {
            _context.Futsals.Add(futsal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFutsal", new { id = futsal.Futsalid }, futsal);
        }

        // DELETE: api/Futsals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFutsal(int id)
        {
            var futsal = await _context.Futsals.FindAsync(id);
            if (futsal == null)
            {
                return NotFound();
            }

            _context.Futsals.Remove(futsal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FutsalExists(int id)
        {
            return _context.Futsals.Any(e => e.Futsalid == id);
        }
    }
}
