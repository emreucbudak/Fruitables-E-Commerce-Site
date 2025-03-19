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
    public class StatsController : ControllerBase
    {
        private readonly IServiceManager _context;

        public StatsController(IServiceManager context)
        {
            _context = context;
        }

        // GET: api/Stats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stats>>> GetStats()
        {
            var x = await _context.StatsService.GetStats(false);
            return Ok(x);
        }

        // GET: api/Stats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stats>> GetStats(int id)
        {
            var x = await _context.StatsService.GetStatsById(id,false);
            return Ok(x);
        }

        // PUT: api/Stats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStats(int id, Stats stats)
        {
            await _context.StatsService.UpdateStats(id, stats);

            return NoContent();
        }

        // POST: api/Stats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stats>> PostStats(Stats stats)
        {
            await _context.StatsService.AddStats(stats);

            return CreatedAtAction("GetStats", new { id = stats.Id }, stats);
        }

        // DELETE: api/Stats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStats(int id)
        {
            await _context.StatsService.DeleteStats(id);

            return NoContent();
        }


    }
}
