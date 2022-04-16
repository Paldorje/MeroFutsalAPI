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
    public class FutsalsController : ControllerBase
    {
        private readonly DataContext _context;

        public FutsalsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Futsals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Futsal>>> GetFutsals()
        {
            return await _context.Futsals.ToListAsync();
        }

        // GET: api/Futsals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Futsal>>> GetFutsal(int id)
        {
            var futsal = await _context.Futsals
                .Where(f => f.Futsalid == id)
                .Include(f => f.Owners)
                .Include(f => f.Grounds)
                .ToListAsync();

            if (futsal == null)
            {
                return NotFound();
            }

            return futsal;
        }

        // PUT: api/Futsals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Futsal>> PostFutsal(CreateFutsalDto request)
        {
            var owner = await _context.Owners.FindAsync(request.OwnerEmail);
            if (owner == null)
                return NotFound();

            var newFutsal = new Futsal
            {
                Futsalid = request.Futsalid,
                FutsalName = request.FutsalName,
                Cost = request.Cost,
                Location = request.Location,
                IsDeleted = request.IsDeleted,
                IsReserved = request.IsReserved,
                OwnerEmail = request.OwnerEmail,
            };

            _context.Futsals.Add(newFutsal);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FutsalExists(newFutsal.Futsalid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFutsal", new { id = newFutsal.Futsalid }, newFutsal);
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
