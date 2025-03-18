using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Context;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeGivesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WeGivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WeGives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeGives>>> GetWeGives()
        {
            return await _context.WeGives.ToListAsync();
        }

        // GET: api/WeGives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeGives>> GetWeGives(int id)
        {
            var weGives = await _context.WeGives.FindAsync(id);

            if (weGives == null)
            {
                return NotFound();
            }

            return weGives;
        }

        // PUT: api/WeGives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeGives(int id, WeGives weGives)
        {
            if (id != weGives.Id)
            {
                return BadRequest();
            }

            _context.Entry(weGives).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeGivesExists(id))
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

        // POST: api/WeGives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeGives>> PostWeGives(WeGives weGives)
        {
            _context.WeGives.Add(weGives);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeGives", new { id = weGives.Id }, weGives);
        }

        // DELETE: api/WeGives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeGives(int id)
        {
            var weGives = await _context.WeGives.FindAsync(id);
            if (weGives == null)
            {
                return NotFound();
            }

            _context.WeGives.Remove(weGives);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeGivesExists(int id)
        {
            return _context.WeGives.Any(e => e.Id == id);
        }
    }
}
