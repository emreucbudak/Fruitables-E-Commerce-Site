using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Context;

namespace FruitablesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TestimonialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Testimonials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testimonials>>> GetTestimonials()
        {
            return await _context.Testimonials.ToListAsync();
        }

        // GET: api/Testimonials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Testimonials>> GetTestimonials(int id)
        {
            var testimonials = await _context.Testimonials.FindAsync(id);

            if (testimonials == null)
            {
                return NotFound();
            }

            return testimonials;
        }

        // PUT: api/Testimonials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestimonials(int id, Testimonials testimonials)
        {
            if (id != testimonials.Id)
            {
                return BadRequest();
            }

            _context.Entry(testimonials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestimonialsExists(id))
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

        // POST: api/Testimonials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Testimonials>> PostTestimonials(Testimonials testimonials)
        {
            _context.Testimonials.Add(testimonials);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestimonials", new { id = testimonials.Id }, testimonials);
        }

        // DELETE: api/Testimonials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonials(int id)
        {
            var testimonials = await _context.Testimonials.FindAsync(id);
            if (testimonials == null)
            {
                return NotFound();
            }

            _context.Testimonials.Remove(testimonials);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestimonialsExists(int id)
        {
            return _context.Testimonials.Any(e => e.Id == id);
        }
    }
}
