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
    public class OwnProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OwnProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OwnProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnProduct>>> GetOwnProducts()
        {
            return await _context.OwnProducts.ToListAsync();
        }

        // GET: api/OwnProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnProduct>> GetOwnProduct(int id)
        {
            var ownProduct = await _context.OwnProducts.FindAsync(id);

            if (ownProduct == null)
            {
                return NotFound();
            }

            return ownProduct;
        }

        // PUT: api/OwnProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwnProduct(int id, OwnProduct ownProduct)
        {
            if (id != ownProduct.ID)
            {
                return BadRequest();
            }

            _context.Entry(ownProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnProductExists(id))
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

        // POST: api/OwnProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OwnProduct>> PostOwnProduct(OwnProduct ownProduct)
        {
            _context.OwnProducts.Add(ownProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOwnProduct", new { id = ownProduct.ID }, ownProduct);
        }

        // DELETE: api/OwnProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwnProduct(int id)
        {
            var ownProduct = await _context.OwnProducts.FindAsync(id);
            if (ownProduct == null)
            {
                return NotFound();
            }

            _context.OwnProducts.Remove(ownProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OwnProductExists(int id)
        {
            return _context.OwnProducts.Any(e => e.ID == id);
        }
    }
}
