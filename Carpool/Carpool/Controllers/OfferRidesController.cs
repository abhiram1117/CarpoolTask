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
    public class OfferRidesController : ControllerBase
    {
        private readonly CarpoolContext _context;

        public OfferRidesController(CarpoolContext context)
        {
            _context = context;
        }

        // GET: api/OfferRides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferRide>>> GetOfferRide()
        {
          if (_context.OfferRide == null)
          {
              return NotFound();
          }
            return await _context.OfferRide.ToListAsync();
        }

        // GET: api/OfferRides/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<OfferRide>> GetOfferRide(int id)
        //{
        //  if (_context.OfferRide == null)
        //  {
        //      return NotFound();
        //  }
        //    var offerRide = await _context.OfferRide.FindAsync(id);

        //    if (offerRide == null)
        //    {
        //        return NotFound();
        //    }

        //    return offerRide;
        //}

        //// PUT: api/OfferRides/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOfferRide(int id, OfferRide offerRide)
        //{
        //    if (id != offerRide.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(offerRide).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OfferRideExists(id))
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

        // POST: api/OfferRides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OfferRide>> PostOfferRide(OfferRide offerRide)
        {
          if (_context.OfferRide == null)
          {
              return Problem("Entity set 'CarpoolContext.OfferRide'  is null.");
          }
            _context.OfferRide.Add(offerRide);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOfferRide", new { id = offerRide.Id }, offerRide);
        }

        // DELETE: api/OfferRides/5
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteOfferRide(int id)
    //    {
    //        if (_context.OfferRide == null)
    //        {
    //            return NotFound();
    //        }
    //        var offerRide = await _context.OfferRide.FindAsync(id);
    //        if (offerRide == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.OfferRide.Remove(offerRide);
    //        await _context.SaveChangesAsync();

    //        return NoContent();
    //    }

    //    private bool OfferRideExists(int id)
    //    {
    //        return (_context.OfferRide?.Any(e => e.Id == id)).GetValueOrDefault();
    //    }
    }
}
