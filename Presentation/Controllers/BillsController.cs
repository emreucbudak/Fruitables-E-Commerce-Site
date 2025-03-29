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
    public class BillsController : ControllerBase
    {
        private readonly IServiceManager _context;

        public BillsController(IServiceManager context)
        {
            _context = context;
        }

        // GET: api/Bills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillsDtoForList>>> GetBills()
        {
            var x =  await _context.BillsService.GetAllBillsFromService(false);
            return Ok(x);

        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillsDtoForList>> GetBills(int id)
        {
            var x = await _context.BillsService.GetBillsFromService(id);
            return Ok(x);
        }

        // PUT: api/Bills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBills(int id , BillsDtoForUpdate bills)
        {
            await _context.BillsService.UpdateBillsFromService(id, bills);
            return NoContent();
        }

        // POST: api/Bills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BillsDtoForInsert>> PostBills(BillsDtoForInsert bills)
        {
            await _context.BillsService.AddBillsFromService(bills);

            return NoContent();
        }

        // DELETE: api/Bills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBills(int id)
        {
            await _context.BillsService.RemoveBillsFromService(id);

            return NoContent();
        }


    }
}
