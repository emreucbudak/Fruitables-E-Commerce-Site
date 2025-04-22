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
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _context;

        public CategoriesController(IServiceManager context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var x = await _context.CategoryService.GetAllCategories(false);
            return Ok(x);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var x = await _context.CategoryService.GetCategoryById(id);
            return Ok(x);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id ,Category category)
        {
            await _context.CategoryService.UpdateCategoryFromService(id , category);

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await _context.CategoryService.AddCategoryFromService(category);

            return CreatedAtAction("GetCategory", new { id = category.CategoryID }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _context.CategoryService.DeleteCategoryFromService(id);


            return NoContent();
        }


    }
}
