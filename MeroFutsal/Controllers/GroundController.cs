using Microsoft.AspNetCore.Mvc;

namespace MeroFutsal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroundController : ControllerBase
    {private readonly DataContext _context;

        public GroundController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Grounds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ground>>> GetGrounds()
        {
            return await _context.Grounds.Where(a => a.Isdeleted != true).Select(a => a).ToListAsync();

        } 
        [HttpGet("~/api/Fusal/Ground/{groundId}")]
        public async Task<ActionResult<IEnumerable<Ground>>> GetGroundsbyFutsal(int groundId)
        {
            return await _context.Grounds.Where(a => a.Isdeleted != true && a.Futsalid == groundId && a.Isreserved == false).Select(a => a).ToListAsync();

        }
        [HttpGet("~/api/Fusal/Ground/booked/{Futsalid}")]
        public async Task<ActionResult<IEnumerable<Ground>>> GetReservedGroundsbyFutsal(int id)
        {
            return await _context.Grounds.Where(a => a.Isdeleted != true && a.Futsalid == id && a.Isreserved == true).Select(a => a).ToListAsync();

        }

        // GET: api/Grounds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ground>> GetGround(int id)
        {
            var Ground = await _context.Grounds.FindAsync(id);

            if (Ground == null)
            {
                return NotFound();
            }

            return Ground;
        }

        // PUT: api/Grounds/5
            [HttpPut("{id}")]
        public async Task<IActionResult> PutGround(int id, Ground Ground)
        {
            if (id != Ground.Groundid)
            {
                return BadRequest();
            }

            _context.Entry(Ground).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroundExists(id))
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
        [HttpPut("~/api/Grounds/delete/{id}")]
        public async Task<IActionResult> DelGround(int id)
        {
            var Ground = _context.Grounds.Where(a => a.Groundid == id).FirstOrDefault();

            Ground.Isdeleted = true;

            _context.Entry(Ground).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroundExists(id))
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

        [HttpPost]
        public IActionResult CreateGround(Ground Ground)
        {
            Ground.Isdeleted = false;
            Ground.Isreserved = false;
            _context.Grounds.Add(Ground);
            _context.SaveChanges();
            return Ok(Ground);
        }

        private bool GroundExists(int id)
        {
            return _context.Grounds.Any(e => e.Groundid == id);
        }
    }
}
