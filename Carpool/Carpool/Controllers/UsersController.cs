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

    public class UsersController : ControllerBase
    {
        private readonly CarpoolContext _context;

        public UsersController(CarpoolContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'CarpoolContext.User'  is null.");
          }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        

        // POST: api/User/Login
        [HttpPost("Login")]
        public async Task<ActionResult<User>> LoginUser(User user)
        {
            

            
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.email == user.email);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            
            if (existingUser.password != user.password)
            {
                return BadRequest("Incorrect password.");
            }

            return Ok(existingUser);
        }

        // POST: api/Users/Signup
        [HttpPost("Signup")]
        public async Task<ActionResult<User>> SignupUser(User user)
        {
            
            // Check if a user with the provided email already exists
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.email == user.email);

            if (existingUser != null)
            {
                return Conflict("User already exists.");
            }

            // Save the new user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
    }
}
