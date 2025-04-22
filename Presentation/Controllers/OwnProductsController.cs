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
using Presentation.ActionFilters;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogFilterAttribute))]
    public class OwnProductsController : ControllerBase
    {
        private readonly IServiceManager _context;

        public OwnProductsController(IServiceManager context)
        {
            _context = context;
        }

        // GET: api/OwnProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnProduct>>> GetOwnProducts()
        {
            var x = await _context.OwnProductsService.GetAllOwnProducts(false);
            return Ok(x);
        }

        // GET: api/OwnProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnProduct>> GetOwnProduct(int id)
        {
            var x = await _context.OwnProductsService.GetOwnProductById(id);
            return Ok(x);
        }

        // PUT: api/OwnProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwnProduct(int id, OwnProduct ownProduct)
        {
            await _context.OwnProductsService.UpdateOwnProductsFromService(id, ownProduct);

            return NoContent();
        }

        // POST: api/OwnProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<OwnProduct>> PostOwnProduct(OwnProduct ownProduct)
        {
            await _context.OwnProductsService.AddOwnProductsFromService(ownProduct);

            return CreatedAtAction("GetOwnProduct", new { id = ownProduct.ID }, ownProduct);
        }

        // DELETE: api/OwnProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwnProduct(int id)
        {
            await _context.OwnProductsService.RemoveOwnProductsFromService(id);


            return NoContent();
        }


    }
}
