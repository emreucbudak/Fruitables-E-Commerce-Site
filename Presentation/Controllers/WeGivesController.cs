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
using Entities.DTO;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeGivesController : ControllerBase
    {
        private readonly IServiceManager _context;

        public WeGivesController(IServiceManager context)
        {
            _context = context;
        }

        // GET: api/WeGives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeGivesDto>>> GetWeGives()
        {
            var x = await _context.WeGivesService.GetAllWeGives(false);
            return Ok(x);
        }

        // GET: api/WeGives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeGivesDto>> GetWeGives(int id)
        {
            var weGives = await _context.WeGivesService.GetWeGives(id,false);

            return weGives;
        }

        // PUT: api/WeGives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeGives(int id, WeGivesDto weGives)
        {
            await _context.WeGivesService.UpdateWeGives(id, weGives);

            return NoContent();
        }

        // POST: api/WeGives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeGives>> PostWeGives(WeGivesDto weGives)
        {
            await _context.WeGivesService.AddWeGives(weGives);

            return NoContent();
        }

        // DELETE: api/WeGives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeGives(int id)
        {
            await _context.WeGivesService.RemoveWeGives(id);

            return NoContent();
        }
    }
}
