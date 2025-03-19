using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Context;
using Services.Interfaces;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IServiceManager _context;

        public TestimonialsController(IServiceManager context)
        {
            _context = context;
        }

        // GET: api/Testimonials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testimonials>>> GetTestimonials()
        {
            var x = await _context.TestimonialService.GetTestimonials(false);
            return Ok(x);

        }

        // GET: api/Testimonials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Testimonials>> GetTestimonials(int id)
        {
            var testimonials = await _context.TestimonialService.GetTestimonialss(id, false);
            return Ok(testimonials);
        }

        // PUT: api/Testimonials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestimonials(int id, Testimonials testimonials)
        {
            await _context.TestimonialService.UpdateTestimonial(id, testimonials);

            return NoContent();
        }

        // POST: api/Testimonials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Testimonials>> PostTestimonials(Testimonials testimonials)
        {
            await _context.TestimonialService.AddTestimonial(testimonials);

            return CreatedAtAction("GetTestimonials", new { id = testimonials.Id }, testimonials);
        }

        // DELETE: api/Testimonials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonials(int id)
        {
            await _context.TestimonialService.DeleteTestimonial(id);

            return NoContent();
        }


    }
}
