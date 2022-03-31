//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace MeroFutsal.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PhotosController : ControllerBase
//    {
//        private readonly DataContext _context;

//        public PhotosController(DataContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Photos
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Photo>>> GetPhotosByGroundId(int id)
//        {
//            return await _context.Photos.Where(a => a.Futsalid == id).Select(a => a).ToListAsync();
//        }

//        // GET: api/Photos/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Photo>> GetPhoto(int id)
//        {
//            var photo = await _context.Photos.FindAsync(id);

//            if (photo == null)
//            {
//                return NotFound();
//            }

//            return photo;
//        }

//        // PUT: api/Photos/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutPhoto(int id, Photo photo)
//        {
//            if (id != photo.Photoid)
//            {
//                return BadRequest();
//            }

//            _context.Entry(photo).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!PhotoExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Photos
//        // To protect from overposting attacks, see
//        [HttpPost]
//        public IActionResult CreatePhoto(Photo photo)
//        {
//            _context.Photos.Add(photo);
//            //_context.SaveChanges();
//            return Ok(photo);
//        }

//        // DELETE: api/Photos/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeletePhoto(int id)
//        {
//            var photo = await _context.Photos.FindAsync(id);
//            if (photo == null)
//            {
//                return NotFound();
//            }

//            _context.Photos.Remove(photo);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool PhotoExists(int id)
//        {
//            return _context.Photos.Any(e => e.Photoid == id);
//        }
//    }
//}
