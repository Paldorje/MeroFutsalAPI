#nullable disable
using Microsoft.AspNetCore.Mvc;
namespace MeroFutsal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }


        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{userid}")]
        public async Task<ActionResult<User>> GetUser(int userid)
        {
            var user = await _context.Users.FindAsync(userid);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        [HttpPut("{userid}")]


        public async Task<IActionResult> PutUser(int userid, User user)
        {


            if (userid != user.userid)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(userid))
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

        // POST: api/register
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { user.userid }, user);
        }

        //POST: api/login
        //[HttpPost("login")]

        //public async Task<ActionResult<string>> Login(User User)
        //{
        //    if (User.Email != request.Email)
        //    {
        //        return BadRequest("User not Found");
        //    }
        //    else
        //    {
        //        return Ok();
        //    }
        //}


        // DELETE: api/User/5
        [HttpDelete("{userid}")]
        public async Task<IActionResult> DeleteUser(int userid)
        {
            var user = await _context.Users.FindAsync(userid);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int userid)
        {
            return _context.Users.Any(e => e.userid == userid);
        }
    }
}
