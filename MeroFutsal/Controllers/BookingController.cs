using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeroFutsal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly DataContext _context;

        public BookingController(DataContext context)
        {
            _context = context;
        }
        // GET: api/Rooms
        [HttpGet("{Userid}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingsByUserid(int Userid)
        {
            return await _context.Bookings.Where(a => a.Isdeleted != true && a.Userid == Userid).Select(a => a).ToListAsync();

        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings.Where(a => a.Isdeleted != true).Select(a => a).ToListAsync();

        }


        [HttpPost]
        public IActionResult CreateBooking(Booking Booking)
        {
            Booking.Isdeleted = false;

            Booking booking = new Booking()
            {
                Userid = 3,
                
            };
                
            _context.Bookings.Add(booking);

            _context.SaveChanges();
            return Ok(Booking);
        }

        // DELETE: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> DelBooking(int id)
        {
            var booking = _context.Bookings.Where(a => a.Bookingid == id).FirstOrDefault();

            booking.Isdeleted = true;

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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


        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Bookingid == id);
        }
    }
}
