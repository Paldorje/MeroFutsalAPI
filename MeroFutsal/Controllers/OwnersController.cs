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
using System.Security.Cryptography;

namespace MeroFutsal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly DataContext _context;

        public OwnersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Owners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetOwners()
        {
            return await _context.Owners.ToListAsync();
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwner(string id)
        {
            var owner = await _context.Owners.FindAsync(id);

            if (owner == null)
            {
                return NotFound();
            }

            return owner;
        }

        [HttpGet("byEmail{email}")]
        public async Task<ActionResult<OwnerDto>> GetOwnerByEmail(string email)
        {
            var owner = await _context.Owners.FindAsync(email);

            if (owner == null)
            {
                return NotFound();
            }

            var owner1 = new OwnerDto
            {
                Email = owner.Email,
                Password = "can't show",
                Name = owner.Name,
                Address = owner.Address,
                Phone = owner.Phone,
                Photo = owner.Photo,
                IsAvailable = owner.IsAvailable,
                IsDeleted = owner.IsDeleted,

            };

            return owner1;
        }


        [HttpPost("login {email}, {password}")]
        public async Task<ActionResult<Owner>> PostOwner(string email, string password)
        {
            var owner = await _context.Owners.FindAsync(email);

            if (owner.Email != email)
            {
                return BadRequest("User Not Found");
            }

            if (!VerifyPasswordHash(password, owner.PasswordHash, owner.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }

            //string token = CreateToken(user);

            return Ok(owner);
        }

        // PUT: api/Owners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(string id, Owner owner)
        {
            if (id != owner.Email)
            {
                return BadRequest();
            }

            _context.Entry(owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
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

        // POST: api/Owners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(OwnerDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var owner = new Owner
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone,
                Photo = request.Photo,
                IsAvailable = request.IsAvailable,
                IsDeleted = request.IsDeleted,

            };


            _context.Owners.Add(owner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OwnerExists(owner.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOwner", new { id = owner.Email }, owner);
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(string id)
        {
            var owner = await _context.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owners.Remove(owner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OwnerExists(string id)
        {
            return _context.Owners.Any(e => e.Email == id);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
