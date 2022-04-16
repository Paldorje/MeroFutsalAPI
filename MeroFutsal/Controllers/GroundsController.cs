#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeroFutsal.Data;
using MeroFutsal.Models;

namespace MeroFutsal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroundsController : ControllerBase
    {
        private readonly DataContext _context;

        public GroundsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Grounds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ground>>> GetGrounds()
        {
            return await _context.Grounds.ToListAsync();
        }

        // GET: api/Grounds/5
        [HttpGet("{futsalid}")]
        public async Task<ActionResult<List<Ground>>> GetGround(int futsalid)
        {
            var ground = await _context.Grounds.
                Where(x => x.Futsalid == futsalid).
                ToListAsync();

            if (ground == null)
            {
                return NotFound();
            }

            return ground;
        }

        // PUT: api/Grounds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGround(int id, Ground ground)
        {
            if (id != ground.Groundid)
            {
                return BadRequest();
            }

            _context.Entry(ground).State = EntityState.Modified;

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

        // POST: api/Grounds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ground>> PostGround(CreateGroundDto request)
        {
            var futsal = await _context.Futsals.FindAsync(request.Futsalid);
            if (futsal == null)
                return NotFound();

            var newGround = new Ground
            {
                Groundid = request.Groundid,
                GroundName = request.GroundName,
                Futsalid = request.Futsalid,
                Isdeleted = request.Isdeleted,
                Isreserved = request.Isreserved,
            };

            _context.Grounds.Add(newGround);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGround", new { id = newGround.Groundid }, newGround);
        }

        // DELETE: api/Grounds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGround(int id)
        {
            var ground = await _context.Grounds.FindAsync(id);
            if (ground == null)
            {
                return NotFound();
            }

            _context.Grounds.Remove(ground);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroundExists(int id)
        {
            return _context.Grounds.Any(e => e.Groundid == id);
        }
    }
}
