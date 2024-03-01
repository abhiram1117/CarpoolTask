using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carpool.Data;
using Carpool.Models;

namespace Carpool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingRidesController : ControllerBase
    {
        private readonly CarpoolContext _context;

        public BookingRidesController(CarpoolContext context)
        {
            _context = context;
        }

        // GET: api/BookingRides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingRide>>> GetBookingRide()
        {
          if (_context.BookingRide == null)
          {
              return NotFound();
          }
            return await _context.BookingRide.ToListAsync();
        }

        // GET: api/BookingRides/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<BookingRide>> GetBookingRide(int id)
        //{
        //  if (_context.BookingRide == null)
        //  {
        //      return NotFound();
        //  }
        //    var bookingRide = await _context.BookingRide.FindAsync(id);

        //    if (bookingRide == null)
        //    {
        //        return NotFound();
        //    }

        //    return bookingRide;
        //}

        // PUT: api/BookingRides/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBookingRide(int id, BookingRide bookingRide)
        //{
        //    if (id != bookingRide.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(bookingRide).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookingRideExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/BookingRides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingRide>> PostBookingRide(BookingRide bookingRide)
        {
          if (_context.BookingRide == null)
          {
              return Problem("Entity set 'CarpoolContext.BookingRide'  is null.");
          }
            _context.BookingRide.Add(bookingRide);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingRide", new { id = bookingRide.Id }, bookingRide);
        }

        // DELETE: api/BookingRides/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBookingRide(int id)
        //{
        //    if (_context.BookingRide == null)
        //    {
        //        return NotFound();
        //    }
        //    var bookingRide = await _context.BookingRide.FindAsync(id);
        //    if (bookingRide == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.BookingRide.Remove(bookingRide);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool BookingRideExists(int id)
        //{
        //    return (_context.BookingRide?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
